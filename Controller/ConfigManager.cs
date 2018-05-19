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

		private class Config
		{
			public string Name;
			public string LogoImageFilePath;
			public string MainColor;
			public string SubColor;
			public int SoundVolume;
		}

		public static void Save( string _Name, string _LogoImageFilePath, Color _MainColor, Color _SubColor, int _SoundVolume )
		{
			// カラーコードを整形
			Color c = new Color();
			byte[] MainColorByte = { _MainColor.R, _MainColor.G, _MainColor.B };
			byte[] SubColorByte = { _SubColor.R, _SubColor.G, _SubColor.B };

			string MainColorCode = "#"+BitConverter.ToString( MainColorByte ).Replace( "-", string.Empty );
			string SubColorCode = "#"+BitConverter.ToString( SubColorByte ).Replace( "-", string.Empty ); ;

			Config Config = new Config
			{
				Name = _Name,
				LogoImageFilePath = _LogoImageFilePath,
				MainColor = MainColorCode,
				SubColor = SubColorCode,
				SoundVolume = _SoundVolume
			};

			string ConfigJson = JsonConvert.SerializeObject( Config, Formatting.Indented );
			FileStream fs = new FileStream( ConfigFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite );
			StreamWriter sw = new StreamWriter( fs );
			sw.Write( ConfigJson );
			sw.Close();
			fs.Close();
		}

		public static void Load()
		{

		}
	}
}
