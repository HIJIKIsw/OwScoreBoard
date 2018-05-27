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
			// 最大化ボタンを無効化
			this.MaximizeBox = false;

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
			ScoreManager.Score Score = new ScoreManager.Score( (int)WinsUpDown.Value, (int)LosesUpDown.Value, (int)DrawsUpDown.Value, (int)StartingRateUpDown.Value );
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

		private void LoseButton_Click( object sender, EventArgs e )
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

		private void DrawButton_Click( object sender, EventArgs e )
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
		}

		private void MenuItem_Exit_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void MenuItem_Settings_Click( object sender, EventArgs e )
		{
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
			if( WinHotkey != null ) WinHotkey.Dispose();
			if( LoseHotkey != null ) LoseHotkey.Dispose();
			if( DrawHotkey != null ) DrawHotkey.Dispose();
		}


		/// <summary>
		/// Config を読み込んでホットキーをセット
		/// </summary>
		private void SetHotkeyFromConfig()
		{
			WinHotkey = new HotKey( MOD_KEY.NONE, Keys.None );
			LoseHotkey = new HotKey( MOD_KEY.NONE, Keys.None );
			DrawHotkey = new HotKey( MOD_KEY.NONE, Keys.None );

			ConfigManager.Config Config = ConfigManager.Load();
			if( Config.WinHotkey.KeyCode != Keys.None && Config.WinHotkey != null )
			{
				WinHotkey = new HotKey( Config.WinHotkey.ModKey, Config.WinHotkey.KeyCode );
				WinHotkey.HotKeyPush += new EventHandler( WinButton_Click );
			}
			if( Config.LoseHotkey.KeyCode != Keys.None && Config.LoseHotkey != null )
			{
				LoseHotkey = new HotKey( Config.LoseHotkey.ModKey, Config.LoseHotkey.KeyCode );
				LoseHotkey.HotKeyPush += new EventHandler( LoseButton_Click );
			}
			if( Config.DrawHotkey.KeyCode != Keys.None && Config.DrawHotkey != null )
			{
				DrawHotkey = new HotKey( Config.DrawHotkey.ModKey, Config.DrawHotkey.KeyCode );
				DrawHotkey.HotKeyPush += new EventHandler( DrawButton_Click );
			}
		}
	}
}
