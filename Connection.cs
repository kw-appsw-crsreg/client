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
using System.Runtime.CompilerServices;

namespace _2023AppSWClient
{
    public class Connection
    {
        private static TcpClient client = null;
        private static Thread rcvThread;
        public static NetworkStream stream;
        public static StreamReader reader;
        public static StreamWriter writer;
        public static Packet pac;
        static byte[] readBuffer = new byte[1024 * 4000];
        static byte[] sendBuffer = new byte[1024 * 4000];
        public static Stack<Packet> stack = new Stack<Packet>();

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
            catch (Exception e)
            {
                throw new ServerException();
            }
        }

        static void ReceiverThread()
        {
            try
            {
                int bs = 0;
                reader = new StreamReader(stream);

                while (true)
                {
                    bs = stream.Read(readBuffer, 0, 1024 * 4000);
                    Initialize init = (Initialize)Packet.Desserialize(readBuffer);

                    if (init != null)
                    {
                        pac = ServerRst(init);
                        stack.Push(pac);
                    }
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
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}", e);
            }
            finally
            {
                Console.WriteLine("연결중 문제가 발생했습니다");
            }
        }

        static Packet ServerRst(Initialize packet)
        {
          /*
          * server에서 반환된 쿼리 작업 결과물을 패킷 타입을 통해서 해당 작업의 결과를 결정.
          * 쿼리 작업이 수행된 후에 나온 실패의 유무와 성공했다면 그 작업의 결과물을 패킷에 담아서 반환해줌.
          */
            switch ((int)packet.Type)
            {
                case (int)RegisterResult.OK:
                    {
                        Register register = new Register();
                        register.Type = (int)RegisterResult.OK;
                        register.ds = packet.ds;
                        return register;
                    }
                case (int)RegisterResult.ForeignerOnly:
                    {
                        Register register = new Register();
                        register.Type = (int)RegisterResult.ForeignerOnly;
                        return register;
                    }
                case (int)RegisterResult.ExceedsCredit:
                    {
                        Register register = new Register();
                        register.Type = (int)RegisterResult.ExceedsCredit;
                        return register;
                    }
                case (int)RegisterResult.TimeConflicts:
                    {
                        Register register = new Register();
                        register.Type = (int)RegisterResult.TimeConflicts;
                        return register;
                    }
                case (int)RegisterResult.AlreadyRegistered:
                    {
                        Register register = new Register();
                        register.Type = (int)RegisterResult.AlreadyRegistered;
                        return register;
                    }
                case (int)RegisterResult.OverCapacity:
                    {
                        Register register = new Register();
                        register.Type = (int)RegisterResult.OverCapacity;
                        return register;
                    }
                case (int)RegisterResult.Error:
                    {
                        Register register = new Register();
                        register.Type = (int)RegisterResult.Error;
                        return register;
                    }
                case (int)InquireResult.OK:
                    {
                        inquire inquire = new inquire();
                        inquire.Type = (int)InquireResult.OK;
                        inquire.ds = packet.ds;
                        return inquire;
                    }
                case (int)InquireResult.WrongCourseNumber:
                    {
                        inquire inquire = new inquire();
                        inquire.Type = (int)InquireResult.WrongCourseNumber;
                        return inquire;
                    }
                case (int)InquireResult.AlreadyTaken:
                    {
                        inquire inquire = new inquire();
                        inquire.Type = (int)InquireResult.AlreadyTaken;
                        return inquire;
                    }
                case (int)InquireResult.AlreadyFull:
                    {
                        inquire inquire = new inquire();
                        inquire.Type = (int)InquireResult.AlreadyFull;
                        return inquire;
                    }
                case (int)InquireResult.Error:
                    {
                        inquire inquire = new inquire();
                        inquire.Type = (int)InquireResult.Error;
                        return inquire;
                    }
                case (int)LoginResult.OK:
                    {
                        Login login = new Login();
                        login.Type = (int)LoginResult.OK;
                        login.ds = packet.ds;
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
                        favorites.Type = (int)FavoritesResult.OK;
                        favorites.ds = packet.ds;
                        return favorites;
                    }
                case (int)FavoritesResult.FAIL:
                    {
                        Favorites favorites = new Favorites();
                        favorites.Type = (int)FavoritesResult.FAIL;
                        return favorites;
                    }
                case (int)FavoritesResult.AlreadyExist:
                    {
                        Favorites favorites = new Favorites();
                        favorites.Type = (int)FavoritesResult.AlreadyExist;
                        return favorites;
                    }
                case (int)First_ProcessResult.OK:
                    {
                        Initialize init = new Initialize();
                        init.Type = (int)First_ProcessResult.OK;
                        init.ds = packet.ds;
                        return init;
                    }
                case (int)First_ProcessResult.Error:
                    {
                        Initialize init = new Initialize();
                        init.Type = (int)First_ProcessResult.Error;
                        return init;
                    }
            }
            return null;

        }

        public static Packet GetServerPacket()
        {
            try
            {
                Packet p = stack.Pop();
                return p;
            }
            catch (Exception e)
            { return null; }
        }

        public static void AbortThread()
        {
            try
            {
                client.Close();
                rcvThread.Abort();
            }
            catch (Exception e)
            { }
        }
    }
}
