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
using MySqlConnector;
using MySqlX.XDevAPI;
using System.Security.Cryptography;
using AppswPacket;

namespace _2023AppSWClient
{
    public partial class Login_Form : Form
    {
        Form1 form1;
        Login login;
        private static Thread sndThread;
        public static NetworkStream stream;

        public Login_Form()
        {
            try
            {
                Connection.Run();
                InitializeComponent();
                label3.Text = "Server Connect Success! " + DateTime.Now;
            }
            catch (Exception e)
            {
                InitializeComponent();
                label3.Text = "Server Connect Fail!";
            }
        }
        //로그인하면 로그인 창 사리짐
        private void button1_Click(object sender, EventArgs e)
        {
            sndThread = new Thread(new ParameterizedThreadStart(Connection.SendThread));
            login = new Login();
            login.stuID = textBox1.Text;
            login.pwd = textBox2.Text;
            
            using (SHA1 sha = SHA1.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(login.pwd);
                byte[] hashBytes = sha.ComputeHash(sourceBytes);
                string studentPWHash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                login.pwd = studentPWHash;
            }

            sndThread.Start(login);

            wait();
            login = (Login)Connection.GetServerPacket();
            if (login.Type == (int)LoginResult.OK)
            {
                MessageBox.Show("로그인 완료");
                sndThread.Abort();
                form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else if (login.Type == (int)LoginResult.WrongPassword)
            {
                MessageBox.Show("비밀번호를 다시 확인해주세요! ");
                sndThread.Abort();
            }
            else if (login.Type == (int)LoginResult.NotYourDate)
            {
                MessageBox.Show("지금은 수강신청 기간이 아닙니다! ");
                sndThread.Abort();
            }
            else if (login.Type == (int)LoginResult.ServerOff)
            {
                MessageBox.Show("서버 연결을 확인해주세요! ");
                sndThread.Abort();
            }
            else
            {
                MessageBox.Show("오류가 발생했습니다!");
                sndThread.Abort();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void wait()
        {
            while (Connection.stack.Count == 0)
            {
                continue;
            }
        }

    }
}
