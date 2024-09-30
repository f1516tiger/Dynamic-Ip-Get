using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
   public class MessageModel
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageType MessageType { get; set; }
        /// <summary>
        /// 公司Ip地址
        /// </summary>
        public string Message { get; set; }
    }

    public enum MessageType
    {
        传递Ip=0,
        获取Ip=1,
    }

    public enum ResponseType
    {
        成功=0,
        失败=1
    }
    public class ResponseModel
    {
    public ResponseType ResponseType { get; set; }
        public string ResponseMessage { get; set; }
    }
}
