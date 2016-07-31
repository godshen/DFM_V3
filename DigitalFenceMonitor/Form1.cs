using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Media;
using System.Net;
using System.IO.Ports;

namespace DigitalFenceMonitor
{
    public partial class FormMain : Form
    {

        static public string NowUser = "null";
        //定义UDP通信变量
        private IPEndPoint ipLocalPoint;
        private EndPoint RemotePoint;     
        private Socket mySocket;
        static public EndPoint[] RemotePointArr = new EndPoint[1000];

        //定义本机IP地址与端口号，IP自动读取，端口号默认80
        static public IPAddress[] AddressList = null;
        static public IPAddress localIP;
        static public int localPort = 80;        

        //定义基站设置主要数据，用于接收
        static public string[,] StaSetData = new string[1000, 2];
        static public int StaSetCount = 0;
        //定义防区设置主要数据，用于轮询
        static public string[,] AreaSetData = new string[1000, 2];
        static public int AreaSetCount = 0;
        private int FunGetInfoCount = 0;

        //Dictionary<string, int> FunGetInfoCountBuff = new Dictionary<string, int>();
        //Dictionary<string, Dictionary<int,int>> AreaSetDataBuff = new Dictionary<string, Dictionary<int,int>>();

        static public bool SetAreaNum = false;

        static public DataTable AreaMapDT = null;
        static public OleDbDataAdapter AreaMapDA = null;
        static public SoundPlayer player = new SoundPlayer();

        
        //定义全局命令通信协议字符串 以及 指令号Cmd
        private int ProtocolCmd = -1;
        static public byte[][] ProtocolData = new byte[2][]{
            new byte[]{ 0xAA,0xAB,0xF8,0x06,0x00,0x00},
            new byte[]{ 0xAA,0xAC,0xF8,0x06,0x00,0x00}
        };

        //存储串口
        string[] PortName;

        //用来存储当前选中TreeNode点
        static public string CurrentNode = null;
        //设置全局命令定时发送计时器
        System.Timers.Timer timerAllInfo = new System.Timers.Timer(50);
        //设置轮询定时发送计时器
        System.Timers.Timer timerGetInfo = new System.Timers.Timer(100);
        //设置警报清空定时器
        System.Timers.Timer alertClear = new System.Timers.Timer(8000);
        //设置警报地图闪烁定时器
        System.Timers.Timer timeralerttwinkle = new System.Timers.Timer(500);
        //设置昼夜转换定时器
        System.Timers.Timer daynightswitch = new System.Timers.Timer(30 * 1000);
        //载入地图
        public static System.Timers.Timer reloadmap = new System.Timers.Timer(300);
        public bool relaodflag = true;

        static public Dictionary<string, DayNightBuffCLS> DayNightBuff = new Dictionary<string,DayNightBuffCLS>();
        public class DayNightBuffCLS
        {
            public DateTime Day, Night;
            public int DayVol, NightVol;

            public DayNightBuffCLS(DateTime dt0,DateTime dt1,int vol0,int vol1)
            {
                Day = dt0;
                Night = dt1;
                DayVol = vol0;
                NightVol = vol1;
            }

        }
        //定义数据库连接变量
        static public OleDbConnection conn = new OleDbConnection();
        //定义IP:Port<->基站名互转数组
        static public Dictionary<string, string> StaBuff = new Dictionary<string, string>();
        static public Dictionary<string, string> IPBuff = new Dictionary<string, string>();

        //定义IP:Port<->Position名互转数组
        static public Dictionary<string, string> ContentBuff = new Dictionary<string, string>();

        //定义Alert转数组
        static public Dictionary<string, byte> LastAlertBuff = new Dictionary<string, byte>();

        //定义联动设置数组
        static public Dictionary<string, string> LinkageBuff = new Dictionary<string, string>();

        

        //地图数组
        List<string> SaveMap = new List<string>();
        public FormMain()
        {
            InitializeComponent();
            int count = this.Controls.Count * 2 + 2;
            float[] factor = new float[count];
            int i = 0;
            factor[i++] = Size.Width;
            factor[i++] = Size.Height;
            foreach (Control ctrl in this.Controls)
            {
                factor[i++] = ctrl.Location.X / (float)Size.Width;
                factor[i++] = ctrl.Location.Y / (float)Size.Height;
                ctrl.Tag = ctrl.Size;
            }
            Tag = factor;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //跨线程修改控件，主要目的是动态修改TreeView的内容
            Control.CheckForIllegalCrossThreadCalls = false;
            string HoyoSerial = null;
            string RegDate = null;

            //初始化数据库
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = DigitalFence.accdb;" + @"Jet OleDb:Database Password = hoyosh51098876";
            
            try {
                conn.Open();
                string sql = "select HoyoSerial,RegDate from tb_reg";
                DataTable tempdt = new DataTable();
                OleDbDataAdapter tempda = new OleDbDataAdapter(sql, conn);
                tempda.Fill(tempdt);
                HoyoSerial = tempdt.Rows[0]["HoyoSerial"].ToString();
                RegDate = tempdt.Rows[0]["RegDate"].ToString();
                if (RegDate == "null")
                {
                    DateTime date = DateTime.Now;
                    RegDate = date.ToString();
                    sql = "";
                    sql += " update tb_reg set";
                    sql += " RegDate = '" + date.ToString() + "'";
                    OleDbCommand comm = new OleDbCommand(sql, conn);
                    comm.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("找不到数据库文件,或未安装数据库驱动", "警告");
                quit();
            }
            conn.Close();
            //设置全局命令计时器，间隔50毫秒
            timerAllInfo.Elapsed += new System.Timers.ElapsedEventHandler(All_CMD);//回调函数
            timerAllInfo.AutoReset = true;//循环执行
            //设置轮询计时器，间隔100毫秒
            timerGetInfo.Elapsed += new System.Timers.ElapsedEventHandler(FunGetInfo);//轮询发送
            timerGetInfo.AutoReset = true;//循环执行    
            //设置警报清空定时器，间隔5秒
            alertClear.Elapsed += new System.Timers.ElapsedEventHandler(AlertClearFun);
            alertClear.AutoReset = true;//循环执行       
            //设置警报地图闪烁定时器，间隔0.5秒
            timeralerttwinkle.Elapsed += new System.Timers.ElapsedEventHandler(AlertTwinkel);
            timeralerttwinkle.AutoReset = true;//循环执行  
            //设置昼夜转换功能
            daynightswitch.Elapsed += new System.Timers.ElapsedEventHandler(DayNightSwitchFun);
            daynightswitch.AutoReset = true;
            //设置昼夜转换功能
            reloadmap.Elapsed += new System.Timers.ElapsedEventHandler(LoadDigitalMap);
            reloadmap.AutoReset = true;

            //从数据库获取数据初始化StaSetData数组和AreaSetData数组
            GetOLEDBData();
            //获取本机IP
            localIP = getValidIP(getIPAddress());
            //获取地图图片
            GetMapImage();

            //将初试化数据更新至TreeView
            Load_TreeView();
            AlertInfo();
            //将轮询数据写入；设置接受数据线程
            DataBeginFun();

            //开启轮询定时器
            alertClear.Start();
            daynightswitch.Start();

            //绘制防区线
            pictureBox_edit.Parent = pictureBox_Map;
            g = pictureBox_edit.CreateGraphics();
            InitAlertArea();

            player.Load();

            if (HoyoSerial=="null")
            {
                DateTime now = DateTime.Now;//Convert.ToDateTime("2016/05/26 17:11:11");
                // 
                DateTime reg = Convert.ToDateTime(RegDate);
                double rt = (now - reg).TotalMilliseconds / (1000.00 * 3600 * 24);
                if (rt > 0 && rt < 31)
                    MessageBox.Show("剩余使用天数:\r\n" + (31 - rt).ToString().ToString().Split('.')[0] + "天", "未注册用户");
                else
                {
                    if (rt <= 0)
                    {
                        MessageBox.Show("日期错误", "警告");
                        quit();
                    }
                    else
                    {
                        MessageBox.Show("这里是强行注册界面");
                        quit();
                    }

                }
            }

            /*
            //登陆界面
            */
            FormLogin login = new FormLogin();
            login.Owner = this;
            login.StartPosition = FormStartPosition.CenterScreen;
            login.ShowDialog();
                

        }



        private void LoadDigitalMap(object source, System.Timers.ElapsedEventArgs e)
        {
            reloadmap.Stop();
            
            relaodflag = true;
            InitAlertArea();
            reloadmap.Interval = 10;         
        }
        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            lb_thismap.Text = "";
            if (e.TabPageIndex == 0) { reloadmap.Start(); }        
        }
        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            reloadmap.Start();
        }
        private void FormMain_Activated(object sender, EventArgs e)
        {
            reloadmap.Start();
        }

