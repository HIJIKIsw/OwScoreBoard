﻿using System;
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
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void pictureBox2_Click( object sender, EventArgs e )
		{
			Console.WriteLine( "MainColor" );
		}

		private void pictureBox1_Click( object sender, EventArgs e )
		{

		}
	}
}
