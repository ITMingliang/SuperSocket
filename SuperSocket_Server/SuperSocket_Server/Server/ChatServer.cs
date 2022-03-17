using SuperSocket_Server.Session;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Config;

namespace SuperSocket_Server.Server
{
    /// <summary>
    /// 这里是定义的Socket服务器----客户端和服务器链接，就需要Session会话（链接）
    /// </summary>
    public class ChatServer : AppServer<ChatSession>
    {

        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            Console.WriteLine("准备读取配置文件。。。。");
            return base.Setup(rootConfig, config);
        }


        /// <summary>
        /// 当一个新的链接连入到服务实例之后发生
        /// </summary>
        /// <param name="session"></param>
        protected override void OnNewSessionConnected(ChatSession session)
        {
            Console.WriteLine($"新链接加入进来,链接ID:{session.Id}");

            session.Send("欢迎连接到服务器~~");
            base.OnNewSessionConnected(session);
        }

        protected override void OnStarted()
        {
            Console.WriteLine("Chat服务启动。。。");
            base.OnStarted();
        }


        /// <summary>
        /// 客户端执行命令的时候来出发这个方法
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        protected override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            base.ExecuteCommand(session, requestInfo);
        }


        protected override void OnStopped()
        {
            Console.WriteLine("Chat服务停止。。。");
            base.OnStopped();
        }

    }
}
