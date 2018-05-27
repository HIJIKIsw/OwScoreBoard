namespace OwScoreBoardController
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.ScoreGroupBox = new System.Windows.Forms.GroupBox();
			this.DrawsLabel = new System.Windows.Forms.Label();
			this.DrawsUpDown = new System.Windows.Forms.NumericUpDown();
			this.LosesUpDown = new System.Windows.Forms.NumericUpDown();
			this.LosesLabel = new System.Windows.Forms.Label();
			this.WinsUpDown = new System.Windows.Forms.NumericUpDown();
			this.WinsLabel = new System.Windows.Forms.Label();
			this.StartingRateGroupBox = new System.Windows.Forms.GroupBox();
			this.StartingRateUpDown = new System.Windows.Forms.NumericUpDown();
			this.ResetButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.DrawButton = new System.Windows.Forms.Button();
			this.LoseButton = new System.Windows.Forms.Button();
			this.WinButton = new System.Windows.Forms.Button();
			this.SaveTimer = new System.Windows.Forms.Timer(this.components);
			this.MenuBar = new System.Windows.Forms.MenuStrip();
			this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.OptionMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_AlwayOnTop = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_StopUpdate = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_Manual = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItem_Version = new System.Windows.Forms.ToolStripMenuItem();
			this.ScoreGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DrawsUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LosesUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WinsUpDown)).BeginInit();
			this.StartingRateGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.StartingRateUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.MenuBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// ScoreGroupBox
			// 
			this.ScoreGroupBox.Controls.Add(this.DrawsLabel);
			this.ScoreGroupBox.Controls.Add(this.DrawsUpDown);
			this.ScoreGroupBox.Controls.Add(this.LosesUpDown);
			this.ScoreGroupBox.Controls.Add(this.LosesLabel);
			this.ScoreGroupBox.Controls.Add(this.WinsUpDown);
			this.ScoreGroupBox.Controls.Add(this.WinsLabel);
			this.ScoreGroupBox.Location = new System.Drawing.Point(17, 34);
			this.ScoreGroupBox.Margin = new System.Windows.Forms.Padding(8);
			this.ScoreGroupBox.Name = "ScoreGroupBox";
			this.ScoreGroupBox.Padding = new System.Windows.Forms.Padding(8);
			this.ScoreGroupBox.Size = new System.Drawing.Size(144, 152);
			this.ScoreGroupBox.TabIndex = 0;
			this.ScoreGroupBox.TabStop = false;
			this.ScoreGroupBox.Text = "Today\'s Score";
			// 
			// DrawsLabel
			// 
			this.DrawsLabel.AutoSize = true;
			this.DrawsLabel.Location = new System.Drawing.Point(16, 112);
			this.DrawsLabel.Margin = new System.Windows.Forms.Padding(8);
			this.DrawsLabel.Name = "DrawsLabel";
			this.DrawsLabel.Size = new System.Drawing.Size(44, 15);
			this.DrawsLabel.TabIndex = 7;
			this.DrawsLabel.Text = "Draws";
			// 
			// DrawsUpDown
			// 
			this.DrawsUpDown.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.DrawsUpDown.Location = new System.Drawing.Point(76, 110);
			this.DrawsUpDown.Margin = new System.Windows.Forms.Padding(8);
			this.DrawsUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.DrawsUpDown.Name = "DrawsUpDown";
			this.DrawsUpDown.Size = new System.Drawing.Size(52, 23);
			this.DrawsUpDown.TabIndex = 6;
			this.DrawsUpDown.ValueChanged += new System.EventHandler(this.DrawsUpDown_ValueChanged);
			this.DrawsUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DrawsUpDown_KeyUp);
			// 
			// LosesUpDown
			// 
			this.LosesUpDown.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LosesUpDown.Location = new System.Drawing.Point(76, 71);
			this.LosesUpDown.Margin = new System.Windows.Forms.Padding(8);
			this.LosesUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.LosesUpDown.Name = "LosesUpDown";
			this.LosesUpDown.Size = new System.Drawing.Size(52, 23);
			this.LosesUpDown.TabIndex = 5;
			this.LosesUpDown.ValueChanged += new System.EventHandler(this.LosesUpDown_ValueChanged);
			this.LosesUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LosesUpDown_KeyUp);
			// 
			// LosesLabel
			// 
			this.LosesLabel.AutoSize = true;
			this.LosesLabel.Location = new System.Drawing.Point(16, 73);
			this.LosesLabel.Margin = new System.Windows.Forms.Padding(8);
			this.LosesLabel.Name = "LosesLabel";
			this.LosesLabel.Size = new System.Drawing.Size(40, 15);
			this.LosesLabel.TabIndex = 0;
			this.LosesLabel.Text = "Loses";
			// 
			// WinsUpDown
			// 
			this.WinsUpDown.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.WinsUpDown.Location = new System.Drawing.Point(76, 32);
			this.WinsUpDown.Margin = new System.Windows.Forms.Padding(8);
			this.WinsUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.WinsUpDown.Name = "WinsUpDown";
			this.WinsUpDown.Size = new System.Drawing.Size(52, 23);
			this.WinsUpDown.TabIndex = 4;
			this.WinsUpDown.ValueChanged += new System.EventHandler(this.WinsUpDown_ValueChanged);
			this.WinsUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WinsUpDown_KeyUp);
			// 
			// WinsLabel
			// 
			this.WinsLabel.AutoSize = true;
			this.WinsLabel.Location = new System.Drawing.Point(16, 34);
			this.WinsLabel.Margin = new System.Windows.Forms.Padding(8);
			this.WinsLabel.Name = "WinsLabel";
			this.WinsLabel.Size = new System.Drawing.Size(35, 15);
			this.WinsLabel.TabIndex = 1;
			this.WinsLabel.Text = "Wins";
			// 
			// StartingRateGroupBox
			// 
			this.StartingRateGroupBox.Controls.Add(this.StartingRateUpDown);
			this.StartingRateGroupBox.Location = new System.Drawing.Point(17, 202);
			this.StartingRateGroupBox.Margin = new System.Windows.Forms.Padding(8);
			this.StartingRateGroupBox.Name = "StartingRateGroupBox";
			this.StartingRateGroupBox.Padding = new System.Windows.Forms.Padding(8);
			this.StartingRateGroupBox.Size = new System.Drawing.Size(144, 76);
			this.StartingRateGroupBox.TabIndex = 1;
			this.StartingRateGroupBox.TabStop = false;
			this.StartingRateGroupBox.Text = "Starting Rate";
			// 
			// StartingRateUpDown
			// 
			this.StartingRateUpDown.Location = new System.Drawing.Point(16, 32);
			this.StartingRateUpDown.Margin = new System.Windows.Forms.Padding(8);
			this.StartingRateUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.StartingRateUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.StartingRateUpDown.Name = "StartingRateUpDown";
			this.StartingRateUpDown.Size = new System.Drawing.Size(112, 23);
			this.StartingRateUpDown.TabIndex = 0;
			this.StartingRateUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.StartingRateUpDown.ValueChanged += new System.EventHandler(this.StartingRateUpDown_ValueChanged);
			this.StartingRateUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StartingRateUpDown_KeyUp);
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(16, 149);
			this.ResetButton.Margin = new System.Windows.Forms.Padding(8);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(96, 23);
			this.ResetButton.TabIndex = 8;
			this.ResetButton.Text = "Reset";
			this.ResetButton.UseVisualStyleBackColor = true;
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ResetButton);
			this.groupBox1.Controls.Add(this.DrawButton);
			this.groupBox1.Controls.Add(this.LoseButton);
			this.groupBox1.Controls.Add(this.WinButton);
			this.groupBox1.Location = new System.Drawing.Point(177, 34);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 83);
			this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.groupBox1.Size = new System.Drawing.Size(128, 192);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Quick Actions";
			// 
			// DrawButton
			// 
			this.DrawButton.Location = new System.Drawing.Point(16, 110);
			this.DrawButton.Margin = new System.Windows.Forms.Padding(8);
			this.DrawButton.Name = "DrawButton";
			this.DrawButton.Size = new System.Drawing.Size(96, 23);
			this.DrawButton.TabIndex = 2;
			this.DrawButton.Text = "Draw";
			this.DrawButton.UseVisualStyleBackColor = true;
			this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
			// 
			// LoseButton
			// 
			this.LoseButton.Location = new System.Drawing.Point(16, 71);
			this.LoseButton.Margin = new System.Windows.Forms.Padding(8);
			this.LoseButton.Name = "LoseButton";
			this.LoseButton.Size = new System.Drawing.Size(96, 23);
			this.LoseButton.TabIndex = 1;
			this.LoseButton.Text = "Lose";
			this.LoseButton.UseVisualStyleBackColor = true;
			this.LoseButton.Click += new System.EventHandler(this.LoseButton_Click);
			// 
			// WinButton
			// 
			this.WinButton.Location = new System.Drawing.Point(16, 32);
			this.WinButton.Margin = new System.Windows.Forms.Padding(8);
			this.WinButton.Name = "WinButton";
			this.WinButton.Size = new System.Drawing.Size(96, 23);
			this.WinButton.TabIndex = 0;
			this.WinButton.Text = "Win";
			this.WinButton.UseVisualStyleBackColor = true;
			this.WinButton.Click += new System.EventHandler(this.WinButton_Click);
			// 
			// SaveTimer
			// 
			this.SaveTimer.Interval = 1000;
			this.SaveTimer.Tick += new System.EventHandler(this.SaveTimer_Tick);
			// 
			// MenuBar
			// 
			this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.OptionMenu,
            this.HelpMenu});
			this.MenuBar.Location = new System.Drawing.Point(0, 0);
			this.MenuBar.Name = "MenuBar";
			this.MenuBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.MenuBar.Size = new System.Drawing.Size(322, 26);
			this.MenuBar.TabIndex = 4;
			this.MenuBar.Text = "MenuBar";
			// 
			// FileMenu
			// 
			this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Exit});
			this.FileMenu.Name = "FileMenu";
			this.FileMenu.Size = new System.Drawing.Size(85, 22);
			this.FileMenu.Text = "ファイル(&F)";
			// 
			// MenuItem_Exit
			// 
			this.MenuItem_Exit.Name = "MenuItem_Exit";
			this.MenuItem_Exit.Size = new System.Drawing.Size(118, 22);
			this.MenuItem_Exit.Text = "終了(&X)";
			this.MenuItem_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
			// 
			// OptionMenu
			// 
			this.OptionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_AlwayOnTop,
            this.MenuItem_StopUpdate,
            this.toolStripSeparator1,
            this.MenuItem_Settings});
			this.OptionMenu.Name = "OptionMenu";
			this.OptionMenu.Size = new System.Drawing.Size(99, 22);
			this.OptionMenu.Text = "オプション(&O)";
			// 
			// MenuItem_AlwayOnTop
			// 
			this.MenuItem_AlwayOnTop.CheckOnClick = true;
			this.MenuItem_AlwayOnTop.Name = "MenuItem_AlwayOnTop";
			this.MenuItem_AlwayOnTop.Size = new System.Drawing.Size(172, 22);
			this.MenuItem_AlwayOnTop.Text = "常に最前面に表示";
			this.MenuItem_AlwayOnTop.Click += new System.EventHandler(this.MenuItem_AlwayOnTop_Click);
			// 
			// MenuItem_StopUpdate
			// 
			this.MenuItem_StopUpdate.CheckOnClick = true;
			this.MenuItem_StopUpdate.Name = "MenuItem_StopUpdate";
			this.MenuItem_StopUpdate.Size = new System.Drawing.Size(172, 22);
			this.MenuItem_StopUpdate.Text = "反映を一時停止";
			this.MenuItem_StopUpdate.Click += new System.EventHandler(this.MenuItem_StopUpdate_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
			// 
			// MenuItem_Settings
			// 
			this.MenuItem_Settings.Name = "MenuItem_Settings";
			this.MenuItem_Settings.Size = new System.Drawing.Size(172, 22);
			this.MenuItem_Settings.Text = "設定(&C)...";
			this.MenuItem_Settings.Click += new System.EventHandler(this.MenuItem_Settings_Click);
			// 
			// HelpMenu
			// 
			this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Manual,
            this.toolStripSeparator2,
            this.MenuItem_Version});
			this.HelpMenu.Name = "HelpMenu";
			this.HelpMenu.Size = new System.Drawing.Size(75, 22);
			this.HelpMenu.Text = "ヘルプ(&H)";
			// 
			// MenuItem_Manual
			// 
			this.MenuItem_Manual.Name = "MenuItem_Manual";
			this.MenuItem_Manual.Size = new System.Drawing.Size(172, 22);
			this.MenuItem_Manual.Text = "ヘルプ";
			this.MenuItem_Manual.Click += new System.EventHandler(this.MenuItem_Manual_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
			// 
			// MenuItem_Version
			// 
			this.MenuItem_Version.Name = "MenuItem_Version";
			this.MenuItem_Version.Size = new System.Drawing.Size(172, 22);
			this.MenuItem_Version.Text = "バージョン情報...";
			this.MenuItem_Version.Click += new System.EventHandler(this.MenuItem_Version_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(322, 295);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.StartingRateGroupBox);
			this.Controls.Add(this.ScoreGroupBox);
			this.Controls.Add(this.MenuBar);
			this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.MenuBar;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.Text = "OwScoreBoard";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.OnLoad);
			this.ScoreGroupBox.ResumeLayout(false);
			this.ScoreGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DrawsUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LosesUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WinsUpDown)).EndInit();
			this.StartingRateGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.StartingRateUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.MenuBar.ResumeLayout(false);
			this.MenuBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox ScoreGroupBox;
		private System.Windows.Forms.GroupBox StartingRateGroupBox;
		private System.Windows.Forms.Label LosesLabel;
		private System.Windows.Forms.Label WinsLabel;
		private System.Windows.Forms.NumericUpDown WinsUpDown;
		private System.Windows.Forms.NumericUpDown LosesUpDown;
		private System.Windows.Forms.Label DrawsLabel;
		private System.Windows.Forms.NumericUpDown DrawsUpDown;
		private System.Windows.Forms.Button ResetButton;
		private System.Windows.Forms.NumericUpDown StartingRateUpDown;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button WinButton;
		private System.Windows.Forms.Button DrawButton;
		private System.Windows.Forms.Button LoseButton;
		private System.Windows.Forms.Timer SaveTimer;
		private System.Windows.Forms.MenuStrip MenuBar;
		private System.Windows.Forms.ToolStripMenuItem FileMenu;
		private System.Windows.Forms.ToolStripMenuItem OptionMenu;
		private System.Windows.Forms.ToolStripMenuItem HelpMenu;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Version;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_StopUpdate;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Settings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Manual;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_AlwayOnTop;
	}
}

