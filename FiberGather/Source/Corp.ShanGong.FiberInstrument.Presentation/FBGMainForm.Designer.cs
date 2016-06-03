namespace Corp.ShanGong.FiberInstrument.Presentation
{
    partial class FBGMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageLightDisplaying = new System.Windows.Forms.TabPage();
            this.tabPageChartDisplaying = new System.Windows.Forms.TabPage();
            this.tabPageChannelConfig = new System.Windows.Forms.TabPage();
            this.tabPageSensorConfig = new System.Windows.Forms.TabPage();
            this.tabPageSystemSetting = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageLightDisplaying);
            this.tabControlMain.Controls.Add(this.tabPageChartDisplaying);
            this.tabControlMain.Controls.Add(this.tabPageChannelConfig);
            this.tabControlMain.Controls.Add(this.tabPageSensorConfig);
            this.tabControlMain.Controls.Add(this.tabPageSystemSetting);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1008, 730);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageLightDisplaying
            // 
            this.tabPageLightDisplaying.Location = new System.Drawing.Point(4, 22);
            this.tabPageLightDisplaying.Name = "tabPageLightDisplaying";
            this.tabPageLightDisplaying.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLightDisplaying.Size = new System.Drawing.Size(1000, 704);
            this.tabPageLightDisplaying.TabIndex = 0;
            this.tabPageLightDisplaying.Text = "光谱展示";
            this.tabPageLightDisplaying.UseVisualStyleBackColor = true;
            // 
            // tabPageChartDisplaying
            // 
            this.tabPageChartDisplaying.Location = new System.Drawing.Point(4, 22);
            this.tabPageChartDisplaying.Name = "tabPageChartDisplaying";
            this.tabPageChartDisplaying.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChartDisplaying.Size = new System.Drawing.Size(1000, 704);
            this.tabPageChartDisplaying.TabIndex = 1;
            this.tabPageChartDisplaying.Text = "图形展示";
            this.tabPageChartDisplaying.UseVisualStyleBackColor = true;
            // 
            // tabPageChannelConfig
            // 
            this.tabPageChannelConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageChannelConfig.Name = "tabPageChannelConfig";
            this.tabPageChannelConfig.Size = new System.Drawing.Size(1000, 704);
            this.tabPageChannelConfig.TabIndex = 2;
            this.tabPageChannelConfig.Text = "通道配置";
            this.tabPageChannelConfig.UseVisualStyleBackColor = true;
            // 
            // tabPageSensorConfig
            // 
            this.tabPageSensorConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageSensorConfig.Name = "tabPageSensorConfig";
            this.tabPageSensorConfig.Size = new System.Drawing.Size(1000, 704);
            this.tabPageSensorConfig.TabIndex = 3;
            this.tabPageSensorConfig.Text = "传感器配置";
            this.tabPageSensorConfig.UseVisualStyleBackColor = true;
            // 
            // tabPageSystemSetting
            // 
            this.tabPageSystemSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystemSetting.Name = "tabPageSystemSetting";
            this.tabPageSystemSetting.Size = new System.Drawing.Size(1000, 704);
            this.tabPageSystemSetting.TabIndex = 4;
            this.tabPageSystemSetting.Text = "系统设置";
            this.tabPageSystemSetting.UseVisualStyleBackColor = true;
            // 
            // FBGMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.tabControlMain);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FBGMainForm";
            this.Text = "FBG--宁波杉工";
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLightDisplaying;
        private System.Windows.Forms.TabPage tabPageChartDisplaying;
        private System.Windows.Forms.TabPage tabPageChannelConfig;
        private System.Windows.Forms.TabPage tabPageSensorConfig;
        private System.Windows.Forms.TabPage tabPageSystemSetting;
    }
}