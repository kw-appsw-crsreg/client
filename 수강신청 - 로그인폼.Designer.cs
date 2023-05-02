namespace WindowsFormsApp_Login
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
            this.lb_2 = new System.Windows.Forms.Label();
            this.txt_Psw = new System.Windows.Forms.TextBox();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_log = new System.Windows.Forms.Button();
            this.pic_kw = new System.Windows.Forms.PictureBox();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.lb_1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_kw)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_2
            // 
            this.lb_2.AutoSize = true;
            this.lb_2.Location = new System.Drawing.Point(174, 363);
            this.lb_2.Name = "lb_2";
            this.lb_2.Size = new System.Drawing.Size(81, 12);
            this.lb_2.TabIndex = 3;
            this.lb_2.Text = "비밀번호 입력";
            // 
            // txt_Psw
            // 
            this.txt_Psw.Location = new System.Drawing.Point(306, 358);
            this.txt_Psw.Name = "txt_Psw";
            this.txt_Psw.PasswordChar = '*';
            this.txt_Psw.Size = new System.Drawing.Size(170, 21);
            this.txt_Psw.TabIndex = 4;
            this.txt_Psw.TextChanged += new System.EventHandler(this.txt_Psw_TextChanged);
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Red;
            this.btn_logout.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_logout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_logout.Location = new System.Drawing.Point(576, 324);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(59, 55);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            // 
            // btn_log
            // 
            this.btn_log.BackColor = System.Drawing.Color.Red;
            this.btn_log.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_log.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_log.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_log.Location = new System.Drawing.Point(502, 324);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(58, 55);
            this.btn_log.TabIndex = 5;
            this.btn_log.Text = "Login";
            this.btn_log.UseCompatibleTextRendering = true;
            this.btn_log.UseVisualStyleBackColor = false;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // pic_kw
            // 
            this.pic_kw.Image = global::WindowsFormsApp_Login.Properties.Resources.kw_picture1;
            this.pic_kw.Location = new System.Drawing.Point(1, 0);
            this.pic_kw.Name = "pic_kw";
            this.pic_kw.Size = new System.Drawing.Size(798, 318);
            this.pic_kw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_kw.TabIndex = 0;
            this.pic_kw.TabStop = false;
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(306, 328);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(170, 21);
            this.txt_Id.TabIndex = 7;
            this.txt_Id.TextChanged += new System.EventHandler(this.txt_Id_TextChanged);
            // 
            // lb_1
            // 
            this.lb_1.AutoSize = true;
            this.lb_1.Location = new System.Drawing.Point(184, 336);
            this.lb_1.Name = "lb_1";
            this.lb_1.Size = new System.Drawing.Size(57, 12);
            this.lb_1.TabIndex = 8;
            this.lb_1.Text = "학번 입력";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_1);
            this.Controls.Add(this.txt_Id);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.txt_Psw);
            this.Controls.Add(this.lb_2);
            this.Controls.Add(this.pic_kw);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic_kw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_kw;
        private System.Windows.Forms.Label lb_2;
        private System.Windows.Forms.TextBox txt_Psw;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.Label lb_1;
    }
}

