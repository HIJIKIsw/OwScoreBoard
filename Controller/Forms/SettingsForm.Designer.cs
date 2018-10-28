namespace OwScoreBoardController
{
	partial class SettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.Hotkey = new System.Windows.Forms.TabPage();
			this.DrawHotkeyModCheckbox_Alt = new System.Windows.Forms.CheckBox();
			this.DrawHotkeyModCheckbox_Shift = new System.Windows.Forms.CheckBox();
			this.DrawHotkeyModCheckbox_Ctrl = new System.Windows.Forms.CheckBox();
			this.DrawHotkeyCombobox = new System.Windows.Forms.ComboBox();
			this.LoseHotkeyModCheckbox_Alt = new System.Windows.Forms.CheckBox();
			this.LoseHotkeyModCheckbox_Shift = new System.Windows.Forms.CheckBox();
			this.LoseHotkeyModCheckbox_Ctrl = new System.Windows.Forms.CheckBox();
			this.LoseHotkeyCombobox = new System.Windows.Forms.ComboBox();
			this.WinHotkeyModCheckbox_Alt = new System.Windows.Forms.CheckBox();
			this.WinHotkeyModCheckbox_Shift = new System.Windows.Forms.CheckBox();
			this.WinHotkeyModCheckbox_Ctrl = new System.Windows.Forms.CheckBox();
			this.WinHotkeyCombobox = new System.Windows.Forms.ComboBox();
			this.DrawHotkeyClearButton = new System.Windows.Forms.Button();
			this.LoseHotkeyClearButton = new System.Windows.Forms.Button();
			this.WinHotkeyClearButton = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.General = new System.Windows.Forms.TabPage();
			this.ProductionGroup = new System.Windows.Forms.GroupBox();
			this.EnableProductionCheckbox = new System.Windows.Forms.CheckBox();
			this.VolumeLabel = new System.Windows.Forms.Label();
			this.VolumeTrackbar = new System.Windows.Forms.TrackBar();
			this.FontColorLabel = new System.Windows.Forms.Label();
			this.MainColorLabel = new System.Windows.Forms.Label();
			this.FontColorBox = new System.Windows.Forms.PictureBox();
			this.MainColorBox = new System.Windows.Forms.PictureBox();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.SubColorBox = new System.Windows.Forms.PictureBox();
			this.NameLabel = new System.Windows.Forms.Label();
			this.SubColorLabel = new System.Windows.Forms.Label();
			this.LogoPictureBox = new System.Windows.Forms.PictureBox();
			this.LogoLabel = new System.Windows.Forms.Label();
			this.ScoreBoardGroup = new System.Windows.Forms.GroupBox();
			this.ScoreBoardSizeLabel = new System.Windows.Forms.Label();
			this.ScoreBoardPositionRadioPanel = new System.Windows.Forms.Panel();
			this.ScoreBoardPositionLabel = new System.Windows.Forms.Label();
			this.ScoreBoardPositionRadio_Top = new System.Windows.Forms.RadioButton();
			this.ScoreBoardPositionRadio_Bottom = new System.Windows.Forms.RadioButton();
			this.ScoreBoardSizeTrackbar = new System.Windows.Forms.TrackBar();
			this.SettingsTabControl = new System.Windows.Forms.TabControl();
			this.Hotkey.SuspendLayout();
			this.General.SuspendLayout();
			this.ProductionGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.VolumeTrackbar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FontColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MainColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SubColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
			this.ScoreBoardGroup.SuspendLayout();
			this.ScoreBoardPositionRadioPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ScoreBoardSizeTrackbar)).BeginInit();
			this.SettingsTabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(265, 451);
			this.OKButton.Margin = new System.Windows.Forms.Padding(8);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(80, 23);
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(361, 451);
			this.CancelButton.Margin = new System.Windows.Forms.Padding(8);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(80, 23);
			this.CancelButton.TabIndex = 2;
			this.CancelButton.Text = "キャンセル";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// Hotkey
			// 
			this.Hotkey.BackColor = System.Drawing.SystemColors.Control;
			this.Hotkey.Controls.Add(this.DrawHotkeyModCheckbox_Alt);
			this.Hotkey.Controls.Add(this.DrawHotkeyModCheckbox_Shift);
			this.Hotkey.Controls.Add(this.DrawHotkeyModCheckbox_Ctrl);
			this.Hotkey.Controls.Add(this.DrawHotkeyCombobox);
			this.Hotkey.Controls.Add(this.LoseHotkeyModCheckbox_Alt);
			this.Hotkey.Controls.Add(this.LoseHotkeyModCheckbox_Shift);
			this.Hotkey.Controls.Add(this.LoseHotkeyModCheckbox_Ctrl);
			this.Hotkey.Controls.Add(this.LoseHotkeyCombobox);
			this.Hotkey.Controls.Add(this.WinHotkeyModCheckbox_Alt);
			this.Hotkey.Controls.Add(this.WinHotkeyModCheckbox_Shift);
			this.Hotkey.Controls.Add(this.WinHotkeyModCheckbox_Ctrl);
			this.Hotkey.Controls.Add(this.WinHotkeyCombobox);
			this.Hotkey.Controls.Add(this.DrawHotkeyClearButton);
			this.Hotkey.Controls.Add(this.LoseHotkeyClearButton);
			this.Hotkey.Controls.Add(this.WinHotkeyClearButton);
			this.Hotkey.Controls.Add(this.label13);
			this.Hotkey.Controls.Add(this.label12);
			this.Hotkey.Controls.Add(this.label11);
			this.Hotkey.Location = new System.Drawing.Point(4, 24);
			this.Hotkey.Margin = new System.Windows.Forms.Padding(8);
			this.Hotkey.Name = "Hotkey";
			this.Hotkey.Padding = new System.Windows.Forms.Padding(8);
			this.Hotkey.Size = new System.Drawing.Size(416, 390);
			this.Hotkey.TabIndex = 2;
			this.Hotkey.Text = "ホットキー";
			// 
			// DrawHotkeyModCheckbox_Alt
			// 
			this.DrawHotkeyModCheckbox_Alt.AutoSize = true;
			this.DrawHotkeyModCheckbox_Alt.Location = new System.Drawing.Point(182, 96);
			this.DrawHotkeyModCheckbox_Alt.Name = "DrawHotkeyModCheckbox_Alt";
			this.DrawHotkeyModCheckbox_Alt.Size = new System.Drawing.Size(42, 19);
			this.DrawHotkeyModCheckbox_Alt.TabIndex = 20;
			this.DrawHotkeyModCheckbox_Alt.Text = "Alt";
			this.DrawHotkeyModCheckbox_Alt.UseVisualStyleBackColor = true;
			// 
			// DrawHotkeyModCheckbox_Shift
			// 
			this.DrawHotkeyModCheckbox_Shift.AutoSize = true;
			this.DrawHotkeyModCheckbox_Shift.Location = new System.Drawing.Point(123, 96);
			this.DrawHotkeyModCheckbox_Shift.Name = "DrawHotkeyModCheckbox_Shift";
			this.DrawHotkeyModCheckbox_Shift.Size = new System.Drawing.Size(53, 19);
			this.DrawHotkeyModCheckbox_Shift.TabIndex = 19;
			this.DrawHotkeyModCheckbox_Shift.Text = "Shift";
			this.DrawHotkeyModCheckbox_Shift.UseVisualStyleBackColor = true;
			// 
			// DrawHotkeyModCheckbox_Ctrl
			// 
			this.DrawHotkeyModCheckbox_Ctrl.AutoSize = true;
			this.DrawHotkeyModCheckbox_Ctrl.Location = new System.Drawing.Point(70, 96);
			this.DrawHotkeyModCheckbox_Ctrl.Name = "DrawHotkeyModCheckbox_Ctrl";
			this.DrawHotkeyModCheckbox_Ctrl.Size = new System.Drawing.Size(47, 19);
			this.DrawHotkeyModCheckbox_Ctrl.TabIndex = 18;
			this.DrawHotkeyModCheckbox_Ctrl.Text = "Ctrl";
			this.DrawHotkeyModCheckbox_Ctrl.UseVisualStyleBackColor = true;
			// 
			// DrawHotkeyCombobox
			// 
			this.DrawHotkeyCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DrawHotkeyCombobox.FormattingEnabled = true;
			this.DrawHotkeyCombobox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
			this.DrawHotkeyCombobox.Location = new System.Drawing.Point(230, 94);
			this.DrawHotkeyCombobox.Name = "DrawHotkeyCombobox";
			this.DrawHotkeyCombobox.Size = new System.Drawing.Size(95, 23);
			this.DrawHotkeyCombobox.TabIndex = 17;
			// 
			// LoseHotkeyModCheckbox_Alt
			// 
			this.LoseHotkeyModCheckbox_Alt.AutoSize = true;
			this.LoseHotkeyModCheckbox_Alt.Location = new System.Drawing.Point(182, 57);
			this.LoseHotkeyModCheckbox_Alt.Name = "LoseHotkeyModCheckbox_Alt";
			this.LoseHotkeyModCheckbox_Alt.Size = new System.Drawing.Size(42, 19);
			this.LoseHotkeyModCheckbox_Alt.TabIndex = 16;
			this.LoseHotkeyModCheckbox_Alt.Text = "Alt";
			this.LoseHotkeyModCheckbox_Alt.UseVisualStyleBackColor = true;
			// 
			// LoseHotkeyModCheckbox_Shift
			// 
			this.LoseHotkeyModCheckbox_Shift.AutoSize = true;
			this.LoseHotkeyModCheckbox_Shift.Location = new System.Drawing.Point(123, 57);
			this.LoseHotkeyModCheckbox_Shift.Name = "LoseHotkeyModCheckbox_Shift";
			this.LoseHotkeyModCheckbox_Shift.Size = new System.Drawing.Size(53, 19);
			this.LoseHotkeyModCheckbox_Shift.TabIndex = 15;
			this.LoseHotkeyModCheckbox_Shift.Text = "Shift";
			this.LoseHotkeyModCheckbox_Shift.UseVisualStyleBackColor = true;
			// 
			// LoseHotkeyModCheckbox_Ctrl
			// 
			this.LoseHotkeyModCheckbox_Ctrl.AutoSize = true;
			this.LoseHotkeyModCheckbox_Ctrl.Location = new System.Drawing.Point(70, 57);
			this.LoseHotkeyModCheckbox_Ctrl.Name = "LoseHotkeyModCheckbox_Ctrl";
			this.LoseHotkeyModCheckbox_Ctrl.Size = new System.Drawing.Size(47, 19);
			this.LoseHotkeyModCheckbox_Ctrl.TabIndex = 14;
			this.LoseHotkeyModCheckbox_Ctrl.Text = "Ctrl";
			this.LoseHotkeyModCheckbox_Ctrl.UseVisualStyleBackColor = true;
			// 
			// LoseHotkeyCombobox
			// 
			this.LoseHotkeyCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LoseHotkeyCombobox.FormattingEnabled = true;
			this.LoseHotkeyCombobox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
			this.LoseHotkeyCombobox.Location = new System.Drawing.Point(230, 55);
			this.LoseHotkeyCombobox.Name = "LoseHotkeyCombobox";
			this.LoseHotkeyCombobox.Size = new System.Drawing.Size(95, 23);
			this.LoseHotkeyCombobox.TabIndex = 13;
			// 
			// WinHotkeyModCheckbox_Alt
			// 
			this.WinHotkeyModCheckbox_Alt.AutoSize = true;
			this.WinHotkeyModCheckbox_Alt.Location = new System.Drawing.Point(182, 18);
			this.WinHotkeyModCheckbox_Alt.Name = "WinHotkeyModCheckbox_Alt";
			this.WinHotkeyModCheckbox_Alt.Size = new System.Drawing.Size(42, 19);
			this.WinHotkeyModCheckbox_Alt.TabIndex = 12;
			this.WinHotkeyModCheckbox_Alt.Text = "Alt";
			this.WinHotkeyModCheckbox_Alt.UseVisualStyleBackColor = true;
			// 
			// WinHotkeyModCheckbox_Shift
			// 
			this.WinHotkeyModCheckbox_Shift.AutoSize = true;
			this.WinHotkeyModCheckbox_Shift.Location = new System.Drawing.Point(123, 18);
			this.WinHotkeyModCheckbox_Shift.Name = "WinHotkeyModCheckbox_Shift";
			this.WinHotkeyModCheckbox_Shift.Size = new System.Drawing.Size(53, 19);
			this.WinHotkeyModCheckbox_Shift.TabIndex = 11;
			this.WinHotkeyModCheckbox_Shift.Text = "Shift";
			this.WinHotkeyModCheckbox_Shift.UseVisualStyleBackColor = true;
			// 
			// WinHotkeyModCheckbox_Ctrl
			// 
			this.WinHotkeyModCheckbox_Ctrl.AutoSize = true;
			this.WinHotkeyModCheckbox_Ctrl.Location = new System.Drawing.Point(70, 18);
			this.WinHotkeyModCheckbox_Ctrl.Name = "WinHotkeyModCheckbox_Ctrl";
			this.WinHotkeyModCheckbox_Ctrl.Size = new System.Drawing.Size(47, 19);
			this.WinHotkeyModCheckbox_Ctrl.TabIndex = 10;
			this.WinHotkeyModCheckbox_Ctrl.Text = "Ctrl";
			this.WinHotkeyModCheckbox_Ctrl.UseVisualStyleBackColor = true;
			// 
			// WinHotkeyCombobox
			// 
			this.WinHotkeyCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.WinHotkeyCombobox.FormattingEnabled = true;
			this.WinHotkeyCombobox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
			this.WinHotkeyCombobox.Location = new System.Drawing.Point(230, 16);
			this.WinHotkeyCombobox.Name = "WinHotkeyCombobox";
			this.WinHotkeyCombobox.Size = new System.Drawing.Size(95, 23);
			this.WinHotkeyCombobox.TabIndex = 9;
			// 
			// DrawHotkeyClearButton
			// 
			this.DrawHotkeyClearButton.Location = new System.Drawing.Point(336, 94);
			this.DrawHotkeyClearButton.Margin = new System.Windows.Forms.Padding(8);
			this.DrawHotkeyClearButton.Name = "DrawHotkeyClearButton";
			this.DrawHotkeyClearButton.Size = new System.Drawing.Size(62, 23);
			this.DrawHotkeyClearButton.TabIndex = 8;
			this.DrawHotkeyClearButton.Text = "クリア";
			this.DrawHotkeyClearButton.UseVisualStyleBackColor = true;
			this.DrawHotkeyClearButton.Click += new System.EventHandler(this.DrawHotkeyClearButton_Click);
			// 
			// LoseHotkeyClearButton
			// 
			this.LoseHotkeyClearButton.Location = new System.Drawing.Point(336, 55);
			this.LoseHotkeyClearButton.Margin = new System.Windows.Forms.Padding(8);
			this.LoseHotkeyClearButton.Name = "LoseHotkeyClearButton";
			this.LoseHotkeyClearButton.Size = new System.Drawing.Size(64, 23);
			this.LoseHotkeyClearButton.TabIndex = 7;
			this.LoseHotkeyClearButton.Text = "クリア";
			this.LoseHotkeyClearButton.UseVisualStyleBackColor = true;
			this.LoseHotkeyClearButton.Click += new System.EventHandler(this.LoseHotkeyClearButton_Click);
			// 
			// WinHotkeyClearButton
			// 
			this.WinHotkeyClearButton.Location = new System.Drawing.Point(336, 16);
			this.WinHotkeyClearButton.Margin = new System.Windows.Forms.Padding(8);
			this.WinHotkeyClearButton.Name = "WinHotkeyClearButton";
			this.WinHotkeyClearButton.Size = new System.Drawing.Size(64, 23);
			this.WinHotkeyClearButton.TabIndex = 6;
			this.WinHotkeyClearButton.Text = "クリア";
			this.WinHotkeyClearButton.UseVisualStyleBackColor = true;
			this.WinHotkeyClearButton.Click += new System.EventHandler(this.WinHotkeyClearButton_Click);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(16, 97);
			this.label13.Margin = new System.Windows.Forms.Padding(8);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(43, 15);
			this.label13.TabIndex = 2;
			this.label13.Text = "Draw:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(20, 58);
			this.label12.Margin = new System.Windows.Forms.Padding(8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(39, 15);
			this.label12.TabIndex = 1;
			this.label12.Text = "Lose:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(25, 19);
			this.label11.Margin = new System.Windows.Forms.Padding(8);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(34, 15);
			this.label11.TabIndex = 0;
			this.label11.Text = "Win:";
			// 
			// General
			// 
			this.General.BackColor = System.Drawing.SystemColors.Control;
			this.General.Controls.Add(this.ProductionGroup);
			this.General.Controls.Add(this.ScoreBoardGroup);
			this.General.Location = new System.Drawing.Point(4, 24);
			this.General.Margin = new System.Windows.Forms.Padding(8);
			this.General.Name = "General";
			this.General.Padding = new System.Windows.Forms.Padding(8);
			this.General.Size = new System.Drawing.Size(416, 390);
			this.General.TabIndex = 0;
			this.General.Text = "基本";
			// 
			// ProductionGroup
			// 
			this.ProductionGroup.Controls.Add(this.EnableProductionCheckbox);
			this.ProductionGroup.Controls.Add(this.VolumeLabel);
			this.ProductionGroup.Controls.Add(this.VolumeTrackbar);
			this.ProductionGroup.Controls.Add(this.FontColorLabel);
			this.ProductionGroup.Controls.Add(this.MainColorLabel);
			this.ProductionGroup.Controls.Add(this.FontColorBox);
			this.ProductionGroup.Controls.Add(this.MainColorBox);
			this.ProductionGroup.Controls.Add(this.NameTextBox);
			this.ProductionGroup.Controls.Add(this.SubColorBox);
			this.ProductionGroup.Controls.Add(this.NameLabel);
			this.ProductionGroup.Controls.Add(this.SubColorLabel);
			this.ProductionGroup.Controls.Add(this.LogoPictureBox);
			this.ProductionGroup.Controls.Add(this.LogoLabel);
			this.ProductionGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ProductionGroup.Location = new System.Drawing.Point(16, 16);
			this.ProductionGroup.Margin = new System.Windows.Forms.Padding(8);
			this.ProductionGroup.Name = "ProductionGroup";
			this.ProductionGroup.Padding = new System.Windows.Forms.Padding(8);
			this.ProductionGroup.Size = new System.Drawing.Size(384, 262);
			this.ProductionGroup.TabIndex = 0;
			this.ProductionGroup.TabStop = false;
			this.ProductionGroup.Text = "勝敗演出";
			// 
			// EnableProductionCheckbox
			// 
			this.EnableProductionCheckbox.AutoSize = true;
			this.EnableProductionCheckbox.Checked = true;
			this.EnableProductionCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.EnableProductionCheckbox.Location = new System.Drawing.Point(16, 32);
			this.EnableProductionCheckbox.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
			this.EnableProductionCheckbox.Name = "EnableProductionCheckbox";
			this.EnableProductionCheckbox.Size = new System.Drawing.Size(135, 19);
			this.EnableProductionCheckbox.TabIndex = 5;
			this.EnableProductionCheckbox.Text = "勝敗演出を有効にする";
			this.EnableProductionCheckbox.UseVisualStyleBackColor = true;
			this.EnableProductionCheckbox.CheckedChanged += new System.EventHandler(this.EnableProductionCheckbox_CheckedChanged);
			// 
			// VolumeLabel
			// 
			this.VolumeLabel.Location = new System.Drawing.Point(208, 190);
			this.VolumeLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.VolumeLabel.Name = "VolumeLabel";
			this.VolumeLabel.Size = new System.Drawing.Size(160, 24);
			this.VolumeLabel.TabIndex = 7;
			this.VolumeLabel.Text = "音量";
			this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VolumeTrackbar
			// 
			this.VolumeTrackbar.AutoSize = false;
			this.VolumeTrackbar.Location = new System.Drawing.Point(216, 222);
			this.VolumeTrackbar.Margin = new System.Windows.Forms.Padding(8);
			this.VolumeTrackbar.Maximum = 100;
			this.VolumeTrackbar.Name = "VolumeTrackbar";
			this.VolumeTrackbar.Size = new System.Drawing.Size(152, 24);
			this.VolumeTrackbar.TabIndex = 0;
			this.VolumeTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.VolumeTrackbar.Value = 100;
			this.VolumeTrackbar.Scroll += new System.EventHandler(this.VolumeTrackbar_Scroll);
			// 
			// FontColorLabel
			// 
			this.FontColorLabel.Location = new System.Drawing.Point(204, 144);
			this.FontColorLabel.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
			this.FontColorLabel.Name = "FontColorLabel";
			this.FontColorLabel.Size = new System.Drawing.Size(108, 24);
			this.FontColorLabel.TabIndex = 5;
			this.FontColorLabel.Text = "フォントカラー:";
			this.FontColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// MainColorLabel
			// 
			this.MainColorLabel.Location = new System.Drawing.Point(204, 64);
			this.MainColorLabel.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
			this.MainColorLabel.Name = "MainColorLabel";
			this.MainColorLabel.Size = new System.Drawing.Size(108, 24);
			this.MainColorLabel.TabIndex = 1;
			this.MainColorLabel.Text = "メインカラー:";
			this.MainColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FontColorBox
			// 
			this.FontColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.FontColorBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FontColorBox.Location = new System.Drawing.Point(320, 144);
			this.FontColorBox.Margin = new System.Windows.Forms.Padding(4, 8, 8, 8);
			this.FontColorBox.Name = "FontColorBox";
			this.FontColorBox.Size = new System.Drawing.Size(48, 24);
			this.FontColorBox.TabIndex = 4;
			this.FontColorBox.TabStop = false;
			this.FontColorBox.Click += new System.EventHandler(this.ColorSelect);
			// 
			// MainColorBox
			// 
			this.MainColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.MainColorBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MainColorBox.Location = new System.Drawing.Point(320, 64);
			this.MainColorBox.Margin = new System.Windows.Forms.Padding(4, 8, 8, 8);
			this.MainColorBox.Name = "MainColorBox";
			this.MainColorBox.Size = new System.Drawing.Size(48, 24);
			this.MainColorBox.TabIndex = 0;
			this.MainColorBox.TabStop = false;
			this.MainColorBox.Click += new System.EventHandler(this.ColorSelect);
			// 
			// NameTextBox
			// 
			this.NameTextBox.Location = new System.Drawing.Point(68, 64);
			this.NameTextBox.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(128, 23);
			this.NameTextBox.TabIndex = 4;
			// 
			// SubColorBox
			// 
			this.SubColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.SubColorBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SubColorBox.Location = new System.Drawing.Point(320, 104);
			this.SubColorBox.Margin = new System.Windows.Forms.Padding(4, 8, 8, 8);
			this.SubColorBox.Name = "SubColorBox";
			this.SubColorBox.Size = new System.Drawing.Size(48, 24);
			this.SubColorBox.TabIndex = 3;
			this.SubColorBox.TabStop = false;
			this.SubColorBox.Click += new System.EventHandler(this.ColorSelect);
			// 
			// NameLabel
			// 
			this.NameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.NameLabel.Location = new System.Drawing.Point(12, 63);
			this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(48, 24);
			this.NameLabel.TabIndex = 3;
			this.NameLabel.Text = "名前:";
			this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubColorLabel
			// 
			this.SubColorLabel.Location = new System.Drawing.Point(204, 104);
			this.SubColorLabel.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
			this.SubColorLabel.Name = "SubColorLabel";
			this.SubColorLabel.Size = new System.Drawing.Size(108, 24);
			this.SubColorLabel.TabIndex = 2;
			this.SubColorLabel.Text = "サブカラー:";
			this.SubColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LogoPictureBox
			// 
			this.LogoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.LogoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LogoPictureBox.Enabled = false;
			this.LogoPictureBox.Location = new System.Drawing.Point(68, 103);
			this.LogoPictureBox.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
			this.LogoPictureBox.Name = "LogoPictureBox";
			this.LogoPictureBox.Size = new System.Drawing.Size(128, 128);
			this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.LogoPictureBox.TabIndex = 1;
			this.LogoPictureBox.TabStop = false;
			this.LogoPictureBox.Click += new System.EventHandler(this.LogoPictureBox_Click);
			// 
			// LogoLabel
			// 
			this.LogoLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LogoLabel.Location = new System.Drawing.Point(12, 104);
			this.LogoLabel.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
			this.LogoLabel.Name = "LogoLabel";
			this.LogoLabel.Size = new System.Drawing.Size(48, 24);
			this.LogoLabel.TabIndex = 0;
			this.LogoLabel.Text = "ロゴ:";
			this.LogoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ScoreBoardGroup
			// 
			this.ScoreBoardGroup.Controls.Add(this.ScoreBoardSizeLabel);
			this.ScoreBoardGroup.Controls.Add(this.ScoreBoardPositionRadioPanel);
			this.ScoreBoardGroup.Controls.Add(this.ScoreBoardSizeTrackbar);
			this.ScoreBoardGroup.Location = new System.Drawing.Point(16, 294);
			this.ScoreBoardGroup.Margin = new System.Windows.Forms.Padding(8);
			this.ScoreBoardGroup.Name = "ScoreBoardGroup";
			this.ScoreBoardGroup.Padding = new System.Windows.Forms.Padding(8);
			this.ScoreBoardGroup.Size = new System.Drawing.Size(384, 80);
			this.ScoreBoardGroup.TabIndex = 3;
			this.ScoreBoardGroup.TabStop = false;
			this.ScoreBoardGroup.Text = "スコアボード";
			// 
			// ScoreBoardSizeLabel
			// 
			this.ScoreBoardSizeLabel.AutoSize = true;
			this.ScoreBoardSizeLabel.Location = new System.Drawing.Point(16, 24);
			this.ScoreBoardSizeLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.ScoreBoardSizeLabel.Name = "ScoreBoardSizeLabel";
			this.ScoreBoardSizeLabel.Size = new System.Drawing.Size(36, 15);
			this.ScoreBoardSizeLabel.TabIndex = 6;
			this.ScoreBoardSizeLabel.Text = "大きさ";
			// 
			// ScoreBoardPositionRadioPanel
			// 
			this.ScoreBoardPositionRadioPanel.Controls.Add(this.ScoreBoardPositionLabel);
			this.ScoreBoardPositionRadioPanel.Controls.Add(this.ScoreBoardPositionRadio_Top);
			this.ScoreBoardPositionRadioPanel.Controls.Add(this.ScoreBoardPositionRadio_Bottom);
			this.ScoreBoardPositionRadioPanel.Location = new System.Drawing.Point(238, 24);
			this.ScoreBoardPositionRadioPanel.Margin = new System.Windows.Forms.Padding(8);
			this.ScoreBoardPositionRadioPanel.Name = "ScoreBoardPositionRadioPanel";
			this.ScoreBoardPositionRadioPanel.Size = new System.Drawing.Size(130, 47);
			this.ScoreBoardPositionRadioPanel.TabIndex = 5;
			// 
			// ScoreBoardPositionLabel
			// 
			this.ScoreBoardPositionLabel.AutoSize = true;
			this.ScoreBoardPositionLabel.Location = new System.Drawing.Point(3, 0);
			this.ScoreBoardPositionLabel.Name = "ScoreBoardPositionLabel";
			this.ScoreBoardPositionLabel.Size = new System.Drawing.Size(55, 15);
			this.ScoreBoardPositionLabel.TabIndex = 6;
			this.ScoreBoardPositionLabel.Text = "表示位置";
			// 
			// ScoreBoardPositionRadio_Top
			// 
			this.ScoreBoardPositionRadio_Top.AutoSize = true;
			this.ScoreBoardPositionRadio_Top.Location = new System.Drawing.Point(6, 22);
			this.ScoreBoardPositionRadio_Top.Name = "ScoreBoardPositionRadio_Top";
			this.ScoreBoardPositionRadio_Top.Size = new System.Drawing.Size(37, 19);
			this.ScoreBoardPositionRadio_Top.TabIndex = 1;
			this.ScoreBoardPositionRadio_Top.TabStop = true;
			this.ScoreBoardPositionRadio_Top.Text = "上";
			this.ScoreBoardPositionRadio_Top.UseVisualStyleBackColor = true;
			// 
			// ScoreBoardPositionRadio_Bottom
			// 
			this.ScoreBoardPositionRadio_Bottom.AutoSize = true;
			this.ScoreBoardPositionRadio_Bottom.Location = new System.Drawing.Point(58, 22);
			this.ScoreBoardPositionRadio_Bottom.Name = "ScoreBoardPositionRadio_Bottom";
			this.ScoreBoardPositionRadio_Bottom.Size = new System.Drawing.Size(37, 19);
			this.ScoreBoardPositionRadio_Bottom.TabIndex = 4;
			this.ScoreBoardPositionRadio_Bottom.TabStop = true;
			this.ScoreBoardPositionRadio_Bottom.Text = "下";
			this.ScoreBoardPositionRadio_Bottom.UseVisualStyleBackColor = true;
			// 
			// ScoreBoardSizeTrackbar
			// 
			this.ScoreBoardSizeTrackbar.AutoSize = false;
			this.ScoreBoardSizeTrackbar.BackColor = System.Drawing.SystemColors.Control;
			this.ScoreBoardSizeTrackbar.Location = new System.Drawing.Point(14, 47);
			this.ScoreBoardSizeTrackbar.Margin = new System.Windows.Forms.Padding(8);
			this.ScoreBoardSizeTrackbar.Maximum = 200;
			this.ScoreBoardSizeTrackbar.Name = "ScoreBoardSizeTrackbar";
			this.ScoreBoardSizeTrackbar.Size = new System.Drawing.Size(195, 24);
			this.ScoreBoardSizeTrackbar.TabIndex = 0;
			this.ScoreBoardSizeTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.ScoreBoardSizeTrackbar.Value = 100;
			this.ScoreBoardSizeTrackbar.Scroll += new System.EventHandler(this.ScoreBoardSizeTrackbar_Scroll);
			// 
			// SettingsTabControl
			// 
			this.SettingsTabControl.Controls.Add(this.General);
			this.SettingsTabControl.Controls.Add(this.Hotkey);
			this.SettingsTabControl.Location = new System.Drawing.Point(17, 17);
			this.SettingsTabControl.Margin = new System.Windows.Forms.Padding(8);
			this.SettingsTabControl.Name = "SettingsTabControl";
			this.SettingsTabControl.SelectedIndex = 0;
			this.SettingsTabControl.Size = new System.Drawing.Size(424, 418);
			this.SettingsTabControl.TabIndex = 4;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(458, 491);
			this.Controls.Add(this.SettingsTabControl);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OKButton);
			this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SettingsForm";
			this.Text = "OwScoreBoard 設定";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.Hotkey.ResumeLayout(false);
			this.Hotkey.PerformLayout();
			this.General.ResumeLayout(false);
			this.ProductionGroup.ResumeLayout(false);
			this.ProductionGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.VolumeTrackbar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FontColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MainColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SubColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
			this.ScoreBoardGroup.ResumeLayout(false);
			this.ScoreBoardGroup.PerformLayout();
			this.ScoreBoardPositionRadioPanel.ResumeLayout(false);
			this.ScoreBoardPositionRadioPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ScoreBoardSizeTrackbar)).EndInit();
			this.SettingsTabControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.ToolTip Tooltip;
		private System.Windows.Forms.TabPage Hotkey;
		private System.Windows.Forms.TabPage General;
		private System.Windows.Forms.GroupBox ProductionGroup;
		private System.Windows.Forms.Label VolumeLabel;
		private System.Windows.Forms.TrackBar VolumeTrackbar;
		private System.Windows.Forms.Label FontColorLabel;
		private System.Windows.Forms.Label MainColorLabel;
		private System.Windows.Forms.PictureBox FontColorBox;
		private System.Windows.Forms.PictureBox MainColorBox;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.PictureBox SubColorBox;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label SubColorLabel;
		private System.Windows.Forms.PictureBox LogoPictureBox;
		private System.Windows.Forms.Label LogoLabel;
		private System.Windows.Forms.GroupBox ScoreBoardGroup;
		private System.Windows.Forms.Label ScoreBoardSizeLabel;
		private System.Windows.Forms.Panel ScoreBoardPositionRadioPanel;
		private System.Windows.Forms.Label ScoreBoardPositionLabel;
		private System.Windows.Forms.RadioButton ScoreBoardPositionRadio_Top;
		private System.Windows.Forms.RadioButton ScoreBoardPositionRadio_Bottom;
		private System.Windows.Forms.TrackBar ScoreBoardSizeTrackbar;
		private System.Windows.Forms.TabControl SettingsTabControl;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button DrawHotkeyClearButton;
		private System.Windows.Forms.Button WinHotkeyClearButton;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox WinHotkeyCombobox;
		private System.Windows.Forms.CheckBox WinHotkeyModCheckbox_Alt;
		private System.Windows.Forms.CheckBox WinHotkeyModCheckbox_Shift;
		private System.Windows.Forms.CheckBox WinHotkeyModCheckbox_Ctrl;
		private System.Windows.Forms.Button LoseHotkeyClearButton;
		private System.Windows.Forms.CheckBox DrawHotkeyModCheckbox_Alt;
		private System.Windows.Forms.CheckBox DrawHotkeyModCheckbox_Shift;
		private System.Windows.Forms.CheckBox DrawHotkeyModCheckbox_Ctrl;
		private System.Windows.Forms.ComboBox DrawHotkeyCombobox;
		private System.Windows.Forms.CheckBox LoseHotkeyModCheckbox_Alt;
		private System.Windows.Forms.CheckBox LoseHotkeyModCheckbox_Shift;
		private System.Windows.Forms.CheckBox LoseHotkeyModCheckbox_Ctrl;
		private System.Windows.Forms.ComboBox LoseHotkeyCombobox;
        private System.Windows.Forms.CheckBox EnableProductionCheckbox;
    }
}