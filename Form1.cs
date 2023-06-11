using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppswPacket;


namespace _2023AppSWClient
{
    public partial class Form1 : Form
    {
        string testSearch = "{\"Table\":[{\"course_id\":\"20231H0001295701\",\"type\":\"전선\",\"course_name\":\"공학설계입문\",\"credit\":3,\"instructor_name\":\"최상\r\n호\",\"remaining_capacity\":2,\"time\":\"화2.목1.\"},{\"course_id\":\"20231H0001295702\",\"type\":\"전선\",\"course_name\":\"공학설계입문\",\"credit\":3,\"instructor_name\":\"\",\"remaining_capacity\":2,\"time\":\"월3.수4.\"},{\"course_id\":\"20231H0001309501\",\"type\":\"교필\",\"course_name\":\"융합적사고와글쓰기\",\"credit\":3,\"instructor_name\":\"허연실\",\"remaining_capacity\":2,\"time\":\"월1.수2.\"},{\"course_id\":\"20231H0001309502\",\"type\":\"교필\",\"course_name\":\"융합적사고와글쓰기\",\"credit\":3,\"instructor_name\":\"전도현\",\"remaining_capacity\":2,\"time\":\"월2.수1.\"},{\"course_id\":\"20231H0001309503\",\"type\":\"교필\",\"course_name\":\"융합적사고와글쓰기\",\"credit\":3,\"instructor_name\":\"유승호\",\"remaining_capacity\":2,\"time\":\"월5.수6.\"},{\"course_id\":\"20231H0001309504\",\"type\":\"교필\",\"course_name\":\"융합적사고와글쓰기\",\"credit\":3,\"instructor_name\":\"이주영\",\"remaining_capacity\":2,\"time\":\"월6.수5.\"},{\"course_id\":\"20231H0001309505\",\"type\":\"교필\",\"course_name\":\"융합적사고와글쓰기\",\"credit\":3,\"instructor_name\":\"김광섭\",\"remaining_capacity\":2,\"time\":\"화2.목1.\"},{\"course_id\":\"20231H0001309506\",\"type\":\"교필\",\"course_name\":\"융합적사고와글쓰기\",\"credit\":3,\"instructor_name\":\"조영복\",\"remaining_capacity\":2,\"time\":\"화5.목6.\"},{\"course_id\":\"20231H0001309507\",\"type\":\"교필\",\"course_name\":\"융합적사고와글쓰기\",\"credit\":3,\"instructor_name\":\"이지은\",\"remaining_capacity\":2,\"time\":\"화6.목5.\"},{\"course_id\":\"20231H0001309508\",\"type\":\"교필\",\"course_name\":\"융합적사 고와글쓰기\",\"credit\":3,\"instructor_name\":\"이은경\",\"remaining_capacity\":2,\"time\":\"금1.금2.\"},{\"course_id\":\"20231H0001309509\",\"type\":\"교필\",\"course_name\":\"융합적사고와글쓰기\",\"credit\":3,\"instructor_name\":\"신정은\",\"remaining_capacity\":2,\"time\":\"금3.금4.\"},{\"course_id\":\"20231H0001341501\",\"type\":\"기필\",\"course_name\":\"대학화학및실험1\",\"credit\":3,\"instructor_name\":\"사영진\",\"remaining_capacity\":2,\"time\":\"화5.\"},{\"course_id\":\"20231H0001341502\",\"type\":\"기필\",\"course_name\":\"대학화학및실험1\",\"credit\":3,\"instructor_name\":\"사영진\",\"remaining_capacity\":2,\"time\":\"화6.\"},{\"course_id\":\"20231H0001367401\",\"type\":\"전선\",\"course_name\":\"창의설계입문\",\"credit\":3,\"instructor_name\":\"신원경\",\"remaining_capacity\":2,\"time\":\"월2.수1.\"},{\"course_id\":\"20231H0001367402\",\"type\":\"전선\",\"course_name\":\"창의설계입문\",\"credit\":3,\"instructor_name\":\"김미화\",\"remaining_capacity\":2,\"time\":\"금3.금4.\"},{\"course_id\":\"20231H0001462501\",\"type\":\"기필\",\"course_name\":\"대학수학및연습1\",\"credit\":3,\"instructor_name\":\"김순영\",\"remaining_capacity\":2,\"time\":\"월2.수1.\"},{\"course_id\":\"20231H0001462502\",\"type\":\"기필\",\"course_name\":\"대학수학및연습1\",\"credit\":3,\"instructor_name\":\"채형직\",\"remaining_capacity\":2,\"time\":\"월4.수3.\"}]}";

