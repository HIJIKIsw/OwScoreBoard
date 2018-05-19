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

namespace OwWinsCounterController
{
	public partial class MainForm : Form
	{

		private string JsonFilePath = "./data.json";

		public MainForm()
		{
			InitializeComponent();
		}

		private void OnLoad( object sender, EventArgs e )
		{
			// 最大化ボタンを無効化
			this.MaximizeBox = false;

			// Json がない場合はデフォルト設定で作成
			if( !File.Exists( JsonFilePath ) )
			{
				DataJson DefaultData = new DataJson
				{
					Wins = 0,
					Loses = 0,
					Draws = 0,
					StartingRate = 1,
				};
				string Json = JsonConvert.SerializeObject( DefaultData, Formatting.Indented );

				FileStream fs = new FileStream( JsonFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite);
				StreamWriter sw = new StreamWriter( fs );
				sw.Write( Json );
				sw.Close();
				fs.Close();
			}
			// Json がある場合は読み込んで値をセット
			else
			{
				StreamReader sr = new StreamReader( JsonFilePath, Encoding.ASCII );
				string RawData = sr.ReadToEnd();
				sr.Close();

				DataJson Data = JsonConvert.DeserializeObject<DataJson>( RawData );

				WinsUpDown.Value = Data.Wins;
				LosesUpDown.Value = Data.Loses;
				DrawsUpDown.Value = Data.Draws;
				StartingRateUpDown.Value = Data.StartingRate;
			}
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
			SaveData();
		}

		private void ResetTimer()
		{
			SaveTimer.Enabled = false;
			SaveTimer.Enabled = true;
		}

		private void SaveData()
		{
			SaveTimer.Enabled = false;

			WinButton.Enabled = true;
			LoseButton.Enabled = true;
			DrawButton.Enabled = true;
			ResetButton.Enabled = true;

			DataJson Data = new DataJson
			{
				Wins = (int)WinsUpDown.Value,
				Loses = (int)LosesUpDown.Value,
				Draws = (int)DrawsUpDown.Value,
				StartingRate = (int)StartingRateUpDown.Value
			};

			string Json = JsonConvert.SerializeObject( Data, Formatting.Indented );
			FileStream fs = new FileStream( JsonFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite );
			StreamWriter sw = new StreamWriter( fs );
			sw.Write( Json );
			sw.Close();
			fs.Close();

			Console.WriteLine( Json );
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
				MessageBoxDefaultButton.Button2);

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

		private void StopUpdateCheckbox_CheckedChanged( object sender, EventArgs e )
		{
			if( !MenuItem_StopUpdate.Checked )
			{
				ResetTimer();
			}
		}

		private void MenuItem_Version_Click( object sender, EventArgs e )
		{
			Console.WriteLine( "OpenInfo" );
			Form VersionInfoForm = new VersionInfoForm();
			VersionInfoForm.ShowInTaskbar = false;
			VersionInfoForm.ShowDialog();
			Console.WriteLine( "ClosedInfo" );
		}
	}

	class DataJson
	{
		public int Wins;
		public int Loses;
		public int Draws;
		public int StartingRate;
	}
}
