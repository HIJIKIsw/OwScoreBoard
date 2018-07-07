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

namespace OwScoreBoardController
{
	public partial class SettingsForm : Form
	{
		// ロゴ画像への相対パス (拡張子なし)
		private static string LogoFileNameWithoutExtension = "./user/Logo";

		public SettingsForm()
		{
			InitializeComponent();
		}

		private void SettingsForm_Load( object sender, EventArgs e )
		{
			// 最大化を無効に
			this.MaximizeBox = false;

			// コンフィグを読み込んで値をセット
			ConfigManager.Config Config = ConfigManager.Load();
			NameTextBox.Text = Config.Name;
			LogoPictureBox.ImageLocation = Config.LogoImageFilePath;
			MainColorBox.BackColor = ColorTranslator.FromHtml( Config.MainColorHtml );
			SubColorBox.BackColor = ColorTranslator.FromHtml( Config.SubColorHtml );
			FontColorBox.BackColor = ColorTranslator.FromHtml( Config.FontColorHtml );
			VolumeTrackbar.Value = Config.SoundVolume;
			ScoreBoardSizeTrackbar.Value = Config.ScoreBoardSize;
			if( Config.ScoreBoardPosition == "top" )
			{
				ScoreBoardPositionRadio_Top.Checked = true;
			}
			else
			{
				ScoreBoardPositionRadio_Bottom.Checked = true;

			}
			EnableProductionCheckbox.Checked = Config.EnableProduction;
			SetEnabledRegardingProductionControls( EnableProductionCheckbox.Checked );

			KeysConverter kc = new KeysConverter();
			if( Config.WinHotkey.KeyCode != Keys.None ) WinHotkeyCombobox.Text = kc.ConvertToString( Config.WinHotkey.KeyCode );
			if( Config.WinHotkey.ModKey.HasFlag( MOD_KEY.CONTROL ) ) WinHotkeyModCheckbox_Ctrl.Checked = true;
			if( Config.WinHotkey.ModKey.HasFlag( MOD_KEY.ALT ) ) WinHotkeyModCheckbox_Alt.Checked = true;
			if( Config.WinHotkey.ModKey.HasFlag( MOD_KEY.SHIFT ) ) WinHotkeyModCheckbox_Shift.Checked = true;
			if( Config.LoseHotkey.KeyCode != Keys.None ) LoseHotkeyCombobox.Text = kc.ConvertToString( Config.LoseHotkey.KeyCode );
			if( Config.LoseHotkey.ModKey.HasFlag( MOD_KEY.CONTROL ) ) LoseHotkeyModCheckbox_Ctrl.Checked = true;
			if( Config.LoseHotkey.ModKey.HasFlag( MOD_KEY.ALT ) ) LoseHotkeyModCheckbox_Alt.Checked = true;
			if( Config.LoseHotkey.ModKey.HasFlag( MOD_KEY.SHIFT ) ) LoseHotkeyModCheckbox_Shift.Checked = true;
			if( Config.DrawHotkey.KeyCode != Keys.None ) DrawHotkeyCombobox.Text = kc.ConvertToString( Config.DrawHotkey.KeyCode );
			if( Config.DrawHotkey.ModKey.HasFlag( MOD_KEY.CONTROL ) ) DrawHotkeyModCheckbox_Ctrl.Checked = true;
			if( Config.DrawHotkey.ModKey.HasFlag( MOD_KEY.ALT ) ) DrawHotkeyModCheckbox_Alt.Checked = true;
			if( Config.DrawHotkey.ModKey.HasFlag( MOD_KEY.SHIFT ) ) DrawHotkeyModCheckbox_Shift.Checked = true;
		}

		private void LogoPictureBox_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "画像ファイル|*.bmp;*.png;*.jpg;*.jpeg;*.gif";

			if( ofd.ShowDialog() == DialogResult.OK )
			{
				LogoPictureBox.ImageLocation = ofd.FileName;
			}
		}