        Packet packcet;
        public Form1()
        {
            packcet = Connection.init;
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            lvw_search_res.View = View.Details;
            lvw_done.View = View.Details;

            //검색결과란에 column 추가
            lvw_search_res.Columns.Add("순번", "순번");
            lvw_search_res.Columns.Add("학정번호", "학정번호");
            lvw_search_res.Columns.Add("구분", "구분");
            lvw_search_res.Columns.Add("과목명", "과목명");
            lvw_search_res.Columns.Add("학점", "학점");
            lvw_search_res.Columns.Add("담당교수", "담당교수");
            lvw_search_res.Columns.Add("여석", "여석");
            lvw_search_res.Columns.Add("강의시간", "강의시간");
            lvw_search_res.Columns.Add("last", "last");

            //수강신청 완료된 교과목 column 추가
            lvw_done.Columns.Add("순번", "순번");
            lvw_done.Columns.Add("학정번호", "학정번호");
            lvw_done.Columns.Add("구분", "구분");
            lvw_done.Columns.Add("과목명", "과목명");
            lvw_done.Columns.Add("학점", "학점");
            lvw_done.Columns.Add("담당교수", "담당교수");
            lvw_done.Columns.Add("요일1", "요일1");
            lvw_done.Columns.Add("시간1", "시간1");
            lvw_done.Columns.Add("강의실1", "강의실1");
            lvw_done.Columns.Add("요일2", "요일2");
            lvw_done.Columns.Add("시간2", "시간2");
            lvw_done.Columns.Add("강의실2", "강의실2");
            lvw_done.Columns.Add("last", "last");

            //width header size auto rezsize
            lvw_search_res.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvw_search_res.Columns.RemoveByKey("last");
            lvw_done.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvw_done.Columns.RemoveByKey("last");

            //alignmnet
            lvw_search_res.Columns[0].TextAlign = HorizontalAlignment.Center;
            lvw_search_res.Columns[1].TextAlign = HorizontalAlignment.Center;
            lvw_search_res.Columns[2].TextAlign = HorizontalAlignment.Center;
            lvw_search_res.Columns[3].TextAlign = HorizontalAlignment.Left;
            lvw_search_res.Columns[4].TextAlign = HorizontalAlignment.Center;
            lvw_search_res.Columns[5].TextAlign = HorizontalAlignment.Left;
            lvw_search_res.Columns[6].TextAlign = HorizontalAlignment.Center;
            lvw_search_res.Columns[7].TextAlign = HorizontalAlignment.Left;

            lvw_done.Columns[0].TextAlign = HorizontalAlignment.Center;
            lvw_done.Columns[1].TextAlign = HorizontalAlignment.Center;
            lvw_done.Columns[2].TextAlign = HorizontalAlignment.Center;
            lvw_done.Columns[3].TextAlign = HorizontalAlignment.Left;
            lvw_done.Columns[4].TextAlign = HorizontalAlignment.Center;
            lvw_done.Columns[5].TextAlign = HorizontalAlignment.Left;
            lvw_done.Columns[6].TextAlign = HorizontalAlignment.Center;
            lvw_done.Columns[7].TextAlign = HorizontalAlignment.Left;
            lvw_done.Columns[8].TextAlign = HorizontalAlignment.Center;
            lvw_done.Columns[9].TextAlign = HorizontalAlignment.Center;
            lvw_done.Columns[10].TextAlign = HorizontalAlignment.Left;
            lvw_done.Columns[11].TextAlign = HorizontalAlignment.Center;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox59_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_ViewLectPlan_Click(object sender, EventArgs e)
        {
            //U 2023   1   0969   H030    02    3 
            //U 년도 학기 과목 개설학과 분반 난이도
            //string lectCode = lvw_search_res.Items[lvw_search_res.FocusedItem.Index].SubItems[0].Text.ToString();
            string lectCode = "U202310969H030023";
            string lectPlanURLBase = "https://klas.kw.ac.kr/std/cps/atnlc/popup/LectrePlanStdView.do?selectSubj=";

            System.Diagnostics.Process.Start(lectPlanURLBase + lectCode);
        }

        private void btn_SearchCourse_Click(object sender, EventArgs e) //Winform조작 작동 확인 완료
        {
            /*
             * cbbox_collegeof
             * cbbox_department
             * cbbox_lecttype
             * txt_subject
             * chk_onlyvalid (여석있는것만조회할지?)
             * 이거 5개 묶어서 서버에 패킷으로 쏘는 핸들러 필요
             */
            ////////////////////////////////////////////////////////////////////////
            //받아온 검색결과 Listview에 띄워주기
            string sourceJson = "";
            sourceJson = testSearch;
            System.Data.DataSet dataSet = DatasetConvertor.DeserializeFromJSON( sourceJson);
            long i = 1;
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(row[0].ToString());
                item.SubItems.Add(row[1].ToString());
                item.SubItems.Add(row[2].ToString());
                item.SubItems.Add(row[3].ToString());
                item.SubItems.Add(row[4].ToString());
                item.SubItems.Add(row[5].ToString());
                item.SubItems.Add(row[6].ToString());

                lvw_search_res.Items.Add(item);
                i++;
            }
            lvw_search_res.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); //모든 열 사이즈 자동조절
        }

