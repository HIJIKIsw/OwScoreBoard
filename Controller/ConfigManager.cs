using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace OwScoreBoardController
{
	/// <summary>
	/// Config ファイルを取り扱うクラス
	/// </summary>
	public static class ConfigManager
	{
		// コンフィグファイルへの相対パス
		private static string ConfigFilePath = "./config.json";

		/// <summary>
		/// Config クラス
		/// </summary>
		public class Config
		{
			public string Name;
			public string LogoImageFilePath;
			public string MainColorHtml;
			public string SubColorHtml;
			public string FontColorHtml;
			public int SoundVolume;
			public int ScoreBoardSize;
			public string ScoreBoardPosition;
			public HotkeyData WinHotkey;
			public HotkeyData LoseHotkey;
			public HotkeyData DrawHotkey;
			public string TimeStamp;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			public Config() { }
			public Config( string Name, string LogoImageFilePath, Color MainColor, Color SubColor, Color FontColor, int SoundVolume, int ScoreBoardSize, string ScoreBoardPosition, HotkeyData WinHotkey, HotkeyData LoseHotkey, HotkeyData DrawHotkey )
			{
				this.Name = Name;
				this.LogoImageFilePath = LogoImageFilePath;
				this.MainColorHtml = ColorTranslator.ToHtml( MainColor );
				this.SubColorHtml = ColorTranslator.ToHtml( SubColor );
				this.FontColorHtml = ColorTranslator.ToHtml( FontColor );
				this.SoundVolume = SoundVolume;
				this.ScoreBoardSize = ScoreBoardSize;
				this.ScoreBoardPosition = ScoreBoardPosition;
				this.WinHotkey = WinHotkey;
				this.LoseHotkey = LoseHotkey;
				this.DrawHotkey = DrawHotkey;
			}

			/// <summary>
			/// 初期設定 Config を返す
			/// </summary>
			/// <returns></returns>
			public static Config Default()
			{
				return new Config
				(
					"You",
					null,
					ColorTranslator.FromHtml( "#032340" ),
					ColorTranslator.FromHtml( "#DB7C00" ),
					ColorTranslator.FromHtml( "#ffffff" ),
					100,
					100,
					"Bottom",
					new HotkeyData(),
					new HotkeyData(),
					new HotkeyData()
				);
			}
		}

		/// <summary>
		/// HotkeyData クラス
		/// </summary>
		public class HotkeyData
		{
			public Keys KeyCode;
			public MOD_KEY ModKey;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			public HotkeyData()
			{
				this.KeyCode = Keys.None;
				this.ModKey = MOD_KEY.NONE;
			}
			public HotkeyData( Keys KeyCode, MOD_KEY ModKey )
			{
				this.KeyCode = KeyCode;
				this.ModKey = ModKey;
			}
		}

		/// <summary>
		/// Config を Json ファイルに保存
		/// </summary>
		public static void Save( Config Config )
		{
			// Json ファイルに保存
			Config.TimeStamp = System.DateTime.Now.ToString();
			string ConfigJson = JsonConvert.SerializeObject( Config, Formatting.Indented );
			FileStream fs = new FileStream( ConfigFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite );
			StreamWriter sw = new StreamWriter( fs );
			sw.Write( ConfigJson );
			sw.Close();
			fs.Close();
		}

		/// <summary>
		/// Json ファイルから Config を読み込み
		/// </summary>
		public static Config Load()
		{
			Config ret;

			// config.json がない場合はデフォルト設定で作成
			if( !File.Exists( ConfigFilePath ) )
			{
				Config DefaultConfig = Config.Default();
				string DefaultConfigJson = JsonConvert.SerializeObject( DefaultConfig, Formatting.Indented );

				Save( DefaultConfig );
				ret = DefaultConfig;
			}
			// config.json がある場合は読み込む
			else
			{
				StreamReader sr = new StreamReader( ConfigFilePath, Encoding.UTF8 );
				string ConfigJson = sr.ReadToEnd();
				sr.Close();

				ret = JsonConvert.DeserializeObject<Config>( ConfigJson );
			}

			return ret;
		}
	}
}
