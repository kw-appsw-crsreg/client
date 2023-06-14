using AppswPacket;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace _2023AppSWClient
{
    public partial class Form1 : Form
    {

        List<string> CollegeOfEI = new List<string>(new string[] {
            "전자공학과","전자통신공학과","전자융합공학과","전기공학과","전자재료공학과","로봇학부"," 컴퓨터공학과","컴퓨터소프트웨어학과", "전체검색", "공통"
            });
        List<string> CollegeofBusiness = new List<string>(new string[] {
            "경영학부","국제통상학부", "전체검색", "공통"
            });
        List<string> CollegeOfEngineering = new List<string>(new string[] {
            "건축공학과","화학공학과","환경공학과","건축학과", "전체검색", "공통"
            });
        List<string> CollegeOfSoftwareConversion = new List<string>(new string[] {
            "컴퓨터정보공학부","소프트웨어학부","정보융합학부", "전체검색", "공통"
            });
        List<string> CollegeOfHumanities = new List<string>(new string[] {
            "국어국문학과","영어산업학과","미디어커뮤니케이션학부","산업심리학과","동북아문화산업학부", "전체검색", "공통"
            });
        List<string> CollegeOfNatural = new List<string>(new string[] {
            "수학과","전자바이오물리학과","화학과","스포츠융합과학과","정보콘텐츠학과", "전체검색", "공통"
            });
        List<string> CollegeOfLaw = new List<string>(new string[] {
            "행정학과","법학부","국제학부","자산관리학과", "전체검색", "공통"
            });

        Packet packcet;
        Login userInfo;


        public Form1(Login login)
        {
            packcet = Connection.pac;
            InitializeComponent();
            userInfo = login; //로그인폼으로부터 넘어온 사용자정보

            string json = userInfo.ds;
            DataSet ds = JsonConvert.DeserializeObject<DataSet>(json);

            DataTable studentInfo = ds.Tables["student_info"];
            DataTable favoritesList = ds.Tables["favorites_list"];
            DataTable registeredList = ds.Tables["registered_list"];

            txt_StuName.Text = studentInfo.Rows[0]["name"].ToString();

            foreach (DataRow row in favoritesList.Rows)
            {
                int idx = Convert.ToInt32(row["idx"]);
                string courseName = row["course_name"].ToString();
                string courseID = row["course_id"].ToString();
                int credit = Convert.ToInt32(row["credit"]);
                string instructorName = row["instructor_Name"].ToString();
                string time = row["time"].ToString();

                if (idx == 1)
                {
                    txt_lec_code1.Text = courseID;
                    txt_lec_name1.Text = courseName;
                    txt_cred1.Text = credit.ToString();
                    txt_prof1.Text = instructorName;
                    txt_lect1.Text = time;
                }
                else if (idx == 2)
                {
                    txt_lec_code2.Text = courseID;
                    txt_lec_name2.Text = courseName;
                    txt_cred2.Text = credit.ToString();
                    txt_prof2.Text = instructorName;
                    txt_lect2.Text = time;
                }
                else if (idx == 3)
                {
                    txt_lec_code3.Text = courseID;
                    txt_lec_name3.Text = courseName;
                    txt_cred3.Text = credit.ToString();
                    txt_prof3.Text = instructorName;
                    txt_lect3.Text = time;
                }
                else if (idx == 4)
                {
                    txt_lec_code4.Text = courseID;
                    txt_lec_name4.Text = courseName;
                    txt_cred4.Text = credit.ToString();
                    txt_prof4.Text = instructorName;
                    txt_lect4.Text = time;
                }
                else if (idx == 5)
                {
                    txt_lec_code5.Text = courseID;
                    txt_lec_name5.Text = courseName;
                    txt_cred5.Text = credit.ToString();
                    txt_prof5.Text = instructorName;
                    txt_lect5.Text = time;
                }
                else if (idx == 6)
                {
                    txt_lec_code6.Text = courseID;
                    txt_lec_name6.Text = courseName;
                    txt_cred6.Text = credit.ToString();
                    txt_prof6.Text = instructorName;
                    txt_lect6.Text = time;
                }
                else if (idx == 7)
                {
                    txt_lec_code7.Text = courseID;
                    txt_lec_name7.Text = courseName;
                    txt_cred7.Text = credit.ToString();
                    txt_prof7.Text = instructorName;
                    txt_lect7.Text = time;
                }
                else if (idx == 8)
                {
                    txt_lec_code8.Text = courseID;
                    txt_lec_name8.Text = courseName;
                    txt_cred8.Text = credit.ToString();
                    txt_prof8.Text = instructorName;
                    txt_lect8.Text = time;
                }
            }

            foreach (DataRow row in registeredList.Rows)
            {
                string courseID = row["course_id"].ToString();
                string type = row["type"].ToString();
                string courseName = row["course_name"].ToString();
                string credit = row["credit"].ToString();
                string instructorName = row["instructor_name"].ToString();
                string time = row["time"].ToString();
                string lectRoom = row["lect_room"].ToString();

                var listViewItem = new ListViewItem(courseID);
                listViewItem.SubItems.Add(type);
                listViewItem.SubItems.Add(courseName);
                listViewItem.SubItems.Add(credit);
                listViewItem.SubItems.Add(instructorName); 
                listViewItem.SubItems.Add(time);
                listViewItem.SubItems.Add(lectRoom);

                lvw_done.Items.Add(listViewItem);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            lvw_search_res.View = View.Details;
            lvw_done.View = View.Details;

            //사용자정보 추가
            userInfo.stuID = "12333333";
            txt_StuID.Text = userInfo.stuID;

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
            lvw_done.Columns.Add("요일", "요일");
            lvw_done.Columns.Add("시간", "시간");
            lvw_done.Columns.Add("강의실", "강의실");
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

            //즐겨찾기 번호추가
            for (int i = 1; i <= 8; i++)
            {
                cbBox_FavNum.Items.Add(i);
            }
            List<string> Departments = new List<string>(new string[] {
            "경영대학", "공과대학", "소프트웨어융합대학", "인문사회과학대학", "자연과학대학", "전자정보공과대학", "정책법학대학", "전체검색", "공통"
            });
            foreach(string str in Departments) cbBox_CollegeOf.Items.Add(str);
            //단과대선택 아이템추가
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
            System.Data.DataSet dataSet = DatasetConvertor.DeserializeFromJSON(sourceJson);
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
            int index = (int)cbBox_FavNum.SelectedItem;

            ListViewItem selectedItem = lvw_search_res.SelectedItems.Cast<ListViewItem>().FirstOrDefault();

            if (selectedItem != null)
            {
                int favRes= (int)FavoritesResult.OK;
                // 여기에 패킷 추가(서버에 즐겨찾기 추가)!!!!!!)!!!!!!)!!!!!!)!!!!!!)!!!!!!
                if (favRes != (int)FavoritesResult.OK)
                {
                    MessageBox.Show("오류!!");
                }
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
                MessageBox.Show("즐겨찾기에 추가할 과목을 선택하세요!");
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
            Button whichPushed = (Button)sender;
            if (whichPushed == btn_del1)
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
        public class CourseInfo
        {
            public int Year { get; set; }
            public int Semester { get; set; }
            public string Department { get; set; }
            public int Level { get; set; }
            public string Subject { get; set; }
            public int Class { get; set; }
            public string CourseId { get; set; }
            public string Type { get; set; }
            public string CourseName { get; set; }
            public int Credit { get; set; }
            public string InstructorName { get; set; }
            public int NumOfStudents { get; set; }
            public int RemainingCapacity { get; set; }
            public string Time { get; set; }
            public string LectRoom { get; set; }
            public bool IsForeignerOnly { get; set; }
        }

        //학정번호 수동조회칸이 꽉 찼다면 체크
        private void txt_Hakjung_TextChanged(object sender, EventArgs e)
        {
            string search_res; // 검색결과 저장할 string
            string test = "{\"course_info\":[{\"year\":2023,\"semester\":1,\"department\":\"H040\",\"level\":3,\"subject\":\"7737\",\"class\":1,\"course_id\":\"20231H0403773701\",\"type\":\"전선\",\"course_name\":\"UX/UI디자인\",\"credit\":3,\"instructor_name\":\"김현경\",\"num_of_students\":0,\"remaining_capacity\":3,\"time\":\"월2.수1.\",\"lect_room\":\"미지정\",\"is_foreignerOnly\":false}]}";

            if (txt_Hakjung.TextLength == 16)
            {
                //서버에 학번, 20231+학정번호로 요청보내서 과목정보 조회

                //서버로부터받은 data예제

                DataSet classinfo = DatasetConvertor.DeserializeFromJSON(test);

                txt_Hakjung.Text = classinfo.Tables[0].Rows[0]["course_id"].ToString();
                txt_CourseName.Text = classinfo.Tables[0].Rows[0]["course_name"].ToString();
                txt_CourseType.Text = classinfo.Tables[0].Rows[0]["type"].ToString();
                txt_CourseCredit.Text = classinfo.Tables[0].Rows[0]["credit"].ToString();
                txt_InstructorName.Text = classinfo.Tables[0].Rows[0]["instructor_name"].ToString();
                txt_CourseTime.Text = classinfo.Tables[0].Rows[0]["course_name"].ToString();
                txt_CourseLectRoom.Text = classinfo.Tables[0].Rows[0]["lect_room"].ToString();

                if (int.Parse(classinfo.Tables[0].Rows[0]["remaining_capacity"].ToString()) == 0)
                {
                    MessageBox.Show("만석입니다!");
                    txt_Hakjung.Clear();
                    txt_CourseName.Clear();
                    txt_CourseType.Clear();
                    txt_CourseCredit.Clear();
                    txt_InstructorName.Clear();
                    txt_CourseTime.Clear();
                    txt_CourseLectRoom.Clear();
                }
            }
            
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            //서버에 학번,  20231+학정번호로 신청하기

            if (true)
            {
                txt_Hakjung.Clear();
                txt_CourseName.Clear();
                txt_CourseType.Clear();
                txt_CourseCredit.Clear();
                txt_InstructorName.Clear();
                txt_CourseTime.Clear();
                txt_CourseLectRoom.Clear();
            }
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
            this.Close();
        }

        private void wait()
        {
            while (Connection.stack.Count == 0)
            {
                continue;
            }
        }

        private void cbBox_CollegeOf_SelectedIndexChanged(object sender, EventArgs e)
        {
            string what=(string)cbBox_CollegeOf.SelectedItem;
            cbBox_Department.Items.Clear();
            cbBox_Department.ResetText();
            switch (what)
            {
                case "경영대학":
                    foreach(string str in CollegeofBusiness) cbBox_Department.Items.Add(str);
                    break;
                case "공과대학":
                    foreach (string str in CollegeOfEngineering) cbBox_Department.Items.Add(str);
                    break;
                case "소프트웨어융합대학":
                    foreach (string str in CollegeOfSoftwareConversion) cbBox_Department.Items.Add(str);
                    break;
                case "인문사회과학대학":
                    foreach (string str in CollegeOfHumanities) cbBox_Department.Items.Add(str);
                    break;
                case "자연과학대학":
                    foreach (string str in CollegeOfNatural) cbBox_Department.Items.Add(str);
                    break;
                case "전자정보공과대학":
                    foreach (string str in CollegeOfEI) cbBox_Department.Items.Add(str);
                    break;
                case "정책법학대학":
                    foreach (string str in CollegeOfLaw) cbBox_Department.Items.Add(str);
                    break;
                case "전체검색" :
                case "공통":
                    break;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.AbortThread();
        }
    }
}
