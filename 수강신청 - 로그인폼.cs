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

namespace WindowsFormsApp_Login
{
    public partial class Form1 : Form
    {
        private static TcpClient client = null;
        private static Thread rcvThread;
        private static Thread sndThread;
        public static NetworkStream stream;
        public static StreamReader reader;
        public static StreamWriter writer;
        
        public Form1()
        {
            ClientToServer_Connector();
            InitializeComponent();
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            
        }

     

        private void txt_Psw_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Id_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ClientToServer_Connector()
        {
        
        /*
        비번받아서 SHA 해싱하고 패킷만드는 코드
        적당히 고쳐서 쓰시면돼요
        서버프로그램에서 해볼려고 만든거라 변수명 안맞음
        
        맨위에 using System.Security.Cryptography;
        추가필요
        
        Console.Write("사용자 ID입력 >> ");
                string studentID = Console.ReadLine();
                Console.Write("사용자 PW입력 >> ");
                string studentPWPlain = Console.ReadLine();

                //From String to byte array
                SHA1 sha = SHA1.Create();
                byte[] sourceBytes = Encoding.UTF8.GetBytes(studentPWPlain);
                byte[] hashBytes = sha.ComputeHash(sourceBytes);
                string studentPWHash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                Console.WriteLine(studentPWHash);

                user tst = new user();
                tst.SetStuID(studentID); tst.SetPwd(studentPWHash);

                if (QueryProcess.DBLogin(tst) == LoginResult.OK)
                    Console.WriteLine("성공");
                else { Console.WriteLine("없음"); }
        */
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
