namespace Corp.ShanGong.FiberInstrument.Presentation
{
    partial class FiberMainForm
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
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.checkBoxDebugMode = new System.Windows.Forms.CheckBox();
            this.labelCollectInterval = new System.Windows.Forms.Label();
            this.numUDCollect = new System.Windows.Forms.NumericUpDown();
            this.textBoxLocalPort = new System.Windows.Forms.TextBox();
            this.labelLocal = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxRemotePort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxRemote = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.groupBoxSave = new System.Windows.Forms.GroupBox();
            this.labelDbSaveInterval = new System.Windows.Forms.Label();
            this.numUDDbSaveInterval = new System.Windows.Forms.NumericUpDown();
            this.labelDbConfig = new System.Windows.Forms.Label();
            this.textBoxDbConfigString = new System.Windows.Forms.TextBox();
            this.labelSendInterval = new System.Windows.Forms.Label();
            this.numUDNetSendInterval = new System.Windows.Forms.NumericUpDown();
            this.labelLocalSaveInterval = new System.Windows.Forms.Label();
            this.numUDLocalSaveInterval = new System.Windows.Forms.NumericUpDown();
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
            this.tabPageAdChart = new System.Windows.Forms.TabPage();
            this.plotViewAdChart = new OxyPlot.WindowsForms.PlotView();
            this.tabPageWave = new System.Windows.Forms.TabPage();
            this.listViewQuantity = new System.Windows.Forms.ListView();
            this.tabControlMonitor = new System.Windows.Forms.TabControl();
            this.groupBoxSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDCollect)).BeginInit();
            this.groupBoxSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDDbSaveInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNetSendInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLocalSaveInterval)).BeginInit();
            this.tabPageAdChart.SuspendLayout();
            this.tabPageWave.SuspendLayout();
            this.tabControlMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSetting.Controls.Add(this.comboBoxChannel);
            this.groupBoxSetting.Controls.Add(this.checkBoxDebugMode);
            this.groupBoxSetting.Controls.Add(this.labelCollectInterval);
            this.groupBoxSetting.Controls.Add(this.numUDCollect);
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
            this.groupBoxSetting.Size = new System.Drawing.Size(1174, 58);
            this.groupBoxSetting.TabIndex = 1;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "基本配置";
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(716, 17);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(80, 20);
            this.comboBoxChannel.TabIndex = 23;
            this.comboBoxChannel.Visible = false;
            this.comboBoxChannel.SelectedIndexChanged += new System.EventHandler(this.comboBoxChannel_SelectedIndexChanged);
            // 
            // checkBoxDebugMode
            // 
            this.checkBoxDebugMode.AutoSize = true;
            this.checkBoxDebugMode.Location = new System.Drawing.Point(614, 21);
            this.checkBoxDebugMode.Name = "checkBoxDebugMode";
            this.checkBoxDebugMode.Size = new System.Drawing.Size(96, 16);
            this.checkBoxDebugMode.TabIndex = 9;
            this.checkBoxDebugMode.Text = "光谱调试模式";
            this.checkBoxDebugMode.UseVisualStyleBackColor = true;
            this.checkBoxDebugMode.CheckedChanged += new System.EventHandler(this.checkBoxDebugMode_CheckedChanged);
            // 
            // labelCollectInterval
            // 
            this.labelCollectInterval.AutoSize = true;
            this.labelCollectInterval.Location = new System.Drawing.Point(449, 23);
            this.labelCollectInterval.Name = "labelCollectInterval";
            this.labelCollectInterval.Size = new System.Drawing.Size(53, 12);
            this.labelCollectInterval.TabIndex = 8;
            this.labelCollectInterval.Text = "采样间隔";
            // 
            // numUDCollect
            // 
            this.numUDCollect.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDCollect.Location = new System.Drawing.Point(508, 20);
            this.numUDCollect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDCollect.Name = "numUDCollect";
            this.numUDCollect.Size = new System.Drawing.Size(62, 21);
            this.numUDCollect.TabIndex = 7;
            this.numUDCollect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUDCollect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDCollect.ValueChanged += new System.EventHandler(this.numUD_ValueChanged);
            // 
            // textBoxLocalPort
            // 
            this.textBoxLocalPort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxLocalPort.Location = new System.Drawing.Point(409, 21);
            this.textBoxLocalPort.MaxLength = 16;
            this.textBoxLocalPort.Name = "textBoxLocalPort";
            this.textBoxLocalPort.Size = new System.Drawing.Size(35, 21);
            this.textBoxLocalPort.TabIndex = 3;
            this.textBoxLocalPort.Text = "8001";
            // 
            // labelLocal
            // 
            this.labelLocal.AutoSize = true;
            this.labelLocal.Location = new System.Drawing.Point(312, 25);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(77, 12);
            this.labelLocal.TabIndex = 6;
            this.labelLocal.Text = "本机连接端口";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(1066, 13);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 31);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "启动";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(985, 13);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 33);
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
            this.groupBoxSave.Controls.Add(this.labelDbSaveInterval);
            this.groupBoxSave.Controls.Add(this.numUDDbSaveInterval);
            this.groupBoxSave.Controls.Add(this.labelDbConfig);
            this.groupBoxSave.Controls.Add(this.textBoxDbConfigString);
            this.groupBoxSave.Controls.Add(this.labelSendInterval);
            this.groupBoxSave.Controls.Add(this.numUDNetSendInterval);
            this.groupBoxSave.Controls.Add(this.labelLocalSaveInterval);
            this.groupBoxSave.Controls.Add(this.numUDLocalSaveInterval);
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
            this.groupBoxSave.Location = new System.Drawing.Point(8, 72);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(1136, 129);
            this.groupBoxSave.TabIndex = 2;
            this.groupBoxSave.TabStop = false;
            this.groupBoxSave.Text = "保存配置";
            // 
            // labelDbSaveInterval
            // 
            this.labelDbSaveInterval.AutoSize = true;
            this.labelDbSaveInterval.Location = new System.Drawing.Point(501, 96);
            this.labelDbSaveInterval.Name = "labelDbSaveInterval";
            this.labelDbSaveInterval.Size = new System.Drawing.Size(53, 12);
            this.labelDbSaveInterval.TabIndex = 22;
            this.labelDbSaveInterval.Text = "保存间隔";
            this.labelDbSaveInterval.Visible = false;
            // 
            // numUDDbSaveInterval
            // 
            this.numUDDbSaveInterval.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUDDbSaveInterval.Location = new System.Drawing.Point(560, 92);
            this.numUDDbSaveInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUDDbSaveInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDDbSaveInterval.Name = "numUDDbSaveInterval";
            this.numUDDbSaveInterval.Size = new System.Drawing.Size(62, 21);
            this.numUDDbSaveInterval.TabIndex = 21;
            this.numUDDbSaveInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUDDbSaveInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDDbSaveInterval.Visible = false;
            this.numUDDbSaveInterval.ValueChanged += new System.EventHandler(this.numUD_ValueChanged);
            // 
            // labelDbConfig
            // 
            this.labelDbConfig.AutoSize = true;
            this.labelDbConfig.Location = new System.Drawing.Point(136, 99);
            this.labelDbConfig.Name = "labelDbConfig";
            this.labelDbConfig.Size = new System.Drawing.Size(77, 12);
            this.labelDbConfig.TabIndex = 20;
            this.labelDbConfig.Text = "保存配置信息";
            this.labelDbConfig.Visible = false;
            // 
            // textBoxDbConfigString
            // 
            this.textBoxDbConfigString.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxDbConfigString.Location = new System.Drawing.Point(210, 95);
            this.textBoxDbConfigString.MaxLength = 256;
            this.textBoxDbConfigString.Name = "textBoxDbConfigString";
            this.textBoxDbConfigString.Size = new System.Drawing.Size(278, 21);
            this.textBoxDbConfigString.TabIndex = 19;
            this.textBoxDbConfigString.Visible = false;
            // 
            // labelSendInterval
            // 
            this.labelSendInterval.AutoSize = true;
            this.labelSendInterval.Location = new System.Drawing.Point(501, 62);
            this.labelSendInterval.Name = "labelSendInterval";
            this.labelSendInterval.Size = new System.Drawing.Size(53, 12);
            this.labelSendInterval.TabIndex = 18;
            this.labelSendInterval.Text = "发送间隔";
            this.labelSendInterval.Visible = false;
            // 
            // numUDNetSendInterval
            // 
            this.numUDNetSendInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDNetSendInterval.Location = new System.Drawing.Point(560, 59);
            this.numUDNetSendInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDNetSendInterval.Name = "numUDNetSendInterval";
            this.numUDNetSendInterval.Size = new System.Drawing.Size(62, 21);
            this.numUDNetSendInterval.TabIndex = 17;
            this.numUDNetSendInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUDNetSendInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDNetSendInterval.Visible = false;
            this.numUDNetSendInterval.ValueChanged += new System.EventHandler(this.numUD_ValueChanged);
            // 
            // labelLocalSaveInterval
            // 
            this.labelLocalSaveInterval.AutoSize = true;
            this.labelLocalSaveInterval.Location = new System.Drawing.Point(501, 24);
            this.labelLocalSaveInterval.Name = "labelLocalSaveInterval";
            this.labelLocalSaveInterval.Size = new System.Drawing.Size(53, 12);
            this.labelLocalSaveInterval.TabIndex = 10;
            this.labelLocalSaveInterval.Text = "保存间隔";
            this.labelLocalSaveInterval.Visible = false;
            // 
            // numUDLocalSaveInterval
            // 
            this.numUDLocalSaveInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDLocalSaveInterval.Location = new System.Drawing.Point(560, 21);
            this.numUDLocalSaveInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDLocalSaveInterval.Name = "numUDLocalSaveInterval";
            this.numUDLocalSaveInterval.Size = new System.Drawing.Size(62, 21);
            this.numUDLocalSaveInterval.TabIndex = 9;
            this.numUDLocalSaveInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUDLocalSaveInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDLocalSaveInterval.Visible = false;
            this.numUDLocalSaveInterval.ValueChanged += new System.EventHandler(this.numUD_ValueChanged);
            // 
            // textBoxSendRemotePort
            // 
            this.textBoxSendRemotePort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxSendRemotePort.Location = new System.Drawing.Point(404, 59);
            this.textBoxSendRemotePort.MaxLength = 16;
            this.textBoxSendRemotePort.Name = "textBoxSendRemotePort";
            this.textBoxSendRemotePort.Size = new System.Drawing.Size(78, 21);
            this.textBoxSendRemotePort.TabIndex = 11;
            this.textBoxSendRemotePort.Text = "9000";
            this.textBoxSendRemotePort.Visible = false;
            // 
            // labelSendPort
            // 
            this.labelSendPort.AutoSize = true;
            this.labelSendPort.Location = new System.Drawing.Point(369, 62);
            this.labelSendPort.Name = "labelSendPort";
            this.labelSendPort.Size = new System.Drawing.Size(29, 12);
            this.labelSendPort.TabIndex = 16;
            this.labelSendPort.Text = "端口";
            this.labelSendPort.Visible = false;
            // 
            // textBoxSendRemoteIp
            // 
            this.textBoxSendRemoteIp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxSendRemoteIp.Location = new System.Drawing.Point(210, 61);
            this.textBoxSendRemoteIp.MaxLength = 16;
            this.textBoxSendRemoteIp.Name = "textBoxSendRemoteIp";
            this.textBoxSendRemoteIp.Size = new System.Drawing.Size(116, 21);
            this.textBoxSendRemoteIp.TabIndex = 10;
            this.textBoxSendRemoteIp.Text = "192.168.0.19";
            this.textBoxSendRemoteIp.Visible = false;
            // 
            // labelSendIp
            // 
            this.labelSendIp.AutoSize = true;
            this.labelSendIp.Location = new System.Drawing.Point(140, 64);
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
            this.checkBoxEnableSaveDB.Location = new System.Drawing.Point(11, 98);
            this.checkBoxEnableSaveDB.Name = "checkBoxEnableSaveDB";
            this.checkBoxEnableSaveDB.Size = new System.Drawing.Size(108, 16);
            this.checkBoxEnableSaveDB.TabIndex = 12;
            this.checkBoxEnableSaveDB.Text = "启用数据库保存";
            this.checkBoxEnableSaveDB.UseVisualStyleBackColor = true;
            this.checkBoxEnableSaveDB.CheckedChanged += new System.EventHandler(this.checkBoxEnableSaveDB_CheckedChanged);
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
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.BackColor = System.Drawing.Color.LightBlue;
            this.textBoxLog.Location = new System.Drawing.Point(0, 687);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(1170, 42);
            this.textBoxLog.TabIndex = 31;
            // 
            // tabPageAdChart
            // 
            this.tabPageAdChart.Controls.Add(this.plotViewAdChart);
            this.tabPageAdChart.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdChart.Name = "tabPageAdChart";
            this.tabPageAdChart.Size = new System.Drawing.Size(1166, 448);
            this.tabPageAdChart.TabIndex = 2;
            this.tabPageAdChart.Text = "光谱图";
            this.tabPageAdChart.UseVisualStyleBackColor = true;
            // 
            // plotViewAdChart
            // 
            this.plotViewAdChart.BackColor = System.Drawing.Color.White;
            this.plotViewAdChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewAdChart.Location = new System.Drawing.Point(0, 0);
            this.plotViewAdChart.Name = "plotViewAdChart";
            this.plotViewAdChart.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewAdChart.Size = new System.Drawing.Size(1166, 448);
            this.plotViewAdChart.TabIndex = 0;
            this.plotViewAdChart.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewAdChart.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewAdChart.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPageWave
            // 
            this.tabPageWave.Controls.Add(this.listViewQuantity);
            this.tabPageWave.Location = new System.Drawing.Point(4, 22);
            this.tabPageWave.Name = "tabPageWave";
            this.tabPageWave.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWave.Size = new System.Drawing.Size(1166, 448);
            this.tabPageWave.TabIndex = 0;
            this.tabPageWave.Text = "波长值";
            this.tabPageWave.UseVisualStyleBackColor = true;
            // 
            // listViewQuantity
            // 
            this.listViewQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewQuantity.GridLines = true;
            this.listViewQuantity.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewQuantity.Location = new System.Drawing.Point(3, 3);
            this.listViewQuantity.Name = "listViewQuantity";
            this.listViewQuantity.Size = new System.Drawing.Size(1160, 442);
            this.listViewQuantity.TabIndex = 30;
            this.listViewQuantity.UseCompatibleStateImageBehavior = false;
            this.listViewQuantity.View = System.Windows.Forms.View.Details;
            // 
            // tabControlMonitor
            // 
            this.tabControlMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMonitor.Controls.Add(this.tabPageWave);
            this.tabControlMonitor.Controls.Add(this.tabPageAdChart);
            this.tabControlMonitor.Location = new System.Drawing.Point(8, 207);
            this.tabControlMonitor.Name = "tabControlMonitor";
            this.tabControlMonitor.SelectedIndex = 0;
            this.tabControlMonitor.Size = new System.Drawing.Size(1174, 474);
            this.tabControlMonitor.TabIndex = 32;
            // 
            // FiberMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 731);
            this.Controls.Add(this.tabControlMonitor);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBoxSave);
            this.Controls.Add(this.groupBoxSetting);
            this.MaximizeBox = false;
            this.Name = "FiberMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "光纤光栅解调仪";
            this.groupBoxSetting.ResumeLayout(false);
            this.groupBoxSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDCollect)).EndInit();
            this.groupBoxSave.ResumeLayout(false);
            this.groupBoxSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDDbSaveInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNetSendInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLocalSaveInterval)).EndInit();
            this.tabPageAdChart.ResumeLayout(false);
            this.tabPageWave.ResumeLayout(false);
            this.tabControlMonitor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //        private System.Windows.Forms.ColumnHeader columnHeader0;
