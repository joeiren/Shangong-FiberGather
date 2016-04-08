namespace ZhengJuyin.UI
{
    partial class ZGraph
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxBottom = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxTop = new System.Windows.Forms.PictureBox();
            this.buttonLinesShowXY = new System.Windows.Forms.Button();
            this.panelControlItem = new System.Windows.Forms.Panel();
            this.panelItemsIN = new System.Windows.Forms.Panel();
            this.buttonReXY = new System.Windows.Forms.Button();
            this.buttonBigModeXY = new System.Windows.Forms.Button();
            this.buttonAutoModeXY = new System.Windows.Forms.Button();
            this.buttonItemsDown = new System.Windows.Forms.Button();
            this.buttonControlItemUP = new System.Windows.Forms.Button();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.MenuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBoxX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.网格显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大选取框功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标自动调整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认坐标范围ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelItemShuoMing = new System.Windows.Forms.Label();
            this.pictureBoxBigXY = new System.Windows.Forms.PictureBox();
            this.buttonBigXYQuit = new System.Windows.Forms.Button();
            this.buttonBigXYBig = new System.Windows.Forms.Button();
            this.panelBigXY = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).BeginInit();
            this.panelControlItem.SuspendLayout();
            this.panelItemsIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.MenuRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBigXY)).BeginInit();
            this.panelBigXY.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxBottom
            // 
            this.pictureBoxBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBottom.BackColor = System.Drawing.Color.White;
            this.pictureBoxBottom.ErrorImage = null;
            this.pictureBoxBottom.InitialImage = null;
            this.pictureBoxBottom.Location = new System.Drawing.Point(0, 228);
            this.pictureBoxBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxBottom.MinimumSize = new System.Drawing.Size(0, 45);
            this.pictureBoxBottom.Name = "pictureBoxBottom";
            this.pictureBoxBottom.Size = new System.Drawing.Size(454, 45);
            this.pictureBoxBottom.TabIndex = 0;
            this.pictureBoxBottom.TabStop = false;
            this.pictureBoxBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBottom_Paint);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxLeft.BackColor = System.Drawing.Color.White;
            this.pictureBoxLeft.ErrorImage = null;
            this.pictureBoxLeft.InitialImage = null;
            this.pictureBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxLeft.MinimumSize = new System.Drawing.Size(50, 0);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(50, 228);
            this.pictureBoxLeft.TabIndex = 1;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxLeft_Paint);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxRight.BackColor = System.Drawing.Color.White;
            this.pictureBoxRight.ErrorImage = null;
            this.pictureBoxRight.InitialImage = null;
            this.pictureBoxRight.Location = new System.Drawing.Point(404, 0);
            this.pictureBoxRight.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxRight.MinimumSize = new System.Drawing.Size(50, 0);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(50, 228);
            this.pictureBoxRight.TabIndex = 2;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxRight_Paint);
            // 
            // pictureBoxTop
            // 
            this.pictureBoxTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTop.BackColor = System.Drawing.Color.White;
            this.pictureBoxTop.ErrorImage = null;
            this.pictureBoxTop.InitialImage = null;
            this.pictureBoxTop.Location = new System.Drawing.Point(50, 0);
            this.pictureBoxTop.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTop.MinimumSize = new System.Drawing.Size(0, 30);
            this.pictureBoxTop.Name = "pictureBoxTop";
            this.pictureBoxTop.Size = new System.Drawing.Size(354, 30);
            this.pictureBoxTop.TabIndex = 3;
            this.pictureBoxTop.TabStop = false;
            this.pictureBoxTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTop_Paint);
            // 
            // buttonLinesShowXY
            // 
            this.buttonLinesShowXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLinesShowXY.BackColor = System.Drawing.Color.Black;
            this.buttonLinesShowXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLinesShowXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLinesShowXY.ForeColor = System.Drawing.Color.White;
            this.buttonLinesShowXY.Location = new System.Drawing.Point(1, 1);
            this.buttonLinesShowXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonLinesShowXY.Name = "buttonLinesShowXY";
            this.buttonLinesShowXY.Size = new System.Drawing.Size(32, 32);
            this.buttonLinesShowXY.TabIndex = 5;
            this.buttonLinesShowXY.TabStop = false;
            this.buttonLinesShowXY.UseVisualStyleBackColor = false;
            this.buttonLinesShowXY.MouseLeave += new System.EventHandler(this.buttonLinesShowXY_MouseLeave);
            this.buttonLinesShowXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonLinesShowXY_Paint);
            this.buttonLinesShowXY.Click += new System.EventHandler(this.buttonLinesShowXY_Click);
            this.buttonLinesShowXY.MouseEnter += new System.EventHandler(this.buttonLinesShowXY_MouseEnter);
            // 
            // panelControlItem
            // 
            this.panelControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlItem.AutoScroll = true;
            this.panelControlItem.BackColor = System.Drawing.Color.Black;
            this.panelControlItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelControlItem.Controls.Add(this.panelItemsIN);
            this.panelControlItem.Location = new System.Drawing.Point(405, 40);
            this.panelControlItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.panelControlItem.Name = "panelControlItem";
            this.panelControlItem.Size = new System.Drawing.Size(36, 178);
            this.panelControlItem.TabIndex = 6;
            // 
            // panelItemsIN
            // 
            this.panelItemsIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelItemsIN.BackColor = System.Drawing.Color.Transparent;
            this.panelItemsIN.Controls.Add(this.buttonReXY);
            this.panelItemsIN.Controls.Add(this.buttonBigModeXY);
            this.panelItemsIN.Controls.Add(this.buttonAutoModeXY);
            this.panelItemsIN.Controls.Add(this.buttonLinesShowXY);
            this.panelItemsIN.Location = new System.Drawing.Point(1, 0);
            this.panelItemsIN.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.panelItemsIN.Name = "panelItemsIN";
            this.panelItemsIN.Size = new System.Drawing.Size(34, 178);
            this.panelItemsIN.TabIndex = 9;
            // 
            // buttonReXY
            // 
            this.buttonReXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReXY.BackColor = System.Drawing.Color.Black;
            this.buttonReXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonReXY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonReXY.Location = new System.Drawing.Point(1, 100);
            this.buttonReXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonReXY.Name = "buttonReXY";
            this.buttonReXY.Size = new System.Drawing.Size(32, 32);
            this.buttonReXY.TabIndex = 11;
            this.buttonReXY.TabStop = false;
            this.buttonReXY.UseVisualStyleBackColor = false;
            this.buttonReXY.MouseLeave += new System.EventHandler(this.buttonReXY_MouseLeave);
            this.buttonReXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonReXY_Paint);
            this.buttonReXY.Click += new System.EventHandler(this.buttonReXY_Click);
            this.buttonReXY.MouseEnter += new System.EventHandler(this.buttonReXY_MouseEnter);
            // 
            // buttonBigModeXY
            // 
            this.buttonBigModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBigModeXY.BackColor = System.Drawing.Color.Black;
            this.buttonBigModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBigModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonBigModeXY.ForeColor = System.Drawing.Color.White;
            this.buttonBigModeXY.Location = new System.Drawing.Point(1, 34);
            this.buttonBigModeXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonBigModeXY.Name = "buttonBigModeXY";
            this.buttonBigModeXY.Size = new System.Drawing.Size(32, 32);
            this.buttonBigModeXY.TabIndex = 10;
            this.buttonBigModeXY.TabStop = false;
            this.buttonBigModeXY.UseVisualStyleBackColor = false;
            this.buttonBigModeXY.MouseLeave += new System.EventHandler(this.buttonBigModeXY_MouseLeave);
            this.buttonBigModeXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonBigModeXY_Paint);
            this.buttonBigModeXY.Click += new System.EventHandler(this.buttonBigModeXY_Click);
            this.buttonBigModeXY.MouseEnter += new System.EventHandler(this.buttonBigModeXY_MouseEnter);
            // 
            // buttonAutoModeXY
            // 
            this.buttonAutoModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoModeXY.BackColor = System.Drawing.Color.Black;
            this.buttonAutoModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutoModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAutoModeXY.ForeColor = System.Drawing.Color.White;
            this.buttonAutoModeXY.Location = new System.Drawing.Point(1, 67);
            this.buttonAutoModeXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonAutoModeXY.Name = "buttonAutoModeXY";
            this.buttonAutoModeXY.Size = new System.Drawing.Size(32, 32);
            this.buttonAutoModeXY.TabIndex = 9;
            this.buttonAutoModeXY.TabStop = false;
            this.buttonAutoModeXY.UseVisualStyleBackColor = false;
            this.buttonAutoModeXY.MouseLeave += new System.EventHandler(this.buttonAutoModeXY_MouseLeave);
            this.buttonAutoModeXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonAutoModeXY_Paint);
            this.buttonAutoModeXY.Click += new System.EventHandler(this.buttonAutoModeXY_Click);
            this.buttonAutoModeXY.MouseEnter += new System.EventHandler(this.buttonAutoModeXY_MouseEnter);
            // 
            // buttonItemsDown
            // 
            this.buttonItemsDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemsDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonItemsDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonItemsDown.Enabled = false;
            this.buttonItemsDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemsDown.ForeColor = System.Drawing.Color.Black;
            this.buttonItemsDown.Location = new System.Drawing.Point(405, 218);
            this.buttonItemsDown.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonItemsDown.Name = "buttonItemsDown";
            this.buttonItemsDown.Size = new System.Drawing.Size(36, 10);
            this.buttonItemsDown.TabIndex = 8;
            this.buttonItemsDown.TabStop = false;
            this.buttonItemsDown.UseVisualStyleBackColor = false;
            this.buttonItemsDown.Click += new System.EventHandler(this.buttonItemsDown_Click);
            // 
            // buttonControlItemUP
            // 
            this.buttonControlItemUP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonControlItemUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonControlItemUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonControlItemUP.Enabled = false;
            this.buttonControlItemUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonControlItemUP.ForeColor = System.Drawing.Color.Black;
            this.buttonControlItemUP.Location = new System.Drawing.Point(405, 30);
            this.buttonControlItemUP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonControlItemUP.Name = "buttonControlItemUP";
            this.buttonControlItemUP.Size = new System.Drawing.Size(36, 10);
            this.buttonControlItemUP.TabIndex = 7;
            this.buttonControlItemUP.TabStop = false;
            this.buttonControlItemUP.UseVisualStyleBackColor = false;
            this.buttonControlItemUP.Click += new System.EventHandler(this.buttonControlItemUP_Click);
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGraph.BackColor = System.Drawing.Color.Black;
            this.pictureBoxGraph.ContextMenuStrip = this.MenuRightClick;
            this.pictureBoxGraph.ErrorImage = null;
            this.pictureBoxGraph.InitialImage = null;
            this.pictureBoxGraph.Location = new System.Drawing.Point(50, 30);
            this.pictureBoxGraph.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(354, 198);
            this.pictureBoxGraph.TabIndex = 4;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.MouseLeave += new System.EventHandler(this.pictureBoxGraph_MouseLeave);
            this.pictureBoxGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseMove);
            this.pictureBoxGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseDown);
            this.pictureBoxGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraph_Paint);
            this.pictureBoxGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseUp);
            // 
            // MenuRightClick
            // 
            this.MenuRightClick.BackColor = System.Drawing.Color.White;
            this.MenuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxX,
            this.toolStripTextBoxY,
            this.toolStripSeparator1,
            this.网格显示ToolStripMenuItem,
            this.放大选取框功能ToolStripMenuItem,
            this.坐标自动调整ToolStripMenuItem,
            this.默认坐标范围ToolStripMenuItem});
            this.MenuRightClick.Name = "MenuRightClick";
            this.MenuRightClick.Size = new System.Drawing.Size(161, 134);
            // 
            // toolStripTextBoxX
            // 
            this.toolStripTextBoxX.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.toolStripTextBoxX.Name = "toolStripTextBoxX";
            this.toolStripTextBoxX.ReadOnly = true;
            this.toolStripTextBoxX.Size = new System.Drawing.Size(100, 16);
            this.toolStripTextBoxX.Text = "0";
            // 
            // toolStripTextBoxY
            // 
            this.toolStripTextBoxY.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBoxY.ForeColor = System.Drawing.Color.Black;
            this.toolStripTextBoxY.Name = "toolStripTextBoxY";
            this.toolStripTextBoxY.ReadOnly = true;
            this.toolStripTextBoxY.Size = new System.Drawing.Size(100, 16);
            this.toolStripTextBoxY.Text = "0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 网格显示ToolStripMenuItem
            // 
            this.网格显示ToolStripMenuItem.Checked = true;
            this.网格显示ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.网格显示ToolStripMenuItem.Name = "网格显示ToolStripMenuItem";
            this.网格显示ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.网格显示ToolStripMenuItem.Text = "网格显示";
            this.网格显示ToolStripMenuItem.Click += new System.EventHandler(this.buttonLinesShowXY_Click);
            // 
            // 放大选取框功能ToolStripMenuItem
            // 
            this.放大选取框功能ToolStripMenuItem.Name = "放大选取框功能ToolStripMenuItem";
            this.放大选取框功能ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.放大选取框功能ToolStripMenuItem.Text = "放大选取框功能";
            this.放大选取框功能ToolStripMenuItem.Click += new System.EventHandler(this.buttonBigModeXY_Click);
            // 
            // 坐标自动调整ToolStripMenuItem
            // 
            this.坐标自动调整ToolStripMenuItem.Checked = true;
            this.坐标自动调整ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.坐标自动调整ToolStripMenuItem.Name = "坐标自动调整ToolStripMenuItem";
            this.坐标自动调整ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.坐标自动调整ToolStripMenuItem.Text = "坐标自动调整";
            this.坐标自动调整ToolStripMenuItem.Click += new System.EventHandler(this.buttonAutoModeXY_Click);
            // 
            // 默认坐标范围ToolStripMenuItem
            // 
            this.默认坐标范围ToolStripMenuItem.Name = "默认坐标范围ToolStripMenuItem";
            this.默认坐标范围ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.默认坐标范围ToolStripMenuItem.Text = "默认坐标范围";
            this.默认坐标范围ToolStripMenuItem.Click += new System.EventHandler(this.buttonReXY_Click);
            // 
            // labelItemShuoMing
            // 
            this.labelItemShuoMing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelItemShuoMing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.labelItemShuoMing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelItemShuoMing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelItemShuoMing.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelItemShuoMing.ForeColor = System.Drawing.Color.White;
            this.labelItemShuoMing.Location = new System.Drawing.Point(342, 235);
            this.labelItemShuoMing.Name = "labelItemShuoMing";
            this.labelItemShuoMing.Size = new System.Drawing.Size(100, 32);
            this.labelItemShuoMing.TabIndex = 9;
            this.labelItemShuoMing.Text = "说明";
            this.labelItemShuoMing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelItemShuoMing.Visible = false;
            // 
            // pictureBoxBigXY
            // 
            this.pictureBoxBigXY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBoxBigXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBigXY.ErrorImage = null;
            this.pictureBoxBigXY.InitialImage = null;
            this.pictureBoxBigXY.Location = new System.Drawing.Point(222, 235);
            this.pictureBoxBigXY.Name = "pictureBoxBigXY";
            this.pictureBoxBigXY.Size = new System.Drawing.Size(114, 32);
            this.pictureBoxBigXY.TabIndex = 11;
            this.pictureBoxBigXY.TabStop = false;
            this.pictureBoxBigXY.Visible = false;
            // 
            // buttonBigXYQuit
            // 
            this.buttonBigXYQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBigXYQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonBigXYQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBigXYQuit.ForeColor = System.Drawing.Color.Black;
            this.buttonBigXYQuit.Location = new System.Drawing.Point(43, 9);
            this.buttonBigXYQuit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBigXYQuit.Name = "buttonBigXYQuit";
            this.buttonBigXYQuit.Size = new System.Drawing.Size(40, 23);
            this.buttonBigXYQuit.TabIndex = 12;
            this.buttonBigXYQuit.TabStop = false;
            this.buttonBigXYQuit.Text = "取消";
            this.buttonBigXYQuit.UseVisualStyleBackColor = false;
            this.buttonBigXYQuit.Click += new System.EventHandler(this.buttonBigXYQuit_Click);
            // 
            // buttonBigXYBig
            // 
            this.buttonBigXYBig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBigXYBig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonBigXYBig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBigXYBig.ForeColor = System.Drawing.Color.Black;
            this.buttonBigXYBig.Location = new System.Drawing.Point(3, 9);
            this.buttonBigXYBig.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBigXYBig.Name = "buttonBigXYBig";
            this.buttonBigXYBig.Size = new System.Drawing.Size(40, 23);
            this.buttonBigXYBig.TabIndex = 13;
            this.buttonBigXYBig.TabStop = false;
            this.buttonBigXYBig.Text = "放大";
            this.buttonBigXYBig.UseVisualStyleBackColor = false;
            this.buttonBigXYBig.Click += new System.EventHandler(this.buttonBigXYBig_Click);
            // 
            // panelBigXY
            // 
            this.panelBigXY.BackColor = System.Drawing.Color.Transparent;
            this.panelBigXY.Controls.Add(this.buttonBigXYBig);
            this.panelBigXY.Controls.Add(this.buttonBigXYQuit);
            this.panelBigXY.Location = new System.Drawing.Point(253, 235);
            this.panelBigXY.Name = "panelBigXY";
            this.panelBigXY.Size = new System.Drawing.Size(83, 32);
            this.panelBigXY.TabIndex = 14;
            this.panelBigXY.Visible = false;
            // 
            // ZGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelBigXY);
            this.Controls.Add(this.pictureBoxBigXY);
            this.Controls.Add(this.labelItemShuoMing);
            this.Controls.Add(this.buttonItemsDown);
            this.Controls.Add(this.buttonControlItemUP);
            this.Controls.Add(this.panelControlItem);
            this.Controls.Add(this.pictureBoxGraph);
            this.Controls.Add(this.pictureBoxTop);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.pictureBoxBottom);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(390, 270);
            this.Name = "ZGraph";
            this.Size = new System.Drawing.Size(454, 273);
            this.Resize += new System.EventHandler(this.ZGraph_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).EndInit();
            this.panelControlItem.ResumeLayout(false);
            this.panelItemsIN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.MenuRightClick.ResumeLayout(false);
            this.MenuRightClick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBigXY)).EndInit();
            this.panelBigXY.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBottom;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxTop;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.Button buttonLinesShowXY;
        private System.Windows.Forms.Panel panelControlItem;
        private System.Windows.Forms.Button buttonControlItemUP;
        private System.Windows.Forms.Button buttonItemsDown;
        private System.Windows.Forms.Panel panelItemsIN;
        private System.Windows.Forms.Button buttonAutoModeXY;
        private System.Windows.Forms.Button buttonBigModeXY;
        private System.Windows.Forms.Label labelItemShuoMing;
        private System.Windows.Forms.Button buttonReXY;
        private System.Windows.Forms.ContextMenuStrip MenuRightClick;
        private System.Windows.Forms.PictureBox pictureBoxBigXY;
        private System.Windows.Forms.Button buttonBigXYQuit;
        private System.Windows.Forms.Button buttonBigXYBig;
        private System.Windows.Forms.Panel panelBigXY;
        private System.Windows.Forms.ToolStripMenuItem 网格显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大选取框功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坐标自动调整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 默认坐标范围ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxX;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
