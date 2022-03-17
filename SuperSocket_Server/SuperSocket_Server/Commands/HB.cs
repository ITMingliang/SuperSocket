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

    public class HB : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 1)
            {
                if ("R".Equals(requestInfo.Parameters[0]))
                {
                    session.LastHbTime = DateTime.Now;
                    session.Send("R");
                }
                else
                {
                    session.Send("参数错误");
                }
            }
            else
            {
                session.Send("参数错误");
            }
        }
    }
}
