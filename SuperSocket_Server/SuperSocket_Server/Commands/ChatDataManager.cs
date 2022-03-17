using SuperSocket_Server.Model;
using SuperSocket_Server.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server.Commands
{
    public class ChatDataManager
    {
        /// <summary>
        /// key是用户id
        /// List 这个用户的全部消息
        /// </summary>
        private static Dictionary<string, List<ChatModel>> Dictionary = new Dictionary<string, List<ChatModel>>();

        public static void Add(string userId, ChatModel model)
        {
            if (Dictionary.ContainsKey(userId))
            {
                Dictionary[userId].Add(model);
            }
            else
            {
                Dictionary[userId] = new List<ChatModel>() { model };
            }
        }
        public static void Remove(string userId, string modelId)
        {
            if (Dictionary.ContainsKey(userId))
            {
                Dictionary[userId] = Dictionary[userId].Where(m => m.Id != modelId).ToList();
            }
        }

        public static void SendLogin(string userId, Action<ChatModel> action)
        {
            if (Dictionary.ContainsKey(userId))
            {
                foreach (var item in Dictionary[userId])
                {
                    action.Invoke(item);
                    item.State = 1;
                }
            }
        }


        ///保存历史消息：
        ///1.可以保存在数据库
        ///2.也可以保存在缓存

        private static List<ChatModel> historyMessageList = new List<ChatModel>();

        public static void AddHistoryMessage(ChatModel chatModel)
        {
            historyMessageList.Add(chatModel);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SendHistoryMessage(ChatSession session)
        {
            foreach (var messageModel in historyMessageList)
            {
                session.Send($"{messageModel.CreateTime}   {messageModel.FromId}:{messageModel.Message}");
            }
        }
    }
}