//        private System.Windows.Forms.ColumnHeader columnHeader1;
//        private System.Windows.Forms.ColumnHeader columnHeader2;
//        private System.Windows.Forms.ColumnHeader columnHeader3;
//        private System.Windows.Forms.ColumnHeader columnHeader4;
//        private System.Windows.Forms.ColumnHeader columnHeader5;
//        private System.Windows.Forms.ColumnHeader columnHeader6;
//        private System.Windows.Forms.ColumnHeader columnHeader7;
//        private System.Windows.Forms.ColumnHeader columnHeader8;
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
        private System.Windows.Forms.Label labelCollectInterval;
        private System.Windows.Forms.NumericUpDown numUDCollect;
        private System.Windows.Forms.Label labelDbSaveInterval;
        private System.Windows.Forms.NumericUpDown numUDDbSaveInterval;
        private System.Windows.Forms.Label labelDbConfig;
        private System.Windows.Forms.TextBox textBoxDbConfigString;
        private System.Windows.Forms.Label labelSendInterval;
        private System.Windows.Forms.NumericUpDown numUDNetSendInterval;
        private System.Windows.Forms.Label labelLocalSaveInterval;
        private System.Windows.Forms.NumericUpDown numUDLocalSaveInterval;
        private System.Windows.Forms.CheckBox checkBoxDebugMode;
        //        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.TabPage tabPageAdChart;
        private OxyPlot.WindowsForms.PlotView plotViewAdChart;
        private System.Windows.Forms.TabPage tabPageWave;
        private System.Windows.Forms.ListView listViewQuantity;
        private System.Windows.Forms.TabControl tabControlMonitor;

    }
}

