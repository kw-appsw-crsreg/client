namespace Login_form
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pic_kw = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.txt_Psw = new System.Windows.Forms.TextBox();
            this.btn_log = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_kw)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_kw
            // 
            this.pic_kw.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic_kw.Image = global::Login_form.Properties.Resources.kw_picture;
            this.pic_kw.Location = new System.Drawing.Point(0, 0);
            this.pic_kw.Name = "pic_kw";
            this.pic_kw.Size = new System.Drawing.Size(800, 295);
            this.pic_kw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_kw.TabIndex = 0;
            this.pic_kw.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "학번 입력";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "비밀번호 입력";
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(289, 344);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(162, 21);
            this.txt_Id.TabIndex = 3;
            // 
            // txt_Psw
            // 
            this.txt_Psw.Location = new System.Drawing.Point(289, 378);
            this.txt_Psw.Name = "txt_Psw";
            this.txt_Psw.Size = new System.Drawing.Size(162, 21);
            this.txt_Psw.TabIndex = 4;
            // 
            // btn_log
            // 
            this.btn_log.BackColor = System.Drawing.Color.Red;
            this.btn_log.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_log.ImageIndex = 0;
            this.btn_log.Location = new System.Drawing.Point(489, 344);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(61, 52);
            this.btn_log.TabIndex = 5;
            this.btn_log.Text = "Login";
            this.btn_log.UseVisualStyleBackColor = false;
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Red;
            this.btn_logout.Location = new System.Drawing.Point(573, 344);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(66, 55);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.txt_Psw);
            this.Controls.Add(this.txt_Id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic_kw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_kw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_kw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.TextBox txt_Psw;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.Button btn_logout;
    }
}

