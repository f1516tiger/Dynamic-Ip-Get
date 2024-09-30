using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lib
{
    public class SocketControl
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="obj"></param>
        /// <param name=""></param>
        public ResponseModel SendMessage(object obj, MessageType command,string message)
        {


            Socket socket = (Socket)obj;

            Byte[] data = new byte[0];

            var stream = new NetworkStream(socket);

            string message2Code = JsonConvert.SerializeObject(new MessageModel()
            {
                MessageType = command,
                Message = message
            });
            data = Encoding.UTF8.GetBytes(message2Code);


            if (stream.CanWrite)
            {
                try
                {
                    stream.Write(data, 0, data.Length);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            ResponseModel modeldata;
            string dataString = "";
            byte[] recivedata = new byte[1024];
            if (stream.CanRead)
            {

                try
                {
                    int len = stream.Read(recivedata, 0, recivedata.Length);// socket.Receive(recivedata);
                    dataString = Encoding.UTF8.GetString(recivedata, 0, len);
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
            modeldata = JsonConvert.DeserializeObject<ResponseModel>(dataString);
            return modeldata;


            //Thread thread = new Thread(new ParameterizedThreadStart(ReceiveMessage));
            //thread.Start(socket);
        }

        /// <summary>
        /// 取得
        /// </summary>
        /// <param name="obj"></param>
        public string ReceiveMessage(object obj, bool encryption = false)
        {
            string dataString = "";
            Socket socket = (Socket)obj;
            var stream = new NetworkStream(socket);

            byte[] data = new byte[1024];


            //  int len = socket.Receive(data);
            try
            {
                if (stream.CanRead)
                {
                    int len = stream.Read(data, 0, data.Length);// socket.Receive(recivedata);

                    dataString = Encoding.UTF8.GetString(data, 0, len);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return dataString;
        }






    }
}
