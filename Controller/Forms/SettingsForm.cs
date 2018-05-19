using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwWinsCounterController
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
		}

		private void SettingsForm_Load( object sender, EventArgs e )
		{
			this.MaximizeBox = false;

			VolumeTrackbar.Minimum = 0;
			VolumeTrackbar.Maximum = 200;
			VolumeTrackbar.Value = 100;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			ConfigManager.Save(
				NameTextBox.Text,
				LogoPictureBox.ImageLocation,
				MainColorBox.BackColor,
				SubColorBox.BackColor,
				VolumeTrackbar.Value
				);
			this.Close();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void VolumeTrackbar_Scroll( object sender, EventArgs e )
		{
			Tooltip.SetToolTip( VolumeTrackbar, VolumeTrackbar.Value.ToString() );
		}

		private void pictureBox2_Click( object sender, EventArgs e )
		{
			ColorDialog cd = new ColorDialog();

			//ダイアログを表示する
			if( cd.ShowDialog() == DialogResult.OK )
			{
				//選択された色の取得
				MainColorBox.BackColor = cd.Color;
			}
		}

		private void SubColorBox_Click( object sender, EventArgs e )
		{
			ColorDialog cd = new ColorDialog();

			//ダイアログを表示する
			if( cd.ShowDialog() == DialogResult.OK )
			{
				//選択された色の取得
				SubColorBox.BackColor = cd.Color;
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
	}
}