        private void Load_TreeView()
        {
            treeView.LabelEdit = true;//可编辑状态

            if (conn.State == ConnectionState.Closed) conn.Open();
            string sql = "select DeviceType,Map,Descripe from tb_AreaSet";
            DataTable tempdt = new DataTable();
            OleDbDataAdapter tempda = new OleDbDataAdapter(sql, conn);
     
            tempda.Fill(tempdt);

            treeView.Nodes.Clear();
            TreeNode t1 = new TreeNode("0");
            TreeNode t2 = new TreeNode("0");
            TreeNode t3 = new TreeNode("0");
            treeView.Nodes.Add(t1);
            t1.Nodes.Add(t2);
            t2.Nodes.Add(t3);

            for (int i = 0; i < tempdt.Rows.Count; i++)
            {
                bool repeat = true;
                string str = tempdt.Rows[i]["Map"].ToString().Split('-')[0], str1,str12, str2, str22, str3, des, des2, type;
                type = tempdt.Rows[i]["DeviceType"].ToString();

                str1 = str.Split(',')[0];
                str12 = str1 + " -- " + StaBuff[str1.Trim()];

                str2 = str.Split(',')[1];
                str22 = "撤防-" + type + ": " + String.Format("{0:000}", Convert.ToInt16(str2)) + "---";

                str3 = tempdt.Rows[i]["Map"].ToString().Split('-')[1];

                des =  tempdt.Rows[i]["Descripe"].ToString();
                des2 = "--防区>" + des;



                foreach (TreeNode node in treeView.Nodes)
                {

                    if (node.Name.Trim() == str1.Trim())
                    {
                        if (str3 == "0")
                        {
                            TreeNode node2 = new TreeNode(str2);
                            node2.Text = str22;
                            node2.Name = str2;
                            TreeNode node3 = new TreeNode(des);
                            node3.Text = des2;
                            node3.Name = des;

                            node.Nodes.Add(node2);
                            node2.Nodes.Add(node3);
                        }
                        else
                        {
                            string add = tempdt.Rows[i + 1]["Descripe"].ToString();
                            string add2 = "--防区>" + add;

                            TreeNode node2 = new TreeNode(str2);
                            node2.Text = str22;
                            node2.Name = str2;
                            TreeNode node3 = new TreeNode();
                            node3.Text = des2;
                            node3.Name = des;
                            TreeNode node4 = new TreeNode();
                            node4.Text = add2;
                            node4.Name = add;

                            node.Nodes.Add(node2);
                            node2.Nodes.Add(node3);
                            node2.Nodes.Add(node4);

                            i++;
                        }


                        repeat = false;
                        break;
                    }
 
                }

                if (repeat)
                {
                    if (str3 == "0")
                    {
                        TreeNode node1 = new TreeNode();
                        node1.Text = str12;
                        node1.Name = str1;
                        TreeNode node2 = new TreeNode();
                        node2.Text = str22;
                        node2.Name = str2;
                        TreeNode node3 = new TreeNode();
                        node3.Text = des2;
                        node3.Name = des;


                        treeView.Nodes.Add(node1);
                        node1.Nodes.Add(node2);
                        node2.Nodes.Add(node3);
                    }
                    else
                    {
                        string add = tempdt.Rows[i + 1]["Descripe"].ToString();
                        string add2 = "--防区>" + add;

                        TreeNode node1 = new TreeNode(str1);
                        node1.Text = str12;
                        node1.Name = str1;
                        TreeNode node2 = new TreeNode(str2);
                        node2.Text = str22;
                        node2.Name = str2;
                        TreeNode node3 = new TreeNode();
                        node3.Text = des2;
                        node3.Name = des;
                        TreeNode node4 = new TreeNode();
                        node4.Text = add2;
                        node4.Name = add;

                        treeView.Nodes.Add(node1);
                        node1.Nodes.Add(node2);
                        node2.Nodes.Add(node3);
                        node2.Nodes.Add(node4);

                        i++;
                    }
                }


            }

            treeView.Nodes[0].Remove();
            treeView.ExpandAll();
        }


        private void quit()
        {
            foreach (Thread t in ThreadList)
            {
                t.Abort();
                ThreadList.Remove(t);
                break;
            }
            this.Dispose();
            this.Close();
        }

        

