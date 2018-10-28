using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace OwScoreBoardController
{
	public partial class MainForm : Form
	{
		HotKey WinHotkey;
		HotKey LoseHotkey;
		HotKey DrawHotkey;

		public MainForm()
		{
			InitializeComponent();
		}

		private void OnLoad( object sender, EventArgs e )
		{
			// 前回のウィンドウ位置を復元
			Point WindowPosition = Properties.Settings.Default.WindowPosition;
			Point UnsetValue = new Point(-1234, -5678);
			if( WindowPosition != UnsetValue )
			{
				DesktopLocation = WindowPosition;
			}

			// 最大化ボタンを無効化
			this.MaximizeBox = false;

			// 言語設定を復元
			switch(Properties.Settings.Default.Language)
			{
				case "ja-JP":
					MenuItem_Language_Japanese_Click(null, null);
					break;
				case "en-US":
					MenuItem_Language_English_Click(null, null);
					break;
				case "Automatic":
				default:
					MenuItem_Language_Automatic_Click(null, null);
					break;
			}
			SetLanguage();

			// Score を読み込んで値をセット
			ScoreManager.Score Score = ScoreManager.Load();
			WinsUpDown.Value = Score.Wins;
			LosesUpDown.Value = Score.Loses;
			DrawsUpDown.Value = Score.Draws;
			StartingRateUpDown.Value = Score.StartingRate;

			// ホットキーをセット
			SetHotkeyFromConfig();
		}

		private void LosesUpDown_ValueChanged( object sender, EventArgs e )
		{
			if( LosesUpDown.Value.ToString() == "" )
			{
				LosesUpDown.Value = 0;
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void WinsUpDown_ValueChanged( object sender, EventArgs e )
		{
			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void StartingRateUpDown_ValueChanged( object sender, EventArgs e )
		{
			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void DrawsUpDown_ValueChanged( object sender, EventArgs e )
		{
			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void SaveTimer_Tick( object sender, EventArgs e )
		{
			ScoreManager.Score Score = new ScoreManager.Score( (int)WinsUpDown.Value, (int)LosesUpDown.Value, (int)DrawsUpDown.Value, (int)StartingRateUpDown.Value, InPlacementCheckbox.Checked );
			ScoreManager.Save( Score );

			SaveTimer.Enabled = false;
			WinButton.Enabled = true;
			LoseButton.Enabled = true;
			DrawButton.Enabled = true;
			ResetButton.Enabled = true;
		}

		private void ResetTimer()
		{
			SaveTimer.Enabled = false;
			SaveTimer.Enabled = true;
		}

		private void WinButton_Click( object sender, EventArgs e )
		{
			if( WinButton.Enabled )
			{
				WinsUpDown.Value++;

				if( !MenuItem_StopUpdate.Checked )
				{
					WinButton.Enabled = false;
					LoseButton.Enabled = false;
					DrawButton.Enabled = false;
					ResetButton.Enabled = false;
					ResetTimer();
				}
			}
		}

		private void LoseButton_Click( object sender, EventArgs e )
		{
			if( LoseButton.Enabled )
			{
				LosesUpDown.Value++;

				if( !MenuItem_StopUpdate.Checked )
				{
					WinButton.Enabled = false;
					LoseButton.Enabled = false;
					DrawButton.Enabled = false;
					ResetButton.Enabled = false;
					ResetTimer();
				}
			}
		}

		private void DrawButton_Click( object sender, EventArgs e )
		{
			if( DrawButton.Enabled )
			{
				DrawsUpDown.Value++;

				if( !MenuItem_StopUpdate.Checked )
				{
					WinButton.Enabled = false;
					LoseButton.Enabled = false;
					DrawButton.Enabled = false;
					ResetButton.Enabled = false;
					ResetTimer();
				}
			}
		}

		private void ResetButton_Click( object sender, EventArgs e )
		{
			DialogResult Result = MessageBox.Show( "スコアをリセットしてよろしいですか？",
				"スコアのリセット",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button2 );

			if( Result == DialogResult.OK )
			{
				WinsUpDown.Value = 0;
				LosesUpDown.Value = 0;
				DrawsUpDown.Value = 0;

				if( !MenuItem_StopUpdate.Checked )
				{
					WinButton.Enabled = false;
					LoseButton.Enabled = false;
					DrawButton.Enabled = false;
					ResetButton.Enabled = false;
					ResetTimer();
				}
			}
		}

		private void MenuItem_Version_Click( object sender, EventArgs e )
		{
			Form VersionInfoForm = new VersionInfoForm();
			VersionInfoForm.ShowInTaskbar = false;
			VersionInfoForm.ShowDialog();
		}

		private void MenuItem_Manual_Click( object sender, EventArgs e )
		{
			System.Diagnostics.Process.Start( "https://github.com/HIJIKIsw/OwScoreBoard/blob/master/Help.md" );
		}

		private void MenuItem_AlwayOnTop_Click( object sender, EventArgs e )
		{
			this.TopMost = MenuItem_AlwayOnTop.Checked;
			Properties.Settings.Default.AlwaysOnTop = MenuItem_AlwayOnTop.Checked;
		}

		private void MenuItem_Exit_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void MenuItem_Settings_Click( object sender, EventArgs e )
		{
			// ホットキーを無効化
			if( WinHotkey != null ) WinHotkey.Dispose();
			if( LoseHotkey != null ) LoseHotkey.Dispose();
			if( DrawHotkey != null ) DrawHotkey.Dispose();
			WinHotkey = new HotKey( MOD_KEY.NONE, Keys.None );
			LoseHotkey = new HotKey( MOD_KEY.NONE, Keys.None );
			DrawHotkey = new HotKey( MOD_KEY.NONE, Keys.None );

			Form SettingsForm = new SettingsForm();
			SettingsForm.ShowInTaskbar = false;
			SettingsForm.ShowDialog();
			SetHotkeyFromConfig();
		}

		private void MenuItem_StopUpdate_Click( object sender, EventArgs e )
		{
			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void StartingRateUpDown_KeyUp( object sender, KeyEventArgs e )
		{
			if( StartingRateUpDown.Text == string.Empty )
			{
				StartingRateUpDown.Value = 1;
				StartingRateUpDown.Text = "1";
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void WinsUpDown_KeyUp( object sender, KeyEventArgs e )
		{
			if( WinsUpDown.Text == string.Empty )
			{
				WinsUpDown.Value = 0;
				WinsUpDown.Text = "0";
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void LosesUpDown_KeyUp( object sender, KeyEventArgs e )
		{
			if( LosesUpDown.Text == string.Empty )
			{
				LosesUpDown.Value = 0;
				LosesUpDown.Text = "0";
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void DrawsUpDown_KeyUp( object sender, KeyEventArgs e )
		{
			if( DrawsUpDown.Text == string.Empty )
			{
				DrawsUpDown.Value = 0;
				DrawsUpDown.Text = "0";
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			// ホットキーのフックを解除
			if( WinHotkey != null ) WinHotkey.Dispose();
			if( LoseHotkey != null ) LoseHotkey.Dispose();
			if( DrawHotkey != null ) DrawHotkey.Dispose();

			// ウィンドウの位置を記憶
			Properties.Settings.Default.WindowPosition = DesktopLocation;

			// 設定を保存する
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// Config を読み込んでホットキーをセット
		/// </summary>
		private void SetHotkeyFromConfig()
		{
			ConfigManager.Config Config = ConfigManager.Load();
			if (Config.WinHotkey.KeyCode != Keys.None && Config.WinHotkey != null)
			{
				WinHotkey = new HotKey(Config.WinHotkey.ModKey, Config.WinHotkey.KeyCode);
				WinHotkey.HotKeyPush += new EventHandler(WinButton_Click);
			}
			if (Config.LoseHotkey.KeyCode != Keys.None && Config.LoseHotkey != null)
			{
				LoseHotkey = new HotKey(Config.LoseHotkey.ModKey, Config.LoseHotkey.KeyCode);
				LoseHotkey.HotKeyPush += new EventHandler(LoseButton_Click);
			}
			if (Config.DrawHotkey.KeyCode != Keys.None && Config.DrawHotkey != null)
			{
				DrawHotkey = new HotKey(Config.DrawHotkey.ModKey, Config.DrawHotkey.KeyCode);
				DrawHotkey.HotKeyPush += new EventHandler(DrawButton_Click);
			}
		}

		/// <summary>
		/// 言語をセット
		/// </summary>
		private void SetLanguage()
		{
			LanguageManager.Language Language;

			// 設定に応じた言語オブジェクトを取得
			if( Properties.Settings.Default.Language == "Automatic" )
			{
				// OS の言語を取得
				string OSLanguage = System.Globalization.CultureInfo.CurrentCulture.Name;
				Language = LanguageManager.Get(OSLanguage);
			}
			else
			{
				Language = LanguageManager.Get(Properties.Settings.Default.Language);
			}

			// 各文言をセット
			FileMenu.Text = Language.mainForm.FileMenu;
			MenuItem_Exit.Text = Language.mainForm.MenuItem_Exit;
			OptionMenu.Text = Language.mainForm.OptionMenu;
			MenuItem_AlwayOnTop.Text = Language.mainForm.MenuItem_AlwayOnTop;
			MenuItem_StopUpdate.Text = Language.mainForm.MenuItem_StopUpdate;
			MenuItem_Language.Text = Language.mainForm.MenuItem_Language;
			MenuItem_Language_Automatic.Text = Language.mainForm.MenuItem_Language_Automatic;
			MenuItem_Settings.Text = Language.mainForm.MenuItem_Settings;
			HelpMenu.Text = Language.mainForm.HelpMenu;
			MenuItem_Manual.Text = Language.mainForm.MenuItem_Manual;
			MenuItem_Version.Text = Language.mainForm.MenuItem_Version;
		}

		private void MenuItem_Language_Automatic_Click(object sender, EventArgs e)
		{
			MenuItem_Language_Automatic.Checked = true;
			MenuItem_Language_Japanese.Checked = false;
			MenuItem_Language_English.Checked = false;

			Properties.Settings.Default.Language = "Automatic";
			SetLanguage();
		}

		private void MenuItem_Language_Japanese_Click(object sender, EventArgs e)
		{
			MenuItem_Language_Automatic.Checked = false;
			MenuItem_Language_Japanese.Checked = true;
			MenuItem_Language_English.Checked = false;

			Properties.Settings.Default.Language = "ja-JP";
			SetLanguage();
		}

		private void MenuItem_Language_English_Click(object sender, EventArgs e)
		{
			MenuItem_Language_Automatic.Checked = false;
			MenuItem_Language_Japanese.Checked = false;
			MenuItem_Language_English.Checked = true;

			Properties.Settings.Default.Language = "en-US";
			SetLanguage();
		}

		private void InPlacementCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}

			StartingRateUpDown.Enabled = !InPlacementCheckbox.Checked;
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			// 常に最前面に表示状態を復元
			this.TopMost = Properties.Settings.Default.AlwaysOnTop;
			MenuItem_AlwayOnTop.Checked = this.TopMost;
		}
	}
}
