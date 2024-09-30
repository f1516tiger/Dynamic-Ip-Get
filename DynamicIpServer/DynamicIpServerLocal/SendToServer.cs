using System;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Timers;
using Lib;

namespace DynamicIpServerLocal
{
    public partial class SendToServer : ServiceBase
    {
        private FileLogWriter _writer
        {
            get
            {
                if (_writerTmp == null)
                {
                    _writerTmp = new FileLogWriter();
                }
                return _writerTmp;
            }
        }
        private FileLogWriter _writerTmp;
        public SendToServer()
        {
            InitializeComponent();
            base.ServiceName = "SendToServer"; //设置服务名称，与后面的安装服务名称要一致 
        }

        private System.Timers.Timer timer;
        private SocketControl _socketControl;
        protected override void OnStart(string[] args)
        {
            SendIpToServer();
            timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 5 * 60 * 1000;// 720000; //5分钟  
            timer.AutoReset = true;

            timer.Elapsed += new System.Timers.ElapsedEventHandler(LinkToServer);
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
            timer.Dispose();
        }

        private IPAddress _serverIpAdd;
        private int _serverCommandPort = 9528;
        private Socket _socket;

        private void LinkToServer(object sender, ElapsedEventArgs elapsedEventArgs)
        {


            SendIpToServer();

        }

        private void SendIpToServer()
        {
            try
            {
                _serverIpAdd       = IPAddress.Parse(Config.GetServerIp()); //
                _serverCommandPort = int.Parse(Config.GetServerPort());
                _socket            = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (!_socket.Connected)
                {
                    _socket.Connect(new IPEndPoint(_serverIpAdd, _serverCommandPort));
                    _socketControl = new SocketControl();
                    var res = _socketControl.SendMessage(_socket, MessageType.传递Ip, "");
                    _writer.Write("连接", "发送IP", LogType.Information, "发送Ip", res.ResponseType.ToString() + res.ResponseMessage);

                }
            }
            catch (Exception e)
            {
                _writer.Write("连接", "初始化连接", e);
                _socket.Close();
                _socket.Dispose();
            }
        }
    }
}