        private void but_StationSet_Click(object sender, EventArgs e)
        {
            FormStaSet formstaset = new FormStaSet();
            formstaset.StartPosition = FormStartPosition.CenterScreen;
            formstaset.Owner = this;
            formstaset.GetDatabaseData += GetOLEDBData;
            formstaset.LoadTreeView += Load_TreeView;
            formstaset.UpdateAlertArea += UpdateAlertArea;
            formstaset.ShowDialog();
        }





        private void but_AreaSet_Click(object sender, EventArgs e)
        {
            FormDenfenAreaSet defenceareaset = new FormDenfenAreaSet();
            defenceareaset.StartPosition = FormStartPosition.CenterScreen;
            defenceareaset.GetDatabaseData += GetOLEDBData;
            defenceareaset.LoadTreeView += Load_TreeView;
            defenceareaset.UpdateAlertArea += UpdateAlertArea;
            defenceareaset.ShowDialog();
        }



        
        int allOnCount = 2;
        private void but_AllOn_Click(object sender, EventArgs e)
        {
            timerGetInfo.Close();
            ProtocolCmd = 0;
            timerAllInfo.Start();
            Thread.Sleep(100);
            UpdateMsgTextBox("全局布防,成功");
            timerGetInfo.Start();
        }


        private void but_AllOff_Click(object sender, EventArgs e)
        {
            timerGetInfo.Close();
            ProtocolCmd = 1;
            timerAllInfo.Start();
            Thread.Sleep(100);
            UpdateMsgTextBox("全局撤防,成功");
            timerGetInfo.Start();
        }

        public void All_CMD(object source, System.Timers.ElapsedEventArgs e)
        {
            if (allOnCount-- == 0)
            { allOnCount = 2; timerAllInfo.Stop(); }
            else
            {
                
                for (int i=0;i<StaSetCount;i++)
                    btSend_Click(ProtocolData[ProtocolCmd],RemotePointArr[i]);
            }
        }
        private byte CrcCheck(byte[] data )
        {
            uint i, j;
            byte tem_data;

            tem_data = data[0];
            j = (uint)(data[3] - 1);

            for (i = 1; i < j; i++)
            {
                tem_data ^= data[i];
            }

            return tem_data;
        }

        private void but_AlertReset_Click(object sender, EventArgs e)
        {
            player.Stop();
            timeralerttwinkle.Stop();
            AlertReset();
            pictureBox_edit.Refresh();
            DisplayMapFun("",Color.Blue);
        }
        public void AlertClearFun(object source, System.Timers.ElapsedEventArgs e)
        {
            for(int i=0;i<LastAlertBuff.Count;i++)
                LastAlertBuff[RemotePointArr[i].ToString()] = 0;
        }






        public string getIPAddress()
        {
            // 获得本机局域网IP地址  
            AddressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;

            if (AddressList.Length < 1)
            {
                return "";
            }
            return AddressList[0].ToString();
        }

        public int getValidPort(string port)
        {
            int lport;
            //测试端口号是否有效  
            try
            {
                //是否为空  
                if (port == "" || Convert.ToInt32(port)>65535)
                {
                    throw new ArgumentException("端口号无效，不能启动UDP");
                }
                lport = System.Convert.ToInt32(port);
            }
            catch (Exception e)
            {
                this.tbMsg.AppendText("无效的端口号：" + e.ToString() + "\n");
                return -1;
            }
            return lport;
        }


        public IPAddress getValidIP(string ip)
        {
            IPAddress lip = null;
            //测试IP是否有效  
            try
            {
                //是否为空  
                if (!IPAddress.TryParse(ip, out lip))
                {
                    throw new ArgumentException("IP无效，不能启动UDP");
                }
            }
            catch (Exception e)
            {
                this.tbMsg.AppendText("无效的IP：" + e.ToString() + "\n");
                return null;
            }
            return lip;
        }

        List<Thread> ThreadList = new List<Thread>();
        public void socket_config(string clientIP,string clientPort,int cou)
        {
            //得到本机IP，设置UDP端口号     
            if ( getValidIP(clientIP) !=null && getValidPort(clientPort) !=-1 )
            {
                //得到客户机IP  
                IPAddress ip = getValidIP(clientIP);
                int port = getValidPort(clientPort);
                IPEndPoint ipep = new IPEndPoint(ip, port);
                RemotePoint = (EndPoint)(ipep);
                //将所有设备存入字典
                RemotePointArr[cou] = RemotePoint;
                //防止报警时重复触发而程序崩溃
                LastAlertBuff[RemotePoint.ToString()] = 0;

                //启动一个新的线程，执行方法this.ReceiveHandle，  
                //以便在一个独立的进程中执行数据接收的操作  

                Thread thread = new Thread(new ThreadStart(this.ReceiveHandle));
                thread.IsBackground = true;
                thread.Start();
                ThreadList.Add(thread);
            }
        }