        private void btn_AddToFav_Click(object sender, EventArgs e) //Winform조작 작동 확인 완료
        {
            /*
             cbbox_favnum(즐겨찾기번호)
            밑에 lev_search_res 선택된과목 즐겨찾기 추가하는거 필요
            패킷으로 학번+즐겨찾기순서+학정번호 추가요청 보내고
            txt_lec_codeN    txt_lec_nameN   txt_credN   txt_profN   txt_lectN(강의시간)
            요 5개 채우기
            */
            int index = int.Parse(cbBox_FavNum.SelectedText);

            index = 1; //임시변수

            ListViewItem selectedItem = lvw_search_res.SelectedItems.Cast<ListViewItem>().FirstOrDefault();

            if (selectedItem != null)
            {
                // 여기에 패킷 추가(서버에 즐겨찾기 추가)!!!!!!)!!!!!!)!!!!!!)!!!!!!)!!!!!!
                if (index == 1)
                {
                    txt_lec_code1.Text = selectedItem.SubItems[1].Text;
                    txt_lec_name1.Text = selectedItem.SubItems[3].Text;
                    txt_cred1.Text = selectedItem.SubItems[4].Text;
                    txt_prof1.Text = selectedItem.SubItems[5].Text;
                    txt_lect1.Text = selectedItem.SubItems[7].Text;

                }
                else if (index == 2)
                {
                    txt_lec_code2.Text = selectedItem.SubItems[1].Text;
                    txt_lec_name2.Text = selectedItem.SubItems[3].Text;
                    txt_cred2.Text = selectedItem.SubItems[4].Text;
                    txt_prof2.Text = selectedItem.SubItems[5].Text;
                    txt_lect2.Text = selectedItem.SubItems[7].Text;
                }
                else if (index == 3)
                {
                    txt_lec_code3.Text = selectedItem.SubItems[1].Text;
                    txt_lec_name3.Text = selectedItem.SubItems[3].Text;
                    txt_cred3.Text = selectedItem.SubItems[4].Text;
                    txt_prof3.Text = selectedItem.SubItems[5].Text;
                    txt_lect3.Text = selectedItem.SubItems[7].Text;
                }
                else if (index == 4)
                {
                    txt_lec_code4.Text = selectedItem.SubItems[1].Text;
                    txt_lec_name4.Text = selectedItem.SubItems[3].Text;
                    txt_cred4.Text = selectedItem.SubItems[4].Text;
                    txt_prof4.Text = selectedItem.SubItems[5].Text;
                    txt_lect4.Text = selectedItem.SubItems[7].Text;
                }
                else if (index == 5)
                {
                    txt_lec_code5.Text = selectedItem.SubItems[1].Text;
                    txt_lec_name5.Text = selectedItem.SubItems[3].Text;
                    txt_cred5.Text = selectedItem.SubItems[4].Text;
                    txt_prof5.Text = selectedItem.SubItems[5].Text;
                    txt_lect5.Text = selectedItem.SubItems[7].Text;
                }
                else if (index == 6)
                {
                    txt_lec_code6.Text = selectedItem.SubItems[1].Text;
                    txt_lec_name6.Text = selectedItem.SubItems[3].Text;
                    txt_cred6.Text = selectedItem.SubItems[4].Text;
                    txt_prof6.Text = selectedItem.SubItems[5].Text;
                    txt_lect6.Text = selectedItem.SubItems[7].Text;
                }
                else if (index == 7)
                {
                    txt_lec_code7.Text = selectedItem.SubItems[1].Text;
                    txt_lec_name7.Text = selectedItem.SubItems[3].Text;
                    txt_cred7.Text = selectedItem.SubItems[4].Text;
                    txt_prof7.Text = selectedItem.SubItems[5].Text;
                    txt_lect7.Text = selectedItem.SubItems[7].Text;
                }
                else if (index == 8)
                {
                    txt_lec_code8.Text = selectedItem.SubItems[1].Text;
                    txt_lec_name8.Text = selectedItem.SubItems[3].Text;
                    txt_cred8.Text = selectedItem.SubItems[4].Text;
                    txt_prof8.Text = selectedItem.SubItems[5].Text;
                    txt_lect8.Text = selectedItem.SubItems[7].Text;
                }
                else
                {
                    return;
                }
            }
            else
            {
                //선택된 과목이 없다고 경고메시지 띄우기
            }
        }

