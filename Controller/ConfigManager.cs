using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OwWinsCounterController
{
	public static class ConfigManager
	{
		private static string ConfigFilePath = "./config.json";

		public class Config
		{
			public string Name;
			public string LogoImageFilePath;
			public Color MainColor;
			public Color SubColor;
			public int SoundVolume;

			public ConfigJson ToConfigJson()
			{
				string _Name = Name;
				string _LogoImageFilePath = LogoImageFilePath;
				string _MainColor = ColorTranslator.ToHtml( MainColor );
				string _SubColor = ColorTranslator.ToHtml( SubColor );
				int _SoundVolume = SoundVolume;

				ConfigJson ret = new ConfigJson
				{
					Name = _Name,
					LogoImageFilePath = _LogoImageFilePath,
					MainColor = _MainColor,
					SubColor = _SubColor,
					SoundVolume = _SoundVolume
				};
				return ret;
			}
		}

		public class ConfigJson
		{
			public string Name;
			public string LogoImageFilePath;
			public string MainColor;
			public string SubColor;
			public int SoundVolume;

			public Config ToConfig()
			{
				string _Name = Name;
				string _LogoImageFilePath = LogoImageFilePath;
				Color _MainColor = ColorTranslator.FromHtml( MainColor );
				Color _SubColor = ColorTranslator.FromHtml( SubColor );
				int _SoundVolume = SoundVolume;

				Config ret = new Config
				{
					Name = _Name,
					LogoImageFilePath = _LogoImageFilePath,
					MainColor = _MainColor,
					SubColor = _SubColor,
					SoundVolume = _SoundVolume
				};
				return ret;
			}
		}

		public static void Save( string _Name, string _LogoImageFilePath, Color _MainColor, Color _SubColor, int _SoundVolume )
		{
			Config Config = new Config
			{
				Name = _Name,
				LogoImageFilePath = _LogoImageFilePath,
				MainColor = _MainColor,
				SubColor = _SubColor,
				SoundVolume = _SoundVolume
			};

			ConfigJson ConfigJson = Config.ToConfigJson();

			string ConfigString = JsonConvert.SerializeObject( ConfigJson, Formatting.Indented );
			FileStream fs = new FileStream( ConfigFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite );
			StreamWriter sw = new StreamWriter( fs );
			sw.Write( ConfigString );
			sw.Close();
			fs.Close();
		}

		public static Config Load()
		{
			Config ret = new Config();

			// config.json がない場合はデフォルト設定で作成
			if( !File.Exists( ConfigFilePath ) )
			{
				ConfigJson DefaultConfig = new ConfigJson
				{
					Name = string.Empty,
					LogoImageFilePath = string.Empty,
					MainColor = "#032340",
					SubColor = "#DB7C00",
					SoundVolume = 100
				};
				string DefaultConfigJson = JsonConvert.SerializeObject( DefaultConfig, Formatting.Indented );

				FileStream fs = new FileStream( DefaultConfigJson, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite );
				StreamWriter sw = new StreamWriter( fs );
				sw.Write( DefaultConfigJson );
				sw.Close();
				fs.Close();

				ret = DefaultConfig.ToConfig();
			}
			// config.json がある場合は読み込む
			else
			{
				StreamReader sr = new StreamReader( ConfigFilePath, Encoding.UTF8 );
				string ConfigRaw = sr.ReadToEnd();
				sr.Close();

				ConfigJson ConfigJson = JsonConvert.DeserializeObject<ConfigJson>( ConfigRaw );

				ret = ConfigJson.ToConfig();
			}

			return ret;
		}
	}
}
