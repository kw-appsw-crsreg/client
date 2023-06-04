using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using AppswPacket;

namespace _2023AppSWClient
{
    public class Connection
    {
        private static TcpClient client = null;
        private static Thread rcvThread;
        public static NetworkStream stream;
        public static StreamReader reader;
        public static StreamWriter writer;
        public static Packet init;
        static byte[] readBuffer = new byte[1024 * 4];
        static byte[] sendBuffer = new byte[1024 * 4];
        static public void Run()
        {
            try
            {
                client = new TcpClient();
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                int port = 12000;
                client.Connect(localAddr, port);

                stream = client.GetStream();
                rcvThread = new Thread(new ThreadStart(ReceiverThread));
                rcvThread.Start();
            }
            catch (Exception e) {
                throw new ServerException();            }
        }

        static void ReceiverThread()
        {
            try
            {
                int bs = 0;
                reader = new StreamReader(stream);

                while (true)
                {
                    bs = stream.Read(readBuffer, 0, 1024 * 4);
                    Packet packet = (Packet)Packet.Desserialize(readBuffer);
                    init = ServerRst(packet);
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

        public static void SendThread(Object init)
        {
            try
            {
                int bs = 0;
                writer = new StreamWriter(stream);

                while (true)
                {
                    // Winform에서 버튼 누른 후 해당 작동과 관련된 패킷이 할당됨
                    Packet.Serialize((Packet)init).CopyTo(sendBuffer, 0);

                    stream.Write(sendBuffer, 0, sendBuffer.Length);
                    stream.Flush();

                    for (int i = 0; i < sendBuffer.Length; i++)
                    {
                        sendBuffer[i] = 0;
                    }
                    stream.Flush();
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

        static Packet ServerRst(Packet packet)
        {
            switch ((int)packet.Type)
            {
                case (int)RegisterResult.OK:
                    {
                        Register register = new Register();
                        return register;
                    }
                case (int)RegisterResult.ForeignerOnly:
                    {
                        Register register = new Register();
                        return register;
                    }
                case (int)RegisterResult.ExceedsCredit:
                    {
                        Register register = new Register();
                        return register;
                    }
                case (int)RegisterResult.TimeConflicts:
                    {
                        Register register = new Register();
                        return register;
                    }
                case (int)RegisterResult.AlreadyRegistered:
                    {
                        Register register = new Register();
                        return register;
                    }
                case (int)RegisterResult.OverCapacity:
                    {
                        Register register = new Register();
                        return register;
                    }
                case (int)RegisterResult.Error:
                    {
                        Register register = new Register();
                        return register;
                    }
                case (int)InquireResult.OK:
                    {
                        inquire inquire = new inquire();
                        return inquire;
                    }
                case (int)InquireResult.WrongCourseNumber:
                    {
                        inquire inquire = new inquire();
                        return inquire;
                    }
                case (int)InquireResult.AlreadyTaken:
                    {
                        inquire inquire = new inquire();
                        return inquire;
                    }
                case (int)InquireResult.AlreadyFull:
                    {
                        inquire inquire = new inquire();
                        return inquire;
                    }
                case (int)InquireResult.Error:
                    {
                        inquire inquire = new inquire();
                        return inquire;
                    }
                case (int)LoginResult.OK:
                    {
                        Login login = new Login();
                        login.Type = (int)LoginResult.OK;
                        return login;
                    }
                case (int)LoginResult.WrongPassword:
                    {
                        Login login = new Login();
                        login.Type = (int)LoginResult.WrongPassword;
                        return login;
                    }
                case (int)LoginResult.NotYourDate:
                    {
                        Login login = new Login();
                        login.Type = (int)LoginResult.NotYourDate;
                        return login;
                    }
                case (int)LoginResult.ServerOff:
                    {
                        Login login = new Login();
                        login.Type = (int)LoginResult.ServerOff;
                        return login;
                    }
                case (int)FavoritesResult.OK:
                    {
                        Favorites favorites = new Favorites();
                        return favorites;
                    }
                case (int)FavoritesResult.FAIL:
                    {
                        Favorites favorites = new Favorites();
                        return favorites;
                    }
                case (int)FavoritesResult.AlreadyExist:
                    {
                        Favorites favorites = new Favorites();
                        return favorites;
                    }
                case (int)First_ProcessResult.OK:
                    {
                        Initialize init = new Initialize();
                        return init;
                    }
                case (int)First_ProcessResult.Error:
                    {
                        Initialize init = new Initialize();
                        return init;
                    }
            }
            return null;

        }
    }
}
