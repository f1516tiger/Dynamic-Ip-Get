using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using Lib;

namespace GetCompanyPublicIP
{
    public partial class Form_GetIp : Form
    {
        public Form_GetIp()
        {
            InitializeComponent();
            GetServerIp();
        }
        private string defaultserverip = "120.25.82.119";
        private IPAddress _serverIpAdd;
        private int _serverCommandPort = 9528;
        private Socket _socket;
        private SocketControl _socketControl;
        private void btn_GetIp_Click(object sender, EventArgs e)
        {
            textBox_IpShow.Text = "获取中...";
            btn_GetIp.Enabled=false;
            var ip =textBox_ServerIp.Text;
            if (string.IsNullOrWhiteSpace(ip))
            {
                ip = defaultserverip;

            }
            _serverIpAdd = IPAddress.Parse(ip);
            var portSuccess = int.TryParse(textBox_Port.Text, out _serverCommandPort);
            if (!portSuccess)
            {
                MessageBox.Show("端口不合法，应为1000-65536的数字");
                return;
            }

            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (!_socket.Connected)
                {
                    _socket.Connect(new IPEndPoint(_serverIpAdd, _serverCommandPort));
                }
                _socketControl = new SocketControl();
                var res = _socketControl.SendMessage(_socket, MessageType.获取Ip, "");
                textBox_IpShow.Text = res.ResponseMessage;
                new FileLogWriter().Write("连接", "取得IP", LogType.Information, "取得IP", res.ResponseType.ToString() + res.ResponseMessage);
                MessageBox.Show("获取成功！");
            }
            catch (Exception eg)
            {
                new FileLogWriter().Write("连接", "初始化连接", eg);
            }
            finally
            {
                _socket.Close();
                _socket.Dispose();
                btn_GetIp.Enabled = true;
            }
        }

        private void GetServerIp()
        {
            var ip = Config.GetServerIp();
            if (string.IsNullOrEmpty(ip))
            {
                textBox_ServerIp.Text = "未配置服务器Ip";
                return;
            }
            textBox_ServerIp.Text = ip;
            var port = Config.GetServerPort();
            if (string.IsNullOrEmpty(port))
            {
                textBox_Port.Text = "未配置服务器Port";
                return;
            }
            textBox_Port.Text = port;
        }

        private void btn_demoip_Click(object sender, EventArgs e)
        {
            textBox_ServerIp.Text = "118.24.42.217";
        }

        private void btn_SaveServerIp_Click(object sender, EventArgs e)
        {
            var ip   = textBox_ServerIp.Text;
            var port = textBox_Port.Text;
            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("请填写IP!");
                return;
            }
            IPAddress add = null;
            bool trans = IPAddress.TryParse(ip, out add);
            if (!trans)
            {
                MessageBox.Show("IP地址不合法!");
                return;
            }
            Config.SaveServerIp(ip, port);
            MessageBox.Show("服务器Ip保存成功!");
        }
    }
}
