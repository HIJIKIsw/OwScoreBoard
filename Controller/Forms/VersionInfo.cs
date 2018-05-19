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
		}

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			System.Diagnostics.Process.Start( "https://github.com/HIJIKIsw/OwScoreBoard" );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close();
		}
	}
}
