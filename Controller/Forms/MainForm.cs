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
			TankStartingRateEnabledCheckBox.Checked = Score.IsTankStartingRateEnabled;
			DamageStartingRateEnabledCheckBox.Checked = Score.IsDamageStartingRateEnabled;
			SupportStartingRateEnabledCheckBox.Checked = Score.IsSupportStartingRateEnabled;
			TankStartingRateUpDown.Value = Score.TankStartingRate;
			DamageStartingRateUpDown.Value = Score.DamageStartingRate;
			SupportStartingRateUpDown.Value = Score.SupportStartingRate;
			TankInPlacementCheckbox.Checked = Score.IsTankInPlacement;
			DamageInPlacementCheckbox.Checked = Score.IsDamageInPlacement;
			SupportInPlacementCheckbox.Checked = Score.IsSupportInPlacement;
			SetQueMode(Score.IsOpenQueueMode);

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

		private void TankStartingRateUpDown_ValueChanged( object sender, EventArgs e )
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

		private void DamageStartingRateUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void SupportStartingRateUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (!MenuItem_StopUpdate.Checked)
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
			SaveScore();

			SaveTimer.Enabled = false;
			WinButton.Enabled = true;
			LoseButton.Enabled = true;
			DrawButton.Enabled = true;
		}

		private void SaveScore()
		{
			ScoreManager.Score Score = new ScoreManager.Score
			(
				(int)WinsUpDown.Value, (int)LosesUpDown.Value, (int)DrawsUpDown.Value,
				TankStartingRateEnabledCheckBox.Checked, DamageStartingRateEnabledCheckBox.Checked, SupportStartingRateEnabledCheckBox.Checked,
				(int)TankStartingRateUpDown.Value, (int)DamageStartingRateUpDown.Value, (int)SupportStartingRateUpDown.Value,
				TankInPlacementCheckbox.Checked, DamageInPlacementCheckbox.Checked, SupportInPlacementCheckbox.Checked,
				MenuItem_SwitchMode_OpenQueue.Checked
			);
			ScoreManager.Save(Score);
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
					ResetTimer();
				}
			}
		}

		private void MenuItem_ClearScore_Click( object sender, EventArgs e )
		{
			LanguageManager.Language Language;

			// 設定に応じた言語オブジェクトを取得
			if (Properties.Settings.Default.Language == "Automatic")
			{
				// OS の言語を取得
				string OSLanguage = System.Globalization.CultureInfo.CurrentCulture.Name;
				Language = LanguageManager.Get(OSLanguage);
			}
			else
			{
				Language = LanguageManager.Get(Properties.Settings.Default.Language);
			}

			string ConfirmMessage = Language.ScoreClearConfirmMessage;
			string ConfirmTitle = Language.ScoreClearConfirmTitle;


			DialogResult Result = MessageBox.Show( ConfirmMessage,
				ConfirmTitle,
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
			string Language;

			// 設定に応じたヘルプドキュメントを開く
			if (Properties.Settings.Default.Language == "Automatic")
			{
				// OS の言語を取得
				Language = System.Globalization.CultureInfo.CurrentCulture.Name;
			}
			else
			{
				Language = Properties.Settings.Default.Language;
			}

			if (Language == "ja-JP")
			{
				System.Diagnostics.Process.Start("https://github.com/HIJIKIsw/OwScoreBoard/blob/master/Help_ja.md");
			}
			else
			{
				System.Diagnostics.Process.Start("https://github.com/HIJIKIsw/OwScoreBoard/blob/master/Help_en.md");
			}

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

		private void TankStartingRateUpDown_KeyUp( object sender, KeyEventArgs e )
		{
			if( TankStartingRateUpDown.Text == string.Empty )
			{
				TankStartingRateUpDown.Value = 1;
				TankStartingRateUpDown.Text = "1";
			}

			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void DamageStartingRateUpDown_KeyUp(object sender, KeyEventArgs e)
		{
			if (DamageStartingRateUpDown.Text == string.Empty)
			{
				DamageStartingRateUpDown.Value = 1;
				DamageStartingRateUpDown.Text = "1";
			}

			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
		}

		private void SupportStartingRateUpDown_KeyUp(object sender, KeyEventArgs e)
		{
			if (SupportStartingRateUpDown.Text == string.Empty)
			{
				SupportStartingRateUpDown.Value = 1;
				SupportStartingRateUpDown.Text = "1";
			}

			if (!MenuItem_StopUpdate.Checked)
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
			SaveScore();
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
			MenuItem_ClearScore.Text = Language.mainForm.MenuItem_ClearScore;
			MenuItem_SwitchMode.Text = Language.mainForm.MenuItem_SwitchMode;
			MenuItem_SwitchMode_RoleQueue.Text = Language.mainForm.MenuItem_SwitchMode_RoleQueue;
			MenuItem_SwitchMode_OpenQueue.Text = Language.mainForm.MenuItem_SwitchMode_OpenQueue;
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

			TankStartingRateUpDown.Enabled = !TankInPlacementCheckbox.Checked;
		}

		private void DamageInPlacementCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}

			DamageStartingRateUpDown.Enabled = !DamageInPlacementCheckbox.Checked;
		}

		private void SupportInPlacementCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}

			SupportStartingRateUpDown.Enabled = !SupportInPlacementCheckbox.Checked;
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			// 常に最前面に表示状態を復元
			this.TopMost = Properties.Settings.Default.AlwaysOnTop;
			MenuItem_AlwayOnTop.Checked = this.TopMost;
		}

		private void StartingRateTankCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool enabled = TankStartingRateEnabledCheckBox.Checked;
			TankStartingRateUpDown.Enabled = enabled && !TankInPlacementCheckbox.Checked;
			TankInPlacementCheckbox.Enabled = enabled;

			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void StartingRateDamageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool enabled = DamageStartingRateEnabledCheckBox.Checked;
			DamageStartingRateUpDown.Enabled = enabled && !DamageInPlacementCheckbox.Checked;
			DamageInPlacementCheckbox.Enabled = enabled;

			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void StartingRateSupportCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool enabled = SupportStartingRateEnabledCheckBox.Checked;
			SupportStartingRateUpDown.Enabled = enabled && !SupportInPlacementCheckbox.Checked;
			SupportInPlacementCheckbox.Enabled = enabled;

			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}

		private void MenuItem_SwitchOpenQueueMode_Click(object sender, EventArgs e)
		{
			SetQueMode(true);
		}

		private void MenuItem_SwitchRoleQueueMode_Click(object sender, EventArgs e)
		{
			SetQueMode(false);
		}

		private void SetQueMode(bool IsOpenQueueMode)
		{
			MenuItem_SwitchMode_OpenQueue.Checked = IsOpenQueueMode;
			MenuItem_SwitchMode_RoleQueue.Checked = !IsOpenQueueMode;

			TankStartingRateEnabledCheckBox.Enabled = !IsOpenQueueMode;
			DamageStartingRateEnabledCheckBox.Enabled = !IsOpenQueueMode;
			SupportStartingRateEnabledCheckBox.Enabled = !IsOpenQueueMode;

			TankStartingRateUpDown.Enabled = (IsOpenQueueMode && !TankInPlacementCheckbox.Checked || (TankStartingRateEnabledCheckBox.Checked && !TankInPlacementCheckbox.Checked));
			DamageStartingRateUpDown.Enabled = (!IsOpenQueueMode && DamageStartingRateEnabledCheckBox.Checked && !DamageInPlacementCheckbox.Checked);
			SupportStartingRateUpDown.Enabled = (!IsOpenQueueMode && SupportStartingRateEnabledCheckBox.Checked && !SupportInPlacementCheckbox.Checked);

			TankInPlacementCheckbox.Enabled = (IsOpenQueueMode || TankStartingRateEnabledCheckBox.Checked);
			DamageInPlacementCheckbox.Enabled = (!IsOpenQueueMode && DamageStartingRateEnabledCheckBox.Checked);
			SupportInPlacementCheckbox.Enabled = (!IsOpenQueueMode && SupportStartingRateEnabledCheckBox.Checked);

			if (!MenuItem_StopUpdate.Checked)
			{
				ResetTimer();
			}
			else
			{
				SaveTimer.Enabled = false;
			}
		}
	}
}
