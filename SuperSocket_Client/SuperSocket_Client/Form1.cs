using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSocket_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         
        private AsyncTcpSession asyncTcpsession = null;

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string ipAddress = this.IpAddressTxt.Text;
            string port = this.PortTxt.Text;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), Convert.ToInt32(port));
            asyncTcpsession = new AsyncTcpSession();
            asyncTcpsession.Connect(endPoint);
            //委托事件
            asyncTcpsession.DataReceived += (x, s) =>
            {
                //在这里处理接受到消息 
                string msg = Encoding.Default.GetString(s.Data, 0, s.Data.Length);

                this.Invoke(new Action(() =>
                {
                    this.Message.Text += "\r\n" + msg;
                })); 
            };
        }
         
        private void Send_Click(object sender, EventArgs e)
        { 
            string message = this.txtCommand.Text+ "\r\n";
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)); 
            asyncTcpsession.Send(buffer);
        }
    }
}
