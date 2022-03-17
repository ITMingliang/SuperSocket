using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server
{
    public class Program
    {
        //1.解析Socket特点,如何应用于Socket
        //2.从Http单向走向Socket双向
        //3.学习使用SuperSocket
        //4.实现双工
        static void Main(string[] args)
        {
            //1.nuget引入程序包：SuperSocket.SocketEngine,安装以后，会自动出现一些文件；内置了Log4Net--- 大家需要注意，Log4net版本问题；
            //2.定义服务
            //3.定义Session
            //4.启动服务，让服务运行起来

            try
            {
                Console.WriteLine("欢迎大家使用SuperSocket~~");
                SuperSocketService.Init();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            Console.Read();
        }
    }
}
