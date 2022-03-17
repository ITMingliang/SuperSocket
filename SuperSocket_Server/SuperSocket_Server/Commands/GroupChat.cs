using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocket_Server.Model;
using SuperSocket_Server.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server.Commands
{
    public class GroupChat : CommandBase<ChatSession, StringRequestInfo>
    {
        /// <summary>
        /// 要求发送消息的命令： 必须有一个参数（消息内容）
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            //throw new NotImplementedException();
            if (requestInfo.Parameters != null && requestInfo.Parameters.Count() > 0)
            {
                //1.在这里得到了需要发送到群里的消息内容；
                string sendMsg = requestInfo.Parameters[0];
                //2.发给所有人，就应该找到所有登录过的人对应的链接；
                // session.AppServer.GetAllSessions(); //找到所有的链接在服务器实例上的链接 
                IEnumerable<ChatSession> ToSessionlist = session.AppServer.GetAllSessions();
                foreach (var toSession in ToSessionlist)
                {
                    toSession.Send($"{DateTime.Now} {session.Name} : {sendMsg}");
                }
                //升级：为了能够满足用户接收到历史消息；应该把发送的消息给保存起来；如果有新的用户登录进来；就应该把消息推送给这个用户； 
                ChatDataManager.AddHistoryMessage(new ChatModel()
                {
                    FromId = session.Id,
                    FromName = session.Name,
                    CreateTime = DateTime.Now,
                    Message = sendMsg
                }); ;
            }



        }
    }
}
