using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Metadata;
using SuperSocket_Server.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server
{
    class AuthorisizeFilterAttribute : CommandFilterAttribute
    {

        public override void OnCommandExecuting(CommandExecutingContext commandContext)
        {
            ChatSession session = (ChatSession)commandContext.Session;
            string command = commandContext.CurrentCommand.Name;
            if (!session.IsLogin)
            {
                if (!command.Equals("Check"))
                {
                    session.Send($"请先登录，再操作");
                    commandContext.Cancel = true;
                }
                else
                {

                }
            }
            else if (!session.IsOnline)
            {
                session.LastHbTime = DateTime.Now;
            }

        }

        public override void OnCommandExecuted(CommandExecutingContext commandContext)
        {

        }

    }
}