		private void ColorSelect( object sender, EventArgs e )
		{
			ColorDialog cd = new ColorDialog();
			PictureBox Sender = (PictureBox)sender;

			//ダイアログを表示する
			if( cd.ShowDialog() == DialogResult.OK )
			{
				//選択された色の取得
				Sender.BackColor = cd.Color;
			}
		}

		private void VolumeTrackbar_Scroll( object sender, EventArgs e )
		{
			Tooltip.SetToolTip( VolumeTrackbar, VolumeTrackbar.Value.ToString() );
		}

		private void ScoreBoardSizeTrackbar_Scroll( object sender, EventArgs e )
		{
			Tooltip.SetToolTip( ScoreBoardSizeTrackbar, ScoreBoardSizeTrackbar.Value.ToString() + "%" );
		}

		/// <summary>
		/// OK ボタンをクリックした
		/// </summary>
		private void OKButton_Click( object sender, EventArgs e )
		{
			// ショートカットキーの正常確認
			if( !ValidateHotkeys() )
			{
				DialogResult result = MessageBox.Show
				(
					"F12 キーは単体で設定しても動作しないことがあります。\r\nCtrl, Shift, Alt のいずれかと併せてご使用ください。\n\n警告を無視してこのまま続行しますか？",
					"警告",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning,
					MessageBoxDefaultButton.Button2
				);

				if( result == DialogResult.No )
				{
					return;
				}
			}

			// スコアボードの表示位置を文字列化
			string ScoreBoardPosition = ScoreBoardPositionRadio_Top.Checked ? "top" : "bottom";

			// ロゴ画像を選択した場合はアプリケーションフォルダ内に複製
			string Extension = Path.GetExtension( LogoPictureBox.ImageLocation );
			if( LogoPictureBox.ImageLocation != LogoFileNameWithoutExtension + Extension && LogoPictureBox.ImageLocation != null && LogoPictureBox.ImageLocation != string.Empty )
			{
				if( !Directory.Exists( Path.GetDirectoryName( LogoFileNameWithoutExtension ) ) )
				{
					Directory.CreateDirectory( Path.GetDirectoryName( LogoFileNameWithoutExtension ) );
				}
				File.Copy( LogoPictureBox.ImageLocation, LogoFileNameWithoutExtension + Extension, true );
				LogoPictureBox.ImageLocation = LogoFileNameWithoutExtension + Extension;
			}

			// ホットキーのデータを作成
			KeysConverter kc = new KeysConverter();
			ConfigManager.HotkeyData WinHotkey = new ConfigManager.HotkeyData();
			if( !string.IsNullOrEmpty( WinHotkeyCombobox.Text ) ) WinHotkey.KeyCode = (Keys)kc.ConvertFromString( WinHotkeyCombobox.Text );
			if( WinHotkeyModCheckbox_Ctrl.Checked ) WinHotkey.ModKey |= MOD_KEY.CONTROL;
			if( WinHotkeyModCheckbox_Alt.Checked ) WinHotkey.ModKey |= MOD_KEY.ALT;
			if( WinHotkeyModCheckbox_Shift.Checked ) WinHotkey.ModKey |= MOD_KEY.SHIFT;

			ConfigManager.HotkeyData LoseHotkey = new ConfigManager.HotkeyData();
			if( !string.IsNullOrEmpty( LoseHotkeyCombobox.Text ) ) LoseHotkey.KeyCode = (Keys)kc.ConvertFromString( LoseHotkeyCombobox.Text );
			if( LoseHotkeyModCheckbox_Ctrl.Checked ) LoseHotkey.ModKey |= MOD_KEY.CONTROL;
			if( LoseHotkeyModCheckbox_Alt.Checked ) LoseHotkey.ModKey |= MOD_KEY.ALT;
			if( LoseHotkeyModCheckbox_Shift.Checked ) LoseHotkey.ModKey |= MOD_KEY.SHIFT;

			ConfigManager.HotkeyData DrawHotkey = new ConfigManager.HotkeyData();
			if( !string.IsNullOrEmpty( DrawHotkeyCombobox.Text ) ) DrawHotkey.KeyCode = (Keys)kc.ConvertFromString( DrawHotkeyCombobox.Text );
			if( DrawHotkeyModCheckbox_Ctrl.Checked ) DrawHotkey.ModKey |= MOD_KEY.CONTROL;
			if( DrawHotkeyModCheckbox_Alt.Checked ) DrawHotkey.ModKey |= MOD_KEY.ALT;
			if( DrawHotkeyModCheckbox_Shift.Checked ) DrawHotkey.ModKey |= MOD_KEY.SHIFT;

			// Config を作成
			ConfigManager.Config Config = new ConfigManager.Config
			(
				NameTextBox.Text,
				LogoPictureBox.ImageLocation,
				MainColorBox.BackColor,
				SubColorBox.BackColor,
				FontColorBox.BackColor,
				VolumeTrackbar.Value,
				ScoreBoardSizeTrackbar.Value,
				ScoreBoardPosition,
				WinHotkey,
				LoseHotkey,
				DrawHotkey,
				EnableProductionCheckbox.Checked
			);

			// 保存
			ConfigManager.Save( Config );

			// フォームを閉じる
			this.Close();
		}

