using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2023AppSWClient
{
    public partial class Form1 : Form
    {
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

        private void btn_SearchCourse_Click(object sender, EventArgs e)
        {
            /*
             * cbbox_collegeof
             * cbbox_department
             * cbbox_lecttype
             * txt_subject
             * chk_onlyvalid (여석있는것만조회할지?)
             * 이거 5개 묶어서 서버에 패킷으로 쏘는 핸들러 필요
             */
            /*
             * 패킷으로부터 결과 받아오면
             * lvw_search_res 작성필요
             */
        }

        private void btn_AddToFav_Click(object sender, EventArgs e)
        {
            /*
             cbbox_favnum(즐겨찾기번호)
            밑에 lev_search_res 선택된과목 즐겨찾기 추가하는거 필요
            패킷으로 학번+즐겨찾기순서+학정번호 추가요청 보내고
            txt_lec_codeN    txt_lec_nameN   txt_credN   txt_profN   txt_lectN(강의시간)
            요 5개 채우기
            */
        }

        private void btn_delN_Click(object sender, EventArgs e)
        {
            /*
             * 몇번버튼이 눌렸는지에 따라서 핸들링 필요
             * 삭제하시겠습니까? 메시지띄우고
             * 서버에 삭제요청 보내고
             * txt_lec_codeN    txt_lec_nameN   txt_credN   txt_profN   txt_lectN(강의시간)
             * 요 5개 텍스트 비우기
             */
            Button whichPushed = (Button) sender;
            if(whichPushed== btn_del1)
            {
                
            }
            else if (whichPushed == btn_del2)
            {

            }
            else if (whichPushed == btn_del3)
            {

            }
            else if (whichPushed == btn_del4)
            {

            }
            else if (whichPushed == btn_del5)
            {

            }
            else if (whichPushed == btn_del6)
            {

            }
            else if (whichPushed == btn_del7)
            {

            }
            else if (whichPushed == btn_del8)
            {

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

            }
            else if (whichPushed == btn_inq2)
            {

            }
            else if (whichPushed == btn_inq3)
            {

            }
            else if (whichPushed == btn_inq4)
            {

            }
            else if (whichPushed == btn_inq5)
            {

            }
            else if (whichPushed == btn_inq6)
            {

            }
            else if (whichPushed == btn_inq7)
            {

            }
            else if (whichPushed == btn_inq8)
            {

            }
        }

        //학정번호 수동조회칸이 꽉 찼다면 체크
        private void txt_Hakjung_TextChanged(object sender, EventArgs e)
        {
            if (txt_Hakjung.TextLength == 11)
            {
                //서버에 학번, 20231+학정번호로 요청보내서 과목정보 조회
                //과목 남았으면 과목명 이수구분 시간 강의실... 등 띄우기
                //만석이면 만석입니다 띄우고 txt_Hakjung.Clear();
            }
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
    }
}