        //定义一个委托  
        public delegate void MyInvoke(string strRecv);
        private void ReceiveHandle()
        {
            //接收数据处理线程  
            byte[] data = new byte[1024];
            MyInvoke myI = new MyInvoke(UpdateMsgTextBox);
            while (true)
            {
                if (mySocket == null || mySocket.Available < 1)
                {
                    Thread.Sleep(200);
                    continue;
                }
                //跨线程调用控件  
                //接收UDP数据报，引用参数RemotePoint获得源地址  
                int rlen=0;
                try
                {
                    rlen = mySocket.ReceiveFrom(data, ref RemotePoint);
                }
                catch{; }
                
                if (data[0] == 0xAA && data[1]==0xF8)
                { 
                    string hex = "";
                    for (int i = 0; i < rlen; i++)
                    {
                        hex += String.Format("{00:X}", data[i]) + " ";
                    }

                    if (rlen == 9)
                    {
                        EndPoint RmtPt = RemotePoint;
                        string ip = RmtPt.ToString();
                        string num = data[2].ToString();
                        TreeNode tn = null;
                                              
                        try { tn = treeView.Nodes.Find(ip, false)[0].Nodes.Find(num, false)[0];  }
                        catch {; }    
                        
                                       
                        if (tn != null)
                        {
                            //*****************************************************************************************//
                            //*****************************************************************************************//
                            string newNodeText = "";
                            string vol = data[7].ToString();

                            if ((data[4]&0x0F)==0x01)
                            {
                                if ((data[5] & 0x10) == 0x10)
                                    newNodeText = "布防-" + tn.Text.Split('-')[1] + "---" + vol + ".6KV";
                                else
                                    newNodeText = "撤防-" + tn.Text.Split('-')[1] + "---0KV";
                            }
                            else
                            {
                                if ((data[5] & 0x10) == 0x10)
                                {
                                    newNodeText = "布防-" + tn.Text.Split('-')[1];
                                }
                                else
                                {
                                    newNodeText = "撤防-" + tn.Text.Split('-')[1];
                                }
                                    
                            }
                            if (tn.Text != newNodeText) tn.Text = newNodeText;
                            /////////////////////////////////////////////////////////////////////////////////////////////


                            //*****************************************************************************************//
                            //*****************************************************************************************//
                            if ((data[6]&0x07)<=4 && ((data[6]>>3) & 0x07) <= 4 && data[6]!=0 && data[6]!= LastAlertBuff[RmtPt.ToString()])
                            {
                                string AlertType = "";
                                string[] AlertContent = new string[8] { "防区1短路报警", "防区1断路报警","防区1触摸报警",
                                                                        "防区2短路报警", "防区2断路报警","防区2触摸报警",
                                                                        "防区1报警","防区2报警",
                                                                        };

                                LastAlertBuff[RmtPt.ToString()] = data[6];

                                if ((data[5] & 0x04) == 0x04)
                                {
                                    AlertType += "已开箱, ";
                                }
                                for(int i=0;i<8;i++)
                                {
                                    if ((data[6] & (1<<i)) == (1<<i))
                                        AlertType += AlertContent[i]+", ";
                                }

                                string s1 = RmtPt.ToString();
                                string s2 = data[2].ToString();
                                string s3 = AlertType.Remove(AlertType.LastIndexOf(","), 1);
                                string s = s1 + " " + s2 + " " + s3;
                                

                                string re1 = " ";
                                string re2 = " ";

                                if ((data[6] & 0xB8) != 0 && 
                                    (data[6] & 0x47) != 0 && (
                                    tn.FirstNode.BackColor != Color.Red || 
                                    tn.FirstNode.NextNode.BackColor != Color.Red)
                                    )
                                {
                                    myAlert(tn.FirstNode,re1);
                                    myAlert(tn.FirstNode.NextNode, re2);
                                    AlertUpdate(s1, s2, s3, 3);
                                    AlertSendData(s1, s2, "1");
                                    AlertSendData(s1, s2, "2");
                                }
                                if ((data[6] & 0x47) != 0  && tn.FirstNode.BackColor != Color.Red)
                                {
                                    myAlert(tn.FirstNode, re1);
                                    AlertUpdate(s1, s2, s3, 1);
                                    AlertSendData(s1, s2, "1");
                                }
                                if((data[6] & 0xB8) != 0 && tn.FirstNode.NextNode.BackColor != Color.Red)
                                {
                                    myAlert(tn.FirstNode.NextNode, re2);
                                    AlertUpdate(s1, s2, s3, 2);
                                    AlertSendData(s1, s2, "2");
                                }
                                //打印log信息
                                UpdateMsgTextBox(s);
                                //警报声音开启
                                timeralerttwinkle.Start();
                                player.PlayLooping();
                            }
                            else if (data[6] == 0)
                            {; }
                            /////////////////////////////////////////////////////////////////////////////////////////////


                        }
                    }
                    else if (rlen == 6 && SetAreaNum)
                    {
                        SetAreaNum = false;
                        MessageBox.Show(RemotePoint.ToString() + " 设置成为 " + data[4].ToString(), "主机地址设置成功");
                    }
                    else if (rlen == 7 && alertSendFlag)
                    {
                        alertSendFlag = false;
                        UpdateMsgTextBox("联动警报已发送");
                    }

                }
            }


        }

        delegate void alertSendData(byte[] data,string str);
        bool alertSendFlag = false;
        void AlertSendData(string ipport,string num,string area)
        {
            timerGetInfo.Close();
            Thread.Sleep(100);
            string ipPortNodes = "";
            try
            {
                ipPortNodes = LinkageBuff[ipport + "-" + num + "-" + area];
                string destination = ipPortNodes.Split('-')[0];
                string node = ipPortNodes.Split('-')[1];
                string[] nodes = node.Split(',');
                alertSendData mySendData = null;
                if (destination.Length < 8)
                {
                    mySendData = new alertSendData(SerialSendData);
                }
                else
                {
                    mySendData = new alertSendData(UDPSendData);
                }

                byte[] data = new byte[7];
                data[0] = 0xAA; data[1] = 0xAF; data[2] = 0xF8; data[3] = 0x07; data[6] = 0x00;
                for (int i = 0; i < nodes.Length; i++)
                {
                    data[4] = (byte)((Convert.ToByte(nodes[i])-1) / 16);
                    data[5] = (byte)(((Convert.ToByte(nodes[i]) - 1) % 16) + 1);
                    mySendData(data, destination);
                }
                alertSendFlag = true;
            }
            catch
            {
                ipPortNodes = "null";
            }
            timerGetInfo.Start();

        }
        void myAlert(TreeNode tn,string str)
        {
            if (tn!=null)
            {
                str = tn.Text + "  ";
                tn.Text = str.Split(' ')[0] + "                   --警报";
                tn.BackColor = Color.Red;
            }
            
        }

        private void btSend_Click(byte[] data,EndPoint RemotePoint)
        {
            SendData(data, RemotePoint);
        }
        public void SendData(byte[] data, EndPoint RemotePoint)
        {
            if (RemotePoint != null)
            {            
                data[data.Length-1] = CrcCheck(data);
                mySocket.SendTo(data, data.Length, SocketFlags.None, RemotePoint);
            }
        }
        public void SerialSendData(byte[] data,string comn)
        {
            SerialPort port = new SerialPort(comn, 4800, Parity.Even, 8, StopBits.One);
            try
            {
                port.Open();
                data[data.Length - 1] = CrcCheck(data);
                string msg = "";
                for (int i = 0; i < data.Length; i++) { msg += data[i].ToString("x") + " "; }
                UpdateMsgTextBox(msg);
                UpdateMsgTextBox(comn.ToString());
                port.Write(data,0,data.Length);
                port.Close();
            }
            catch {UpdateMsgTextBox("串口错误"); }
        }
        public void UDPSendData(byte[] data, string ipport)
        {
            try
            {
                IPAddress ip = getValidIP(ipport.Split(':')[0]);
                int port = getValidPort(ipport.Split(':')[1]);
                EndPoint ipep = (EndPoint)(new IPEndPoint(ip, port));
                string msg = "";
                for (int i = 0; i < data.Length; i++) { msg += data[i].ToString("x") + " "; }
                UpdateMsgTextBox(msg);
                UpdateMsgTextBox(ipep.ToString());
                SendData(data, ipep);
            }
            catch { UpdateMsgTextBox("IP/端口错误"); }
        }


