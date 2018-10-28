using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OwScoreBoardController
{
	/// <summary>
	/// Score ファイルを取り扱うクラス
	/// </summary>
	public static class ScoreManager
	{
		// Score ファイルへの総体パス
		private static string ScoreFilePath = "./score.json";

		/// <summary>
		/// Score クラス
		/// </summary>
		public class Score
		{
			public int Wins;
			public int Loses;
			public int Draws;
			public int StartingRate;
			public bool IsInPlacement;
			public string TimeStamp;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			public Score( int Wins, int Loses, int Draws, int StartingRate, bool IsInPlacement )
			{
				this.Wins = Wins;
				this.Loses = Loses;
				this.Draws = Draws;
				this.IsInPlacement = IsInPlacement;
				this.StartingRate = StartingRate;
			}

			/// <summary>
			/// 初期設定 Score を返す
			/// </summary>
			public static Score Default()
			{
				return new Score( 0, 0, 0, 1, false );
			}
		}

		/// <summary>
		/// Score を Json ファイルに保存
		/// </summary>
		public static void Save( Score Score )
		{
			Score.TimeStamp = System.DateTime.Now.ToString();

			string ScoreJson = JsonConvert.SerializeObject( Score, Formatting.Indented );
			FileStream fs = new FileStream( ScoreFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite );
			StreamWriter sw = new StreamWriter( fs );
			sw.Write( ScoreJson );
			sw.Close();
			fs.Close();
		}

		/// <summary>
		/// Json ファイルから Score を読み込み
		/// </summary>
		public static Score Load()
		{
			Score ret;

			// score.json がない場合はデフォルト設定で作成
			if( !File.Exists( ScoreFilePath ) )
			{
				Score DefaultScore = Score.Default();
				string DefaultScoreJson = JsonConvert.SerializeObject( DefaultScore, Formatting.Indented );

				FileStream fs = new FileStream( ScoreFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite );
				StreamWriter sw = new StreamWriter( fs );
				sw.Write( DefaultScoreJson );
				sw.Close();
				fs.Close();

				ret = DefaultScore;
			}
			// config.json がある場合は読み込む
			else
			{
				StreamReader sr = new StreamReader( ScoreFilePath, Encoding.UTF8 );
				string ScoreJson = sr.ReadToEnd();
				sr.Close();

				ret = JsonConvert.DeserializeObject<Score>( ScoreJson );
			}

			return ret;
		}
	}
}
