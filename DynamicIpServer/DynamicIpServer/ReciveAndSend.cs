using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib;
using Newtonsoft.Json;

namespace DynamicIpServer
{
    public partial class ReciveAndSend : ServiceBase
    {
        private FileLogWriter _writer
        {
            get
            {
                if (_writerTmp==null)
                {
                    _writerTmp=new FileLogWriter();
                }
                return _writerTmp;
            }
        }
        private FileLogWriter _writerTmp;
        public ReciveAndSend()
        {
            InitializeComponent();
            base.ServiceName = "DynamicIpServer"; //设置服务名称，与后面的安装服务名称要一致 
        }

        protected override void OnStart(string[] args)
        {
            StartCommand();
        }

        protected override void OnShutdown()
        {
            StopCommand();
            base.OnShutdown();
        }

        protected override void OnStop()
        {
            StopCommand();
        }

        private void StopCommand()
        {
            _listenerStart = false;
            if (_socket != null)
            {
                _socket.Close();
                _socket.Dispose();
            }
            if (_thrListener != null && _thrListener.IsAlive)
            {
                _thrListener.Abort();
            }
            _serverstatus = false;
        }
        private void Recive(string message, NetworkStream stream)
        {
            IPAddress add;
            bool trans = IPAddress.TryParse(message, out add);
            if (!trans)
            {
                new FileLogWriter().Write("Error", "Ip接收", LogType.Error, "Ip不合法", message);
                return;
            }
            Config.SaveCompanyIp(message);
            new FileLogWriter().Write("Info", "Ip保存", LogType.Information, "Ip保存|"+ message, message);
            if (stream.CanWrite)
            {
                var res = new ResponseModel()
                {
                    ResponseType = ResponseType.成功,
                    ResponseMessage = ""
                };
                Byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res));
                if (stream.CanWrite)
                {
                    stream.Write(data, 0, data.Length);
                 
                }

            }
        }

        private void Send(NetworkStream stream)
        {
            if (stream.CanWrite)
            {
                var ip = Config.GetCompanyIp();
                var res = new ResponseModel()
                {
                    ResponseType = ResponseType.成功,
                    ResponseMessage = ip
                };
                Byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res));
                if (stream.CanWrite)
                {
                    stream.Write(data, 0, data.Length);
                    new FileLogWriter().Write("Info", "Ip发送", LogType.Information, "Ip发送|"+ ip, ip);
                }

            }
        }

        private string defaultserverip =  "0.0.0.0";//"192.168.31.111";
            //"120.25.82.119";
        private int _serverPort = 9528;
        private IPEndPoint _endPoint;
        private Socket _socket;
        /// <summary>
        /// 命令监听
        /// </summary>
        private Thread _thrListener;
        private bool _serverstatus = false;
        /// <summary>
        /// 命令监听状态
        /// </summary>
        private bool _listenerStart = true;
        /// <summary>
        /// 命令监听开始
        /// </summary>
        private void StartCommand()
        {
            var ip = Config.GetServerIp();
            if (string.IsNullOrEmpty(ip))
            {
                ip = defaultserverip;
            }
            IPAddress add;
            bool trans = IPAddress.TryParse(defaultserverip, out add);
            if (!trans)
            {
                new FileLogWriter().Write("Error", "启动监听", LogType.Error, "Ip不合法", ip);
                return;
            }
            var port= Config.GetServerPort();
            bool portSuccess = int.TryParse(port, out _serverPort);
            if (!portSuccess)
            {
                _writer.Write("Error", "启动监听", LogType.Error, "端口不合法", port);
                return;
            } 
            var serverip = add;
            _endPoint = new IPEndPoint(serverip, _serverPort);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {

                _socket.Bind(_endPoint);
                _socket.Listen(50);


                _thrListener = new Thread(ThreadListener);
                _thrListener.Start();
                _serverstatus = true;
                _listenerStart = true;
                _writer.Write("Info", "启动监听", LogType.Information, "启动监听", ip);

            }
            catch (Exception ex)
            {
                _writer.Write("Error", "启动监听", LogType.Error, "启动监听失败", ex.ToString()+"--------------------------"+ serverip+ _serverPort);
            }

        }
        byte[]        databuffer = new byte[1024];
        StringBuilder reciveMsg  = new StringBuilder();
        /// <summary>
        /// 等待开始课程线程
        /// </summary>
        private void ThreadListener()
        {
            string msg = "";

            while (_listenerStart)
            {
                //         if (socket.Available <= 0) continue; 5
                var accept = _socket.Accept();
                var stream = new NetworkStream(accept);

                if (!stream.CanRead) continue;

                try
                {
                    do
                    {

                        var bufferRead = stream.Read(databuffer, 0, databuffer.Length);
                        reciveMsg.Clear();
                        reciveMsg.AppendFormat("{0}", Encoding.UTF8.GetString(databuffer, 0, bufferRead));
                    } while (stream.DataAvailable);

                    msg = reciveMsg.ToString();
                    var command = JsonConvert.DeserializeObject<MessageModel>(msg);
                    var ip      = ((System.Net.IPEndPoint)accept.RemoteEndPoint).Address.ToString();
                    switch (command.MessageType)
                    {
                        case MessageType.传递Ip:
                            Recive(ip, stream);
                            break;
                        case MessageType.获取Ip:
                            Send(stream);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception e)
                {
                    _writer.Write("Error", "发送逻辑", LogType.Error, "发送逻辑失败", e.ToString());
                }
            
            }
        }
    }
}