        private void btnDataBegin_Click(object sender, EventArgs e)
        {
            DataBeginFun();
        }
        private void  DataBeginFun()
        {
            timerGetInfo.Close();

            foreach (Thread t in ThreadList)
            {
                t.Abort();
                ThreadList.Remove(t);
                break;
            }
            
            if (mySocket == null)
            {
                //得到本机IP，设置UDP端口号     
                IPAddress ip = getValidIP(localIP.ToString());
                int port = getValidPort(localPort.ToString());
                ipLocalPoint = new IPEndPoint(ip, port);
                //定义网络类型，数据连接类型和网络协议UDP  
                mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //绑定网络地址
                mySocket.Bind(ipLocalPoint);
 
            }
            else
            {
                if (mySocket.Connected)
                    mySocket.Disconnect(true);
                IPAddress ip = getValidIP(localIP.ToString());
                int port = getValidPort(localPort.ToString());
                ipLocalPoint = new IPEndPoint(ip, port);
                if (ipLocalPoint.ToString() != mySocket.LocalEndPoint.ToString())
                {
                    EndPoint last = mySocket.LocalEndPoint;
                    mySocket.Close();
                    mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    try { mySocket.Bind(ipLocalPoint); }
                    catch { try { mySocket.Bind(last); } catch {; } MessageBox.Show("端口设置有误","更新失败"); }
                }  
            }
            UpdateMsgTextBox("监听地址<-->" + mySocket.LocalEndPoint);


            GetOLEDBData();

            
            string DesDev = "";
            for (int i = 0; i < StaSetCount; i++)
            {
                DesDev += StaSetData[i, 0] + ":" + StaSetData[i, 1]+" ";
                socket_config(StaSetData[i, 0], StaSetData[i, 1], i);
            }
            UpdateMsgTextBox("目标设备<-->\r\n"+DesDev.Trim().Replace(' ','&'));
            timerGetInfo.Start();
            UpdateMsgTextBox(StaSetCount + " 台设备开始等待数据......");
        }
        private void btnCleartxt_Click(object sender, EventArgs e)
        {
            this.tbMsg.Clear();
        }