		private void CancelButton_Click( object sender, EventArgs e )
		{
			// フォームを閉じる
			this.Close();
		}

		private void WinHotkeyClearButton_Click( object sender, EventArgs e )
		{
			WinHotkeyCombobox.SelectedIndex = -1;
			WinHotkeyModCheckbox_Ctrl.Checked = false;
			WinHotkeyModCheckbox_Alt.Checked = false;
			WinHotkeyModCheckbox_Shift.Checked = false;
		}

		private void LoseHotkeyClearButton_Click( object sender, EventArgs e )
		{
			LoseHotkeyCombobox.SelectedIndex = -1;
			LoseHotkeyModCheckbox_Ctrl.Checked = false;
			LoseHotkeyModCheckbox_Alt.Checked = false;
			LoseHotkeyModCheckbox_Shift.Checked = false;
		}

		private void DrawHotkeyClearButton_Click( object sender, EventArgs e )
		{
			DrawHotkeyCombobox.SelectedIndex = -1;
			DrawHotkeyModCheckbox_Ctrl.Checked = false;
			DrawHotkeyModCheckbox_Alt.Checked = false;
			DrawHotkeyModCheckbox_Shift.Checked = false;
		}

		private void EnableProductionCheckbox_CheckedChanged( object sender, EventArgs e )
		{
			SetEnabledRegardingProductionControls( EnableProductionCheckbox.Checked );
		}

		/// <summary>
		/// ホットキーの設定が有効なものであるかを確認
		/// </summary>
		/// <returns>正しく設定されていれば true, それ以外は false を返す。</returns>
		private bool ValidateHotkeys()
		{
			bool ret = true;
			if( WinHotkeyCombobox.Text == "F12" && !WinHotkeyModCheckbox_Alt.Checked && !WinHotkeyModCheckbox_Ctrl.Checked && !WinHotkeyModCheckbox_Shift.Checked ||
				LoseHotkeyCombobox.Text == "F12" && !LoseHotkeyModCheckbox_Alt.Checked && !LoseHotkeyModCheckbox_Ctrl.Checked && !LoseHotkeyModCheckbox_Shift.Checked ||
				DrawHotkeyCombobox.Text == "F12" && !DrawHotkeyModCheckbox_Alt.Checked && !DrawHotkeyModCheckbox_Ctrl.Checked && !DrawHotkeyModCheckbox_Shift.Checked )
			{
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 勝敗演出設定に関するコントロールの有効無効を切り替え
		/// </summary>
		private void SetEnabledRegardingProductionControls( bool Enabled )
		{
			Control[] Controls = { NameTextBox, LogoPictureBox, MainColorBox, SubColorBox, FontColorBox, VolumeTrackbar };
			foreach( var Control in Controls )
			{
				Control.Enabled = Enabled;
			}
		}
	}
}
