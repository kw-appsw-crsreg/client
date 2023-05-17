using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace _2023AppSWClient
{
    public partial class Login_Form : Form
    {
        Form1 form1;
        private static TcpClient client = null;
        private static Thread rcvThread;
        private static Thread sndThread;
        public static NetworkStream stream;
        public static StreamReader reader;
        public static StreamWriter writer;

        public Login_Form()
        {
            ClientToServer_Connector();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientToServer_Connector()
        {
            try
            {
                client = new TcpClient();
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                int port = 12000;
                client.Connect(localAddr, port);

                stream = client.GetStream();
                rcvThread = new Thread(new ThreadStart(ReceiverThread));
                sndThread = new Thread(new ThreadStart(SendThread));

                rcvThread.Start();
                sndThread.Start();
            }
            catch (Exception e) { }
        }

        static void ReceiverThread()
        {
            try
            {
                reader = new StreamReader(stream);

                while (true)
                {
                    String order = reader.ReadLine();
                    Console.WriteLine(order);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}", e);
            }
            finally
            {
                Console.WriteLine("연결중 문제가 발생했습니다");
            }
        }

        static void SendThread()
        {
            try
            {
                writer = new StreamWriter(stream);

                while (true)
                {
                    String order = Console.ReadLine();
                    writer.WriteLine(order);
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}", e);
            }
            finally
            {
                Console.WriteLine("연결중 문제가 발생했습니다");
            }
        }
    }
}
