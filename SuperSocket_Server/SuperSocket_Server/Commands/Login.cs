using SuperSocket_Server.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server.Commands
{
    public class Login : CommandBase<ChatSession, StringRequestInfo>
    {
        /// <summary>
        /// 当命令执行的时候；来出发这里的动作
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            string id = requestInfo.Parameters[0];
            string name = requestInfo.Parameters[1];
            string password = requestInfo.Parameters[2];

            {
                //在这里应该去数据库中去做校验
            }

            session.Id = id;
            session.Name = name;
            session.Password = password;
            session.Send("接收到命令~");

            session.Send($"{name}  登录成功了....");
            { //在这里接受历史消息； 
                ChatDataManager.SendHistoryMessage(session);
            }
        }
    }
}
