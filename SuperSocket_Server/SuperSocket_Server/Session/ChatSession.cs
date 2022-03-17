using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server.Session
{
    /// <summary>
    /// 链接（会话）
    /// </summary>
    public class ChatSession : AppSession<ChatSession>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public bool IsLogin { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime LastHbTime { get; set; }



        public bool IsOnline
        {
            get
            {
                return this.LastHbTime.AddSeconds(10) > DateTime.Now;
            }
        }

        public override void Send(string message)
        {

            Console.WriteLine($"{message}");
            base.Send(message);
        }

       
        protected override void OnInit()
        {
            this.Charset = Encoding.GetEncoding("gb2312");
            base.OnInit();
        }

        protected override void OnSessionStarted()
        {
           // this.Send("Welcome to SuperSocket Chat Server");
        }

        /// <summary>
        /// 异常捕捉
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            this.Send($"\n\r异常信息：{ e.Message}");
            //base.HandleException(e);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            Console.WriteLine("链接已关闭。。。");
            base.OnSessionClosed(reason);
        }

        /// <summary>
        /// 有新的命令执行的时候触发；
        /// </summary>
        /// <param name="requestInfo"></param>
        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            Console.WriteLine("收到命令:" + requestInfo.Key.ToString());
            //base.HandleUnknownRequest(requestInfo);
        }
    }
}
