using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		// ロゴ画像への相対パス (拡張子なし)
		private static string LogoFileNameWithoutExtension = "./user/Logo";

		/// <summary>
		/// Config クラス
		/// </summary>
		public class Config
		{
			public string Name;
			public string LogoImageFilePath;
			public Color MainColor;
			public string MainColorHtml;
			public Color SubColor;
			public string SubColorHtml;
			public int SoundVolume;
			public string TimeStamp;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			public Config( string Name, string LogoImageFilePath, Color MainColor, Color SubColor, int SoundVolume )
			{
				this.Name = Name;
				this.LogoImageFilePath = LogoImageFilePath;
				this.MainColor = MainColor;
				this.MainColorHtml = ColorTranslator.ToHtml( MainColor );
				this.SubColor = SubColor;
				this.SubColorHtml = ColorTranslator.ToHtml( SubColor );
				this.SoundVolume = SoundVolume;
			}
		}

		/// <summary>
		/// Config を Json ファイルに保存
		/// </summary>
		public static void Save( Config Config )
		{
			// ロゴ画像を選択した場合はアプリケーションフォルダ内に複製
			string Extension = Path.GetExtension( Config.LogoImageFilePath );
			if( Config.LogoImageFilePath != LogoFileNameWithoutExtension + Extension && Config.LogoImageFilePath != null )
			{
				if( !Directory.Exists( Path.GetDirectoryName( LogoFileNameWithoutExtension ) ) )
				{
					Directory.CreateDirectory( Path.GetDirectoryName( LogoFileNameWithoutExtension ) );
				}
				File.Copy( Config.LogoImageFilePath, LogoFileNameWithoutExtension + Extension, true );
				Config.LogoImageFilePath = LogoFileNameWithoutExtension + Extension;
			}

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
				Config DefaultConfig = new Config
				(
					string.Empty,
					string.Empty,
					ColorTranslator.FromHtml( "#032340" ),
					ColorTranslator.FromHtml( "#DB7C00" ),
					100
				);
				string DefaultConfigJson = JsonConvert.SerializeObject( DefaultConfig, Formatting.Indented );

				FileStream fs = new FileStream( DefaultConfigJson, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite );
				StreamWriter sw = new StreamWriter( fs );
				sw.Write( DefaultConfigJson );
				sw.Close();
				fs.Close();

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
