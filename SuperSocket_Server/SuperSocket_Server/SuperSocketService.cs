using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server
{
    public class SuperSocketService
    {
        public static void Init()
        {
            //1.可以通过代码配置启动服务
            //2.也可以通过配置文件来启动服务


            //如果要让客户端去连接服务，服务必然需要监听某个端口，类似于:这种端口信息，最大链接数据，超时时间

            IBootstrap bootstrap = BootstrapFactory.CreateBootstrap();
            if (!bootstrap.Initialize())//读取配置文件；  如果读取失败了；
            {
                Console.WriteLine("初始化服务失败了。。。。");
                Console.Read();
                return;
            }
            Console.WriteLine("开始启动服务。。。。");
            StartResult result = bootstrap.Start();//启动服务 
            foreach (var server in bootstrap.AppServers)
            {
                if (server.State == ServerState.Running)
                {
                    Console.WriteLine($"{server.Name} 服务启动成功。。。。");
                }
                else
                {

                    Console.WriteLine($"{server.Name} 服务启动失败了。。。。");
                }
            }
        }
    }
}