        private void btn_delN_Click(object sender, EventArgs e) //Winform조작 작동 확인 완료
        {
            /*
             * 몇번버튼이 눌렸는지에 따라서 핸들링 필요
             * 삭제하시겠습니까? 메시지띄우고
             * 서버에 삭제요청 보내고
             * txt_lec_codeN    txt_lec_nameN   txt_credN   txt_profN   txt_lectN(강의시간)
             * 요 5개 텍스트 비우기
             */

            // 서버 통신부분 여기에 추가하기!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! (서버에 삭제요청 보내도록)
            Button whichPushed = (Button) sender;
            if(whichPushed== btn_del1)
            {
                txt_lec_code1.Text = "";
                txt_lec_name1.Text = "";
                txt_cred1.Text = "";
                txt_prof1.Text = "";
                txt_lect1.Text = "";
            }
            else if (whichPushed == btn_del2)
            {
                txt_lec_code2.Text = "";
                txt_lec_name2.Text = "";
                txt_cred2.Text = "";
                txt_prof2.Text = "";
                txt_lect2.Text = "";
            }
            else if (whichPushed == btn_del3)
            {
                txt_lec_code3.Text = "";
                txt_lec_name3.Text = "";
                txt_cred3.Text = "";
                txt_prof3.Text = "";
                txt_lect3.Text = "";
            }
            else if (whichPushed == btn_del4)
            {
                txt_lec_code4.Text = "";
                txt_lec_name4.Text = "";
                txt_cred4.Text = "";
                txt_prof4.Text = "";
                txt_lect4.Text = "";
            }
            else if (whichPushed == btn_del5)
            {
                txt_lec_code5.Text = "";
                txt_lec_name5.Text = "";
                txt_cred5.Text = "";
                txt_prof5.Text = "";
                txt_lect5.Text = "";
            }
            else if (whichPushed == btn_del6)
            {
                txt_lec_code6.Text = "";
                txt_lec_name6.Text = "";
                txt_cred6.Text = "";
                txt_prof6.Text = "";
                txt_lect6.Text = "";
            }
            else if (whichPushed == btn_del7)
            {
                txt_lec_code7.Text = "";
                txt_lec_name7.Text = "";
                txt_cred7.Text = "";
                txt_prof7.Text = "";
                txt_lect7.Text = "";
            }
            else if (whichPushed == btn_del8)
            {
                txt_lec_code8.Text = "";
                txt_lec_name8.Text = "";
                txt_cred8.Text = "";
                txt_prof8.Text = "";
                txt_lect8.Text = "";
            }
        }

