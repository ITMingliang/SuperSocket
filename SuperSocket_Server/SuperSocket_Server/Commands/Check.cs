using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocket_Server.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server.Commands
{
    public class Check : CommandBase<ChatSession, StringRequestInfo>


    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 2)
            {
                ChatSession oldSession = session.AppServer.GetAllSessions().FirstOrDefault(a => requestInfo.Parameters[0].Equals(a.Id));
                if (oldSession != null) // 说过之前有用户用这个Id 登录过
                {
                    oldSession.Send("您的账号已经在他处登录，您已经被踢下线了");
                    oldSession.Close();
                }

                #region 这里就可以连接数据库进行数据验证做登录
                ///---------------------
                #endregion
                session.Id = requestInfo.Parameters[0];
                session.Password = requestInfo.Parameters[1];
                session.IsLogin = true;
                session.LoginTime = DateTime.Now;

                session.Send("登录成功");

                { // 获取当前登录用户的离线消息 
                    ChatDataManager.SendLogin(session.Id, c =>
                    {
                        session.Send($"{c.FromId} 给你发送消息：{c.Message} {c.Id}");
                    });

                }
            }
            else
            {
                session.Send("参数错误");
            }
        }
    }
}
