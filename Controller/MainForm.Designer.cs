namespace OwWinsCounterController
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
			this.StopUpdateCheckbox = new System.Windows.Forms.CheckBox();
			this.VersionLabel = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.ScoreGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DrawsUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LosesUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WinsUpDown)).BeginInit();
			this.StartingRateGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.StartingRateUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
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
			this.ScoreGroupBox.Location = new System.Drawing.Point(17, 17);
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
			this.StartingRateGroupBox.Location = new System.Drawing.Point(17, 185);
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
			this.groupBox1.Location = new System.Drawing.Point(177, 17);
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
			// StopUpdateCheckbox
			// 
			this.StopUpdateCheckbox.AutoSize = true;
			this.StopUpdateCheckbox.Location = new System.Drawing.Point(177, 225);
			this.StopUpdateCheckbox.Margin = new System.Windows.Forms.Padding(8);
			this.StopUpdateCheckbox.Name = "StopUpdateCheckbox";
			this.StopUpdateCheckbox.Size = new System.Drawing.Size(95, 19);
			this.StopUpdateCheckbox.TabIndex = 3;
			this.StopUpdateCheckbox.Text = "StopUpdate";
			this.StopUpdateCheckbox.UseVisualStyleBackColor = true;
			this.StopUpdateCheckbox.CheckedChanged += new System.EventHandler(this.StopUpdateCheckbox_CheckedChanged);
			// 
			// VersionLabel
			// 
			this.VersionLabel.AutoSize = true;
			this.VersionLabel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.VersionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.VersionLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.VersionLabel.Location = new System.Drawing.Point(226, 258);
			this.VersionLabel.Name = "VersionLabel";
			this.VersionLabel.Size = new System.Drawing.Size(84, 17);
			this.VersionLabel.TabIndex = 4;
			this.VersionLabel.Text = "Version 1.0.0";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(322, 284);
			this.Controls.Add(this.VersionLabel);
			this.Controls.Add(this.StopUpdateCheckbox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.StartingRateGroupBox);
			this.Controls.Add(this.ScoreGroupBox);
			this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form1";
			this.Text = "OwWinsCounter";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ScoreGroupBox.ResumeLayout(false);
			this.ScoreGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DrawsUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LosesUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WinsUpDown)).EndInit();
			this.StartingRateGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.StartingRateUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox StopUpdateCheckbox;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Timer timer1;
    }
}