        private void btn_inqN(object sender, EventArgs e)
        {
            /*
            * 몇번버튼이 눌렸는지에 따라서 핸들링 필요
            * 이건 그냥 txt_hakjung 에다가 
            * txt_lec_codeN 에 있는 번호 갖다 채워버리고
            * txt_Hakjung_TextChanged 호출하면됨
            */
            Button whichPushed = (Button)sender;
            if (whichPushed == btn_inq1)
            {
                txt_Hakjung.Text = txt_lec_code1.Text;
            }
            else if (whichPushed == btn_inq2)
            {
                txt_Hakjung.Text = txt_lec_code2.Text;
            }
            else if (whichPushed == btn_inq3)
            {
                txt_Hakjung.Text = txt_lec_code3.Text;
            }
            else if (whichPushed == btn_inq4)
            {
                txt_Hakjung.Text = txt_lec_code4.Text;
            }
            else if (whichPushed == btn_inq5)
            {
                txt_Hakjung.Text = txt_lec_code5.Text;
            }
            else if (whichPushed == btn_inq6)
            {
                txt_Hakjung.Text = txt_lec_code6.Text;
            }
            else if (whichPushed == btn_inq7)
            {
                txt_Hakjung.Text = txt_lec_code7.Text;
            }
            else if (whichPushed == btn_inq8)
            {
                txt_Hakjung.Text = txt_lec_code8.Text;
            }
        }

        //학정번호 수동조회칸이 꽉 찼다면 체크
        private void txt_Hakjung_TextChanged(object sender, EventArgs e)
        {
            if (txt_Hakjung.TextLength == 16)
            {
                //서버에 학번, 20231+학정번호로 요청보내서 과목정보 조회
            }
            //서버로부터받은 data예제
            string test = "{\"course_info\":[{\"year\":2023,\"semester\":1,\"department\":\"H040\",\"level\":3,\"subject\":\"7737\",\"class\":1,\"course_id\":\"20231H0403773701\",\"type\":\"전선\",\"course_name\":\"UX/UI디자인\",\"credit\":3,\"instructor_name\":\"김현경\",\"num_of_students\":0,\"remaining_capacity\":2,\"time\":\"월2.수1.\",\"lect_room\":\"미지정\",\"is_foreignerOnly\":false}]}";

            //여기에 Winform 핸들러 작성
            //만석이면 만석입니다 띄워야함 txt_Hakjung.Clear();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            //서버에 학번,  20231+학정번호로 신청하기
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lvw_done.SelectedItems == null)
            {
                MessageBox.Show("수강취소할 과목을 선택하세요");
            }
            //서버에 학번,  20231+학정번호로 과목 드랍하기
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            //프로그램 종료하기
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
