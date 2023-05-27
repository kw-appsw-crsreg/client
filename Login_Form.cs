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
                sndThread = new Thread(new ParameterizedThreadStart(Connection.SendThread));
                InitializeComponent();
                label3.Text = "Server Connect Success! " + DateTime.Now;
            } catch (Exception e) {
                InitializeComponent();
                label3.Text = "Server Connect Fail!";
            }
        }
        //로그인하면 로그인 창 사리짐
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                MySqlConnection connection = new MySqlConnection("Server = localhost;Database=sugang;Uid=root;Pwd=root;");
                connection.Open();

                int login_status = 0;

                string loginid = textBox1.Text;
                string loginpwd = textBox2.Text;

                string selectQuery = "SELECT * FROM student_info WHERE student_id = \'" + loginid + "\' ";
                MySqlCommand Selectcommand = new MySqlCommand(selectQuery, connection);

                MySqlDataReader student_info = Selectcommand.ExecuteReader();

                while (student_info.Read())
                {
                    if (loginid == (string)student_info["student_id"] && loginpwd == (string)student_info["password"])
                    {
                        login_status = 1;
                    }
                }
                connection.Close();

                if (login_status == 1)
                {
                    MessageBox.Show("로그인 완료");
                    form1 = new Form1();
                    form1.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

            login = new Login();
            login.stuID = " ";
            login.pwd = " ";
            sndThread.Start(login);

            if(Connection.init.Type == (int)LoginResult.OK )
            {

            }
            else if(Connection.init.Type == (int)LoginResult.WrongPassword)
            {

            }
            else if(Connection.init.Type == (int)LoginResult.NotYourDate)
            {

            }
            else if(Connection.init.Type == (int)LoginResult.ServerOff)
            {

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
    }
}
