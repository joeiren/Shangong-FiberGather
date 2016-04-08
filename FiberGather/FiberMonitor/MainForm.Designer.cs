namespace FiberMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cButtonEx4 = new FiberMonitor.CButtonEx();
            this.cButtonEx3 = new FiberMonitor.CButtonEx();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cButtonEx2 = new FiberMonitor.CButtonEx();
            this.cButtonEx1 = new FiberMonitor.CButtonEx();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericView1 = new FiberMonitor.NumericView();
            this.graphicalView1 = new FiberMonitor.GraphicalView();
            this.cbutton4 = new FiberMonitor.Cbutton();
            this.cbutton3 = new FiberMonitor.Cbutton();
            this.cbutton2 = new FiberMonitor.Cbutton();
            this.cbutton1 = new FiberMonitor.Cbutton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 70);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(667, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 36);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "杉工仪器";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.cButtonEx4);
            this.panel2.Controls.Add(this.cButtonEx3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.cButtonEx2);
            this.panel2.Controls.Add(this.cButtonEx1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtIP);
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Location = new System.Drawing.Point(0, 581);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 96);
            this.panel2.TabIndex = 6;
            // 
            // cButtonEx4
            // 
            this.cButtonEx4.Location = new System.Drawing.Point(539, 18);
            this.cButtonEx4.Name = "cButtonEx4";
            this.cButtonEx4.Size = new System.Drawing.Size(71, 56);
            this.cButtonEx4.TabIndex = 13;
            this.cButtonEx4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cButtonEx4_MouseClick);
            // 
            // cButtonEx3
            // 
            this.cButtonEx3.Location = new System.Drawing.Point(861, 18);
            this.cButtonEx3.Name = "cButtonEx3";
            this.cButtonEx3.Size = new System.Drawing.Size(49, 56);
            this.cButtonEx3.TabIndex = 12;
            this.cButtonEx3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cButtonEx3_MouseClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(789, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 26);
            this.button1.TabIndex = 11;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(618, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Path";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(621, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(162, 23);
            this.textBox1.TabIndex = 9;
            // 
            // cButtonEx2
            // 
            this.cButtonEx2.Location = new System.Drawing.Point(462, 18);
            this.cButtonEx2.Name = "cButtonEx2";
            this.cButtonEx2.Size = new System.Drawing.Size(71, 56);
            this.cButtonEx2.TabIndex = 8;
            this.cButtonEx2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cButtonEx2_MouseClick);
            // 
            // cButtonEx1
            // 
            this.cButtonEx1.Location = new System.Drawing.Point(376, 18);
            this.cButtonEx1.Name = "cButtonEx1";
            this.cButtonEx1.Size = new System.Drawing.Size(71, 56);
            this.cButtonEx1.TabIndex = 7;
            this.cButtonEx1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cButtonEx1_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(267, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Samples /s";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "20",
            "50",
            "100"});
            this.comboBox1.Location = new System.Drawing.Point(270, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(69, 25);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(137, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP Address";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIP.Location = new System.Drawing.Point(140, 29);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(124, 23);
            this.txtIP.TabIndex = 1;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.Location = new System.Drawing.Point(26, 29);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(43, 17);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "label3";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericView1
            // 
            this.numericView1.BackColor = System.Drawing.Color.White;
            this.numericView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericView1.Location = new System.Drawing.Point(0, 96);
            this.numericView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericView1.Name = "numericView1";
            this.numericView1.Size = new System.Drawing.Size(921, 485);
            this.numericView1.TabIndex = 7;
            // 
            // graphicalView1
            // 
            this.graphicalView1.BackColor = System.Drawing.Color.White;
            this.graphicalView1.Location = new System.Drawing.Point(0, 96);
            this.graphicalView1.Name = "graphicalView1";
            this.graphicalView1.Size = new System.Drawing.Size(921, 485);
            this.graphicalView1.TabIndex = 5;
            // 
            // cbutton4
            // 
            this.cbutton4.BackColor = System.Drawing.Color.White;
            this.cbutton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbutton4.BackgroundImage")));
            this.cbutton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbutton4.Location = new System.Drawing.Point(693, 71);
            this.cbutton4.Name = "cbutton4";
            this.cbutton4.Size = new System.Drawing.Size(230, 25);
            this.cbutton4.TabIndex = 4;
            // 
            // cbutton3
            // 
            this.cbutton3.BackColor = System.Drawing.Color.White;
            this.cbutton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbutton3.BackgroundImage")));
            this.cbutton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbutton3.Location = new System.Drawing.Point(462, 71);
            this.cbutton3.Name = "cbutton3";
            this.cbutton3.Size = new System.Drawing.Size(230, 25);
            this.cbutton3.TabIndex = 3;
            // 
            // cbutton2
            // 
            this.cbutton2.BackColor = System.Drawing.Color.White;
            this.cbutton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbutton2.BackgroundImage")));
            this.cbutton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbutton2.Location = new System.Drawing.Point(231, 71);
            this.cbutton2.Name = "cbutton2";
            this.cbutton2.Size = new System.Drawing.Size(230, 25);
            this.cbutton2.TabIndex = 2;
            // 
            // cbutton1
            // 
            this.cbutton1.BackColor = System.Drawing.Color.White;
            this.cbutton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbutton1.BackgroundImage")));
            this.cbutton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbutton1.Location = new System.Drawing.Point(0, 71);
            this.cbutton1.Name = "cbutton1";
            this.cbutton1.Size = new System.Drawing.Size(230, 25);
            this.cbutton1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 677);
            this.Controls.Add(this.numericView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.graphicalView1);
            this.Controls.Add(this.cbutton4);
            this.Controls.Add(this.cbutton3);
            this.Controls.Add(this.cbutton2);
            this.Controls.Add(this.cbutton1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "光纤光栅解调仪";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Cbutton cbutton1;
        private Cbutton cbutton2;
        private Cbutton cbutton3;
        private Cbutton cbutton4;
        public GraphicalView graphicalView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private CButtonEx cButtonEx1;
        private CButtonEx cButtonEx2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private CButtonEx cButtonEx3;
        private CButtonEx cButtonEx4;
        public NumericView numericView1;
    }
}

