using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwScoreBoardController
{
	public partial class VersionInfoForm : Form
	{
		public VersionInfoForm()
		{
			InitializeComponent();
		}

		private void VersionInfoForm_Load( object sender, EventArgs e )
		{
			// 最大化ボタンを無効化
			this.MaximizeBox = false;

			// 言語をセット
			SetLanguage();
		}

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			System.Diagnostics.Process.Start( "https://github.com/HIJIKIsw/OwScoreBoard" );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		/// <summary>
		/// 言語をセット
		/// </summary>
		private void SetLanguage()
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

			// 各文言をセット
			this.Text = Language.versionInfo.WindowTitle;
		}

	}
}
