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
			MainColorBox.BackColor = ColorTranslator.FromHtml( Config.MainColorHtml);
			SubColorBox.BackColor = ColorTranslator.FromHtml( Config.SubColorHtml );
			FontColorBox.BackColor = ColorTranslator.FromHtml( Config.FontColorHtml );
			VolumeTrackbar.Value = Config.SoundVolume;
			ScoreBoardSizeTrackbar.Value = Config.ScoreBoardSize;
			if( Config.ScoreBoardPosition == "Top" )
			{
				ScoreBoardPositionRadio_Top.Checked = true;
			}
			else
			{
				ScoreBoardPositionRadio_Bottom.Checked = true;

			}
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

		private void OKButton_Click( object sender, EventArgs e )
		{
			string ScoreBoardPosition = ScoreBoardPositionRadio_Top.Checked ? "Top" : "Bottom";

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
				new ConfigManager.HotkeyData(),
				new ConfigManager.HotkeyData(),
				new ConfigManager.HotkeyData()
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
	}
}
