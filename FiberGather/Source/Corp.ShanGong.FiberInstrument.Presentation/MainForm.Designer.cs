namespace Corp.ShanGong.FiberInstrument.Presentation
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
            this.listViewQuantity = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.textBoxLocalPort = new System.Windows.Forms.TextBox();
            this.labelLocal = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxRemotePort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxRemote = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.groupBoxSave = new System.Windows.Forms.GroupBox();
            this.textBoxSendRemotePort = new System.Windows.Forms.TextBox();
            this.labelSendPort = new System.Windows.Forms.Label();
            this.textBoxSendRemoteIp = new System.Windows.Forms.TextBox();
            this.labelSendIp = new System.Windows.Forms.Label();
            this.checkBoxSendData = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableSaveDB = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableSaveLocal = new System.Windows.Forms.CheckBox();
            this.buttonBrowser = new System.Windows.Forms.Button();
            this.textBoxDataFileLocalPath = new System.Windows.Forms.TextBox();
            this.labelLocalPath = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.groupBoxSetting.SuspendLayout();
            this.groupBoxSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewQuantity
            // 
            this.listViewQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewQuantity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewQuantity.GridLines = true;
            this.listViewQuantity.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewQuantity.Location = new System.Drawing.Point(5, 200);
            this.listViewQuantity.Name = "listViewQuantity";
            this.listViewQuantity.Size = new System.Drawing.Size(1003, 337);
            this.listViewQuantity.TabIndex = 30;
            this.listViewQuantity.UseCompatibleStateImageBehavior = false;
            this.listViewQuantity.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "传感器序号";
            this.columnHeader0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader0.Width = 72;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "CH1";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CH2";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CH3";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CH4";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "CH5";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "CH6";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "CH7";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "CH8";
            this.columnHeader8.Width = 100;
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSetting.Controls.Add(this.textBoxLocalPort);
            this.groupBoxSetting.Controls.Add(this.labelLocal);
            this.groupBoxSetting.Controls.Add(this.buttonStart);
            this.groupBoxSetting.Controls.Add(this.buttonConnect);
            this.groupBoxSetting.Controls.Add(this.textBoxRemotePort);
            this.groupBoxSetting.Controls.Add(this.labelPort);
            this.groupBoxSetting.Controls.Add(this.textBoxRemote);
            this.groupBoxSetting.Controls.Add(this.labelServer);
            this.groupBoxSetting.Location = new System.Drawing.Point(3, 12);
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size(1003, 82);
            this.groupBoxSetting.TabIndex = 1;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "基本配置";
            // 
            // textBoxLocalPort
            // 
            this.textBoxLocalPort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxLocalPort.Location = new System.Drawing.Point(103, 59);
            this.textBoxLocalPort.MaxLength = 16;
            this.textBoxLocalPort.Name = "textBoxLocalPort";
            this.textBoxLocalPort.Size = new System.Drawing.Size(35, 21);
            this.textBoxLocalPort.TabIndex = 3;
            this.textBoxLocalPort.Text = "8001";
            // 
            // labelLocal
            // 
            this.labelLocal.AutoSize = true;
            this.labelLocal.Location = new System.Drawing.Point(6, 63);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(77, 12);
            this.labelLocal.TabIndex = 6;
            this.labelLocal.Text = "本机连接端口";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(405, 18);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 58);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "启动";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(311, 18);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 58);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "测试连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxRemotePort
            // 
            this.textBoxRemotePort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxRemotePort.Location = new System.Drawing.Point(260, 21);
            this.textBoxRemotePort.MaxLength = 16;
            this.textBoxRemotePort.Name = "textBoxRemotePort";
            this.textBoxRemotePort.ReadOnly = true;
            this.textBoxRemotePort.Size = new System.Drawing.Size(35, 21);
            this.textBoxRemotePort.TabIndex = 2;
            this.textBoxRemotePort.Text = "4567";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(225, 24);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 12);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "端口";
            // 
            // textBoxRemote
            // 
            this.textBoxRemote.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxRemote.Location = new System.Drawing.Point(103, 21);
            this.textBoxRemote.MaxLength = 16;
            this.textBoxRemote.Name = "textBoxRemote";
            this.textBoxRemote.ReadOnly = true;
            this.textBoxRemote.Size = new System.Drawing.Size(92, 21);
            this.textBoxRemote.TabIndex = 1;
            this.textBoxRemote.Text = "192.168.0.19";
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(8, 24);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(89, 12);
            this.labelServer.TabIndex = 0;
            this.labelServer.Text = "解调仪服务器IP";
            // 
            // groupBoxSave
            // 
            this.groupBoxSave.Controls.Add(this.textBoxSendRemotePort);
            this.groupBoxSave.Controls.Add(this.labelSendPort);
            this.groupBoxSave.Controls.Add(this.textBoxSendRemoteIp);
            this.groupBoxSave.Controls.Add(this.labelSendIp);
            this.groupBoxSave.Controls.Add(this.checkBoxSendData);
            this.groupBoxSave.Controls.Add(this.checkBoxEnableSaveDB);
            this.groupBoxSave.Controls.Add(this.checkBoxEnableSaveLocal);
            this.groupBoxSave.Controls.Add(this.buttonBrowser);
            this.groupBoxSave.Controls.Add(this.textBoxDataFileLocalPath);
            this.groupBoxSave.Controls.Add(this.labelLocalPath);
            this.groupBoxSave.Location = new System.Drawing.Point(3, 100);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(1003, 94);
            this.groupBoxSave.TabIndex = 2;
            this.groupBoxSave.TabStop = false;
            this.groupBoxSave.Text = "保存配置";
            // 
            // textBoxSendRemotePort
            // 
            this.textBoxSendRemotePort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxSendRemotePort.Location = new System.Drawing.Point(341, 59);
            this.textBoxSendRemotePort.MaxLength = 16;
            this.textBoxSendRemotePort.Name = "textBoxSendRemotePort";
            this.textBoxSendRemotePort.Size = new System.Drawing.Size(35, 21);
            this.textBoxSendRemotePort.TabIndex = 11;
            this.textBoxSendRemotePort.Text = "9000";
            this.textBoxSendRemotePort.Visible = false;
            // 
            // labelSendPort
            // 
            this.labelSendPort.AutoSize = true;
            this.labelSendPort.Location = new System.Drawing.Point(306, 62);
            this.labelSendPort.Name = "labelSendPort";
            this.labelSendPort.Size = new System.Drawing.Size(29, 12);
            this.labelSendPort.TabIndex = 16;
            this.labelSendPort.Text = "端口";
            this.labelSendPort.Visible = false;
            // 
            // textBoxSendRemoteIp
            // 
            this.textBoxSendRemoteIp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxSendRemoteIp.Location = new System.Drawing.Point(184, 59);
            this.textBoxSendRemoteIp.MaxLength = 16;
            this.textBoxSendRemoteIp.Name = "textBoxSendRemoteIp";
            this.textBoxSendRemoteIp.Size = new System.Drawing.Size(92, 21);
            this.textBoxSendRemoteIp.TabIndex = 10;
            this.textBoxSendRemoteIp.Text = "192.168.0.19";
            this.textBoxSendRemoteIp.Visible = false;
            // 
            // labelSendIp
            // 
            this.labelSendIp.AutoSize = true;
            this.labelSendIp.Location = new System.Drawing.Point(113, 64);
            this.labelSendIp.Name = "labelSendIp";
            this.labelSendIp.Size = new System.Drawing.Size(65, 12);
            this.labelSendIp.TabIndex = 14;
            this.labelSendIp.Text = "数据接收IP";
            this.labelSendIp.Visible = false;
            // 
            // checkBoxSendData
            // 
            this.checkBoxSendData.AutoSize = true;
            this.checkBoxSendData.Location = new System.Drawing.Point(10, 64);
            this.checkBoxSendData.Name = "checkBoxSendData";
            this.checkBoxSendData.Size = new System.Drawing.Size(96, 16);
            this.checkBoxSendData.TabIndex = 9;
            this.checkBoxSendData.Text = "启用数据发送";
            this.checkBoxSendData.UseVisualStyleBackColor = true;
            this.checkBoxSendData.CheckedChanged += new System.EventHandler(this.checkBoxSendData_CheckedChanged);
            // 
            // checkBoxEnableSaveDB
            // 
            this.checkBoxEnableSaveDB.AutoSize = true;
            this.checkBoxEnableSaveDB.Location = new System.Drawing.Point(497, 25);
            this.checkBoxEnableSaveDB.Name = "checkBoxEnableSaveDB";
            this.checkBoxEnableSaveDB.Size = new System.Drawing.Size(108, 16);
            this.checkBoxEnableSaveDB.TabIndex = 12;
            this.checkBoxEnableSaveDB.Text = "启用数据库保存";
            this.checkBoxEnableSaveDB.UseVisualStyleBackColor = true;
            this.checkBoxEnableSaveDB.Visible = false;
            // 
            // checkBoxEnableSaveLocal
            // 
            this.checkBoxEnableSaveLocal.AutoSize = true;
            this.checkBoxEnableSaveLocal.Location = new System.Drawing.Point(10, 25);
            this.checkBoxEnableSaveLocal.Name = "checkBoxEnableSaveLocal";
            this.checkBoxEnableSaveLocal.Size = new System.Drawing.Size(96, 16);
            this.checkBoxEnableSaveLocal.TabIndex = 6;
            this.checkBoxEnableSaveLocal.Text = "启用本地保存";
            this.checkBoxEnableSaveLocal.UseVisualStyleBackColor = true;
            this.checkBoxEnableSaveLocal.CheckedChanged += new System.EventHandler(this.checkBoxEnableSaveLocal_CheckedChanged);
            // 
            // buttonBrowser
            // 
            this.buttonBrowser.Location = new System.Drawing.Point(407, 20);
            this.buttonBrowser.Name = "buttonBrowser";
            this.buttonBrowser.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowser.TabIndex = 8;
            this.buttonBrowser.Text = "浏览...";
            this.buttonBrowser.UseVisualStyleBackColor = true;
            this.buttonBrowser.Visible = false;
            this.buttonBrowser.Click += new System.EventHandler(this.buttonBrowser_Click);
            // 
            // textBoxDataFileLocalPath
            // 
            this.textBoxDataFileLocalPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxDataFileLocalPath.Location = new System.Drawing.Point(184, 21);
            this.textBoxDataFileLocalPath.Name = "textBoxDataFileLocalPath";
            this.textBoxDataFileLocalPath.ReadOnly = true;
            this.textBoxDataFileLocalPath.Size = new System.Drawing.Size(224, 21);
            this.textBoxDataFileLocalPath.TabIndex = 7;
            this.textBoxDataFileLocalPath.Text = "D:\\";
            this.textBoxDataFileLocalPath.Visible = false;
            // 
            // labelLocalPath
            // 
            this.labelLocalPath.AutoSize = true;
            this.labelLocalPath.Location = new System.Drawing.Point(112, 26);
            this.labelLocalPath.Name = "labelLocalPath";
            this.labelLocalPath.Size = new System.Drawing.Size(77, 12);
            this.labelLocalPath.TabIndex = 7;
            this.labelLocalPath.Text = "本机保存路径";
            this.labelLocalPath.Visible = false;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.BackColor = System.Drawing.Color.LightBlue;
            this.textBoxLog.Location = new System.Drawing.Point(3, 543);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(1003, 185);
            this.textBoxLog.TabIndex = 31;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 724);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBoxSave);
            this.Controls.Add(this.groupBoxSetting);
            this.Controls.Add(this.listViewQuantity);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "光纤光栅解调仪";
            this.groupBoxSetting.ResumeLayout(false);
            this.groupBoxSetting.PerformLayout();
            this.groupBoxSave.ResumeLayout(false);
            this.groupBoxSave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewQuantity;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        private System.Windows.Forms.TextBox textBoxRemote;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxRemotePort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelLocal;
        private System.Windows.Forms.TextBox textBoxLocalPort;
        private System.Windows.Forms.GroupBox groupBoxSave;
        private System.Windows.Forms.CheckBox checkBoxEnableSaveDB;
        private System.Windows.Forms.CheckBox checkBoxEnableSaveLocal;
        private System.Windows.Forms.Button buttonBrowser;
        private System.Windows.Forms.TextBox textBoxDataFileLocalPath;
        private System.Windows.Forms.Label labelLocalPath;
        private System.Windows.Forms.TextBox textBoxSendRemotePort;
        private System.Windows.Forms.Label labelSendPort;
        private System.Windows.Forms.TextBox textBoxSendRemoteIp;
        private System.Windows.Forms.Label labelSendIp;
        private System.Windows.Forms.CheckBox checkBoxSendData;
        private System.Windows.Forms.TextBox textBoxLog;

    }
}