        private void 单个布防ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleSet singleset = new SingleSet();
            singleset.StartPosition = FormStartPosition.CenterScreen;
            singleset.SendData += SendData;
            singleset.ShowDialog();
        }
        private void 操作员设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSet userset = new UserSet();
            userset.StartPosition = FormStartPosition.CenterScreen;
            userset.ShowDialog();
        }
        private void 报警声音设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMusic formmusic = new FormMusic();
            formmusic.StartPosition = FormStartPosition.CenterScreen;
            formmusic.ShowDialog();
        }
        double fabs(double num)
        {
            return num > 0 ? num : -num;
        }
        private void DayNightStop()
        {
            daynightswitch.Stop();
        }
        private void DayNightSwitchFun(object source, System.Timers.ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime Now = new DateTime(2000,1,1,now.Hour,now.Minute,0);
            foreach (var DayNight in DayNightBuff)
            {
                if (fabs((DayNight.Value.Day - Now).TotalMilliseconds) < 60 * 1000)
                {
                    Console.WriteLine("Sent Data ->" + DayNight.Value.DayVol.ToString() + "Kv of " + DayNight.Key.ToString());
                    DayNightSendFun(DayNight.Key, (byte)DayNight.Value.DayVol);
                }
                else if (fabs((DayNight.Value.Night - Now).TotalMilliseconds) < 60 * 1000)
                {
                    Console.WriteLine("Sent Data ->" + DayNight.Value.NightVol.ToString() + "Kv of " + DayNight.Key.ToString());
                    DayNightSendFun(DayNight.Key, (byte)DayNight.Value.NightVol);
                }
                
                
            }
        }
        private void DayNightSendFun(string str,byte vol)
        {
            string temp0 = str.Split(',')[0];
            string temp1 = str.Split(',')[1];
            IPAddress IPadr = IPAddress.Parse(temp0.Split(':')[0]);
            IPEndPoint EndPoint = new IPEndPoint(IPadr, int.Parse(temp0.Split(':')[1]));

            byte[] data = new byte[7];
            data[0] = 0xAA;
            data[1] = Convert.ToByte(temp1);
            data[2] = 0xF8;
            data[3] = 0x07;
            data[4] = 0x0D;
            data[5] = vol;
            data[6] = 0;
            SendData(data, EndPoint);
            SendData(data, EndPoint);
        }
        static public int Num_Node_Vol_CMD = -1;
        private void 修改名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Num_Node_Vol_CMD == -1)
            {
                Num_Node_Vol_CMD = 0;
                Num_Node_Vol_SET();
            }
        }
        private void 修改地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Num_Node_Vol_CMD == -1)
            {
                Num_Node_Vol_CMD = 1;
                Num_Node_Vol_SET();
            }    
        }

        private void 统一工作电压ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Num_Node_Vol_CMD == -1)
            {
                Num_Node_Vol_CMD = 2;
                Num_Node_Vol_SET();
            }
        }
        private void Num_Node_Vol_SET()
        {
            EditNodeName editnodename = new EditNodeName();
            editnodename.StartPosition = FormStartPosition.CenterScreen;
            editnodename.LoadTreeView += Load_TreeView;
            editnodename.SendNumData += SendData;
            editnodename.thisMapNodeName += thisMapNodeName;
            editnodename.ShowDialog();
        }
        private void thisMapNodeName(string name)
        {
            string s1 = lb_thismap.Text.Split('-')[0];
            string s2 = lb_thismap.Text.Split('-')[1];
            this.lb_thismap.Text = s1.Split(',')[0] + "," + s1.Split(',')[1] + "," + name + "-" + s2;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutCMS aboutcms = new AboutCMS();
            aboutcms.StartPosition = FormStartPosition.CenterScreen;
            aboutcms.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quit();
        }
        private void 系统设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SystemConfig systemConfig = new SystemConfig();
            systemConfig.StartPosition = FormStartPosition.CenterScreen;
            systemConfig.UpdateMsgTextBox += UpdateMsgTextBox;
            systemConfig.ShowDialog();
        }
        private void 网络转化器设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Setting.exe");

        }



        private void 系统地图设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapSet();
        }
        private void but_MapSet_Click(object sender, EventArgs e)
        {
            MapSet();
        }

        private void MapSet()
        {
            FormDigitalMap digitalmap = new FormDigitalMap();
            digitalmap.StartPosition = FormStartPosition.CenterScreen;
            digitalmap.ChangeMapPath += ChangeMapLocation;
            digitalmap.ShowDialog();
        }

        private void 报警复位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlertReset();
        }

        static public int LinkageSelect = -1;
        private void 电子地图复位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DigitalMapReset();
        }
        private void but_MapReset_Click(object sender, EventArgs e)
        {
            DigitalMapReset();
        }
        public void DigitalMapReset()
        {
            foreach (var v in StaBuff)
            {
                byte[] data = new byte[6];
                data[0] = 0xAA; data[1] = 0xFF; data[2] = 0xF8; data[3] = 0x06; data[4] = 0x00; data[5] = 0x00;
                UDPSendData(data,v.Key);
            }

            foreach (var k in LinkageBuff)
            {
                string destination = k.Value.Split('-')[0];
                alertSendData mySendData = null;
                if (destination.Length < 8)
                {
                    mySendData = new alertSendData(SerialSendData);
                }
                else
                {
                    mySendData = new alertSendData(UDPSendData);
                }

                byte[] data = new byte[6];
                data[0] = 0xAA; data[1] = 0xFF; data[2] = 0xF8; data[3] = 0x06; data[4] = 0x00; data[5] = 0x00;
                mySendData(data, destination);
            }
            UpdateMsgTextBox("联动及电子地图复位成功");
        }
        private void but_LinkageSet_Click(object sender, EventArgs e)
        {
            if (LinkageSelect == -1)
            {
                LinkageSelect = 1;
                LinkageSet();
            }
        }
        private void 联动设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LinkageSelect == -1)
            {
                LinkageSelect = 1;
                LinkageSet();
            }
        }



        private void LinkageSet()
        {
            FormLinkage linkage = new FormLinkage();
            linkage.StartPosition = FormStartPosition.CenterScreen;
            linkage.ShowDialog();
        }

        private void AlertReset()
        {
            foreach (TreeNode n1 in treeView.Nodes)
            {
                foreach (TreeNode n2 in n1.Nodes)
                {
                    foreach (TreeNode n3 in n2.Nodes)
                    {
                        if (n3.BackColor == Color.Red)
                        {
                            n3.BackColor = Color.White;
                            n3.Text = n3.Text.Split(' ')[0];
                        }
                    }
                    
                }
            }
            UpdateMsgTextBox("报警复位,成功");
        }

        private void GetOLEDBData()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            string sql = "select IPandPort,IP,Port,StaName from tb_StaSet";
            DataTable tempdt = new DataTable();
            OleDbDataAdapter tempda = new OleDbDataAdapter(sql, conn);
            tempda.Fill(tempdt);
            StaSetCount = 0;
            for (int i = 0; i < tempdt.Rows.Count; i++)
            {
                StaSetData[StaSetCount, 0] = tempdt.Rows[i]["IP"].ToString();
                StaSetData[StaSetCount, 1] = tempdt.Rows[i]["Port"].ToString();
                StaBuff[tempdt.Rows[i]["IPandPort"].ToString().Trim()] = tempdt.Rows[i]["StaName"].ToString();
                IPBuff[tempdt.Rows[i]["StaName"].ToString()] = tempdt.Rows[i]["IPandPort"].ToString();
                StaSetCount++;
            }


            sql = "select IPandPort,AreaNum,Descripe,Map from tb_AreaSet";
            tempdt = new DataTable();
            tempda = new OleDbDataAdapter(sql, conn);
            tempda.Fill(tempdt);
            AreaSetCount = 0;
            for (int i = 0; i < tempdt.Rows.Count; i++)
            {
                string str1 = tempdt.Rows[i]["IPandPort"].ToString();
                string str2 = tempdt.Rows[i]["AreaNum"].ToString();
                string temp = tempdt.Rows[i]["Map"].ToString();
                if (temp.Split('-')[1] == "0") temp = temp.Split('-')[0] + "-1";
                ContentBuff[temp] = tempdt.Rows[i]["Descripe"].ToString();

                if ((i==0)||(i!=0 && str2!= AreaSetData[AreaSetCount-1, 1]))
                {
                    AreaSetData[AreaSetCount, 0] = str1;
                    AreaSetData[AreaSetCount, 1] = str2;
                    AreaSetCount++;
                }
            }

            sql = "select IpPortNum,Status from tb_DayNightAlert";
            tempdt = new DataTable();
            tempda = new OleDbDataAdapter(sql, conn);
            tempda.Fill(tempdt);
            for (int i = 0; i < tempdt.Rows.Count; i++)
            {
                string str = tempdt.Rows[i]["Status"].ToString(), dt0, dt1;
                dt0 = "20000101" + str.Split('-')[0].Remove(2, 1) + "00";
                dt1 = "20000101" + str.Split('-')[2].Remove(2, 1) + "00";
                DateTime day = DateTime.ParseExact(dt0, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                DateTime night = DateTime.ParseExact(dt1, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                int dayvol = Convert.ToInt16( str.Split('-')[1]);
                int nightvol = Convert.ToInt16(str.Split('-')[3]);

                DayNightBuff[tempdt.Rows[i]["IpPortNum"].ToString()] = new FormMain.DayNightBuffCLS(day, night, dayvol, nightvol);
            }

            sql = "select LinkInfo,IpPortNodes from tb_LinkageAlert";
            tempdt = new DataTable();
            tempda = new OleDbDataAdapter(sql, conn);
            tempda.Fill(tempdt);
            for (int i = 0; i < tempdt.Rows.Count; i++)
            {
                LinkageBuff[tempdt.Rows[i]["LinkInfo"].ToString()] = tempdt.Rows[i]["IpPortNodes"].ToString();
            }

            PortName = SerialPort.GetPortNames();           
        }

        private void 处理警报ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView.SelectedNode;
            string opr = "admin";
            if (tn.BackColor == Color.Red || true)
            {
                tn.BackColor = Color.White;
                tn.Text = tn.Text.Split(' ')[0];
                string s = CurrentNode;
                string s1=s.Split(',')[0], s2 = s.Split(',')[1], s3 = s.Split(',')[2];
                if (conn.State == ConnectionState.Closed) conn.Open();
                string sql = "";
                sql += " update tb_Content set OperationResult = '已处理'";
                sql += " Where StationIP = '" + s1 + "'";
                sql += " and AreaNum = '" + s2 + "'"; ;
                sql += " and Descripe like '%" + s3 + "%'";
                OleDbCommand comm = new OleDbCommand(sql, conn);
                comm.ExecuteNonQuery();

                sql = "";
                sql += " update tb_Content set";
                sql += " Operator = '" + opr + "'";
                sql += " Where StationIP = '" + s1 + "'";
                sql += " and AreaNum = '" + s2 + "'"; ;
                sql += " and Descripe like '%" + s3 + "%'";
                comm = new OleDbCommand(sql, conn);
                comm.ExecuteNonQuery();
            }
        }

        private string[] AlertInfoBuff = new string[7] { "NowDate", "NowTime", "StationIP","StationName", "AreaNum", "AlertType", "Descripe" };
        private void AlertInfo()
        {
            dataGridView.Columns.Add("NowDate", "日期");
            dataGridView.Columns.Add("NowTime", "时间");
            dataGridView.Columns.Add("StationIP", "基站IP");
            dataGridView.Columns.Add("StationName", "基站名称");
            dataGridView.Columns.Add("AreaNum", "防区地址");
            dataGridView.Columns.Add("AlertType", "报警类型");
            dataGridView.Columns.Add("Descripe", "地理位置");

            dataGridView.Rows.Add(); dataGridView.Rows.Add();
            dataGridView.Rows.Add(); dataGridView.Rows.Add();
        }
        private void AlertUpdate(string StaIP,string AreaNum,string AlertType,int DouSin)
        {
            string datetime = DateTime.Now.ToString();
            string[] alertinfobuff = new string[7];
            alertinfobuff[0] = datetime.Split(' ')[0];
            alertinfobuff[1] = datetime.Split(' ')[1];
            alertinfobuff[2] = StaIP;
            alertinfobuff[3] = StaBuff[StaIP];
            alertinfobuff[4] = AreaNum;
            alertinfobuff[5] = AlertType;
            if (DouSin == 3)
            {
                alertinfobuff[6] = ContentBuff[StaIP + "," + AreaNum.ToString() + "-" + 1.ToString()];
                alertinfobuff[6] += "," + ContentBuff[StaIP + "," + AreaNum.ToString() + "-" + 2.ToString()];
            }
            else
            {
                alertinfobuff[6] = ContentBuff[StaIP + "," + AreaNum.ToString() + "-" + DouSin.ToString()];
            }
            
            string cmd = "insert into tb_Content (NowDate,NowTime,StationIP,StationName,AreaNum,"+
                "AlertType,Descripe,OperationInfo,Operator,OperationResult) values(";          
            for (int i = 0; i < AlertInfoBuff.Length; i++)
                cmd += "'" + alertinfobuff[i] + "',";
            cmd += "'" + "无" + "',";
            cmd += "'" + "无" + "',";
            cmd += "'" + "无" + "'";
            cmd += ")";

            OleDbCommand comm = new OleDbCommand(cmd, conn);
            try { comm.ExecuteNonQuery(); }
            catch {; }

            for(int i = 3; i > 0; i--)
            {
                for(int j=0;j< AlertInfoBuff.Length;j++)
                    dataGridView.Rows[i].Cells[AlertInfoBuff[j]].Value = dataGridView.Rows[i-1].Cells[AlertInfoBuff[j]].Value;

            }
            for (int i = 0; i < AlertInfoBuff.Length; i++)
                dataGridView.Rows[0].Cells[AlertInfoBuff[i]].Value = alertinfobuff[i];

        }
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str = mySearchNode();
            if (str != " ") {
                str = str.Replace(' ', ',');
                CurrentNode = str;
                lb_thismap.Text = str + "-防区图";
                this.lb_thismap.ForeColor = Color.Black;
                drawing = false;
                DisplayMapFun(str,Color.Blue);
                SaveMap.Clear();
            }            
        }

        
        private void DisplayMapFun(string str,Color cl)
        {          
            if(AreaMapDT!=null)
            {
                DataTable tempdt = AreaMapDT;

                if (tempdt.Rows.Count != 0)
                {
                    Dictionary<int, Dictionary<int, Point>> PointBuff = new Dictionary<int, Dictionary<int, Point>>();
                    int AreaCount = 0;
                    int PointCount = 0;
                    string last = tempdt.Rows[0]["MapInfo"].ToString();
                    PointBuff.Add(AreaCount, new Dictionary<int, Point>());
                    for (int i = 0; i < tempdt.Rows.Count; i++)
                    {
                        if (tempdt.Rows[i]["MapInfo"].ToString() == last)
                        {
                            Point p = new Point((int)tempdt.Rows[i]["PointX"], (int)tempdt.Rows[i]["PointY"]);
                            PointBuff[AreaCount][PointCount++] = p;
                        }

                        else
                        {
                            PointCount = 0;
                            last = tempdt.Rows[i]["MapInfo"].ToString();
                            PointBuff.Add(++AreaCount, new Dictionary<int, Point>());
                            PointBuff[AreaCount][PointCount++] = new Point((int)tempdt.Rows[i]["PointX"], (int)tempdt.Rows[i]["PointY"]);
                        }
                    }

                    int index = 0;
                    for (int i = 0; i < AreaCount + 1; i++)
                    {
                        index += PointBuff[i].Count;
                        string strcmp = tempdt.Rows[index - 1]["MapInfo"].ToString();
                        TreeNode tn = treeView.Nodes.Find(strcmp.Split(',')[0], false)[0].Nodes.Find(strcmp.Split(',')[1], false)[0];
                        tn = tn.FirstNode.Name.Trim() == strcmp.Split(',')[2].Trim() ? tn.FirstNode : tn.FirstNode.NextNode;
                        //画一个区域的防区折线
                        for (int j = 0; j < PointBuff[i].Count - 1; j++)
                        {
                            if (str.Trim() == strcmp.Trim())
                            {
                                g.DrawLine(new Pen(Color.DarkRed, (float)2.5), PointBuff[i][j], PointBuff[i][j+1]);
                            }
                            else if (tn.BackColor == Color.Red)
                            {
                                g.DrawLine(new Pen(cl, 4), PointBuff[i][j], PointBuff[i][j + 1]);
                            }
                            else
                            {
                                g.DrawLine(new Pen(Color.Blue, (float)2.5), PointBuff[i][j], PointBuff[i][j + 1]);
                            }
                        } 
                        //一个区域的结束
                    }

                }
            }
 
        }
        private void 保存toolStripMenuItem_Click(object sender, EventArgs e)
        {
            pLast.X = 0; pLast.Y = 0;
            drawing = false;
            this.lb_thismap.Text = this.lb_thismap.Text.Split('-')[0] + "-防区图";
            this.lb_thismap.ForeColor = Color.Black;
            for (int i = 0; i < SaveMap.Count; i++)
            {
                string cmd = "insert into tb_Map (PointX,PointY,MapInfo) values(";
                cmd += "'" + SaveMap[i].Split(',')[0] + "',";
                cmd += "'" + SaveMap[i].Split(',')[1] + "',";
                cmd += "'" + lb_thismap.Text.Split('-')[0] + "'";
                cmd += ")";
                OleDbCommand comm = new OleDbCommand(cmd, conn);
                comm.ExecuteNonQuery();
            }

            UpdateAlertArea("");
            SaveMap.Clear();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            string cmd = "delete * from tb_Map where MapInfo = '" + lb_thismap.Text.Split('-')[0] + "'";
            OleDbCommand comm = new OleDbCommand(cmd, conn);
            comm.ExecuteNonQuery();

            UpdateAlertArea("dele");
            DisplayMapFun("", Color.Blue);
        }

        static public bool AlertTK = true;
        private void AlertTwinkel(object source, System.Timers.ElapsedEventArgs e)
        {
            if (AlertTK == false) {AlertTK = true; DisplayMapFun("", Color.Blue); }
            else {AlertTK = false; DisplayMapFun("", Color.Red); }
        }
        public string mySearchNode()
        {
            TreeNode test = treeView.SelectedNode;
            string str = "";
            string[] strarr = new string[3];
            int count = 0;
            while (test != null) { strarr[2 - count] += test.Name; test = test.Parent; count++; }
            if (count == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    str += " " + strarr[i];
                }
                str = str.Trim();
            }
            else
            {
                str = " ";
            }

            return str;
        }


        public void UpdateMsgTextBox(string msg)
        {
            //接收数据显示  
            this.tbMsg.AppendText(msg + "\r\n");
        }

        private void 报警信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlertSearchFun();
        }
        private void AlertSearchFun()
        {
            AlertSearch alertsearch = new AlertSearch();
            alertsearch.StartPosition = FormStartPosition.CenterScreen;
            alertsearch.ShowDialog();
        }
        public void FunGetInfo(object source, System.Timers.ElapsedEventArgs e)
        {
            if (AreaSetCount > 0)
            {
                if (FunGetInfoCount >= AreaSetCount) FunGetInfoCount = 0;
                string str1 = AreaSetData[FunGetInfoCount, 0];
                string str2 = AreaSetData[FunGetInfoCount, 1];
                FunGetInfoCount++;

                IPAddress ip = getValidIP(str1.Split(':')[0]);
                int port = getValidPort(str1.Split(':')[1]);
                IPEndPoint thisEndPoint = new IPEndPoint(ip, port);

                byte[] thisData = new byte[7];
                thisData[0] = 0xAA;
                thisData[1] = Convert.ToByte(str2);
                thisData[2] = 0xF8;
                thisData[3] = 0x07;
                thisData[4] = 0x02;
                thisData[5] = 0x00;
                thisData[6] = 0x00;

                SendData(thisData, thisEndPoint);
            }
        }
        private Point pLast = new Point(0, 0);//定义点
        private static bool drawing = false;//设置一个启动标志
        private static bool moving = false;//设置一个启动标志
        Graphics g = null;


        private void 绘制防区图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lb_thismap.Text = this.lb_thismap.Text.Split('-')[0] + "-编辑模式";
            this.lb_thismap.ForeColor = Color.Red;
            drawing = true;
        }

        private void pictureBox_edit_MouseDown(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void pictureBox_edit_MouseUp(object sender, MouseEventArgs e)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//消除锯齿

            if (drawing && e.Button==MouseButtons.Left)
            {
                if (!(pLast.X==0&&pLast.Y==0))
                {
                    Point currentPoint = new Point(e.X, e.Y);
                    g.DrawLine(new Pen(Color.Blue, 2), pLast, currentPoint);
                    pLast = new Point(e.X, e.Y);
                    SaveMap.Add(pLast.X.ToString() + "," + pLast.Y.ToString());
                }
                else
                {
                    pLast = new Point(e.X, e.Y);
                    SaveMap.Add(pLast.X.ToString() + "," + pLast.Y.ToString());
                }
                moving = true;
            }
            
        }

        private void pictureBox_edit_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing && moving)
            {
                MoveRefresh();
                Point currentPoint = new Point(e.X, e.Y);
                g.DrawLine(new Pen(Color.Blue, 2), pLast, currentPoint);

            }
        }
        private void MoveRefresh()
        {
            this.pictureBox_edit.Refresh();
            DisplayMapFun("", Color.Blue);
            for (int j = 0; j < SaveMap.Count - 1; j++)
            {
                Point p1 = new Point(Convert.ToInt16(SaveMap[j].Split(',')[0]), Convert.ToInt16(SaveMap[j].Split(',')[1]));
                Point p2 = new Point(Convert.ToInt16(SaveMap[j+1].Split(',')[0]), Convert.ToInt16(SaveMap[j+1].Split(',')[1]));
                g.DrawLine(new Pen(Color.Blue, (float)2), p1,p2);
            }
        }

        public void ChangeMapLocation(string path)
        {
            this.pictureBox_Map.ImageLocation = path;
            this.pictureBox_Map.Refresh();
        }
        private void GetMapImage()
        {
            this.pictureBox_Map.ImageLocation = "map.jpg";
            player.SoundLocation = "alert.wav";
        }
        
        private void InitAlertArea()
        {
            UpdateAlertArea("");
        }

        private void UpdateAlertArea(string str)
        {
            if (str == "dele" || true) {
                this.pictureBox_edit.Refresh();
                relaodflag = false;
            }

            if (conn.State == ConnectionState.Closed) conn.Open();
            string sql = "select PointX,PointY,MapInfo from tb_Map order by id asc";
            AreaMapDT = new DataTable();
            AreaMapDA = new OleDbDataAdapter(sql, conn);
            AreaMapDA.Fill(AreaMapDT);       
            
            DisplayMapFun("",Color.Blue);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            quit();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            float[] scale = (float[])Tag;
            int i = 2;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.Left = (int)(Size.Width * scale[i++]);
                ctrl.Top = (int)(Size.Height * scale[i++]);
                ctrl.Width = (int)(Size.Width / (float)scale[0] * ((Size)ctrl.Tag).Width);
                ctrl.Height = (int)(Size.Height / (float)scale[1] * ((Size)ctrl.Tag).Height);

                //每次使用的都是最初始的控件大小，保证准确无误。
            }
        }

        private void 系统帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("help.doc");
        }


    }
}
