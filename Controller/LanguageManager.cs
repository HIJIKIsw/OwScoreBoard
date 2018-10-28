using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwScoreBoardController
{
	/// <summary>
	/// LanguageManager クラス
	/// </summary>
	public static class LanguageManager
	{
		/// <summary>
		/// Language クラス
		/// </summary>
		public class Language
		{
			/// <summary>
			/// メインフォーム
			/// </summary>
			public MainForm mainForm;
			public struct MainForm
			{
				//------------------------------------------------------------------
				// メニューバー
				//------------------------------------------------------------------

				// ファイル
				public string FileMenu;
				public string MenuItem_Exit;                                        // 終了

				// オプション
				public string OptionMenu;
				public string MenuItem_AlwayOnTop;                                  // 常に最前面に表示
				public string MenuItem_StopUpdate;                                  // 反映を一時停止
				public string MenuItem_Language;                                    // 言語
				public string MenuItem_Language_Automatic;                          // 言語 -> 自動
				public string MenuItem_Settings;                                    // 設定

				// ヘルプ
				public string HelpMenu;
				public string MenuItem_Manual;                                      // ヘルプ
				public string MenuItem_Version;                                     // バージョン情報
			}

			/// <summary>
			/// 設定フォーム
			/// </summary>
			public SettingsForm settingsForm;
			public struct SettingsForm
			{
				public string WindowTitle;                                          // ウィンドウタイトル

				//------------------------------------------------------------------
				// 基本設定タブ
				//------------------------------------------------------------------
				public string TabPage_General;                                      // 基本設定

				// 勝敗演出グループボックス
				public string ProductionGroup;                                      // 勝敗演出 (グループボックスの見出し)
				public string EnableProductionCheckbox;                             // 勝敗演出を有効にする
				public string NameLabel;                                            // 名前
				public string LogoLabel;                                            // ロゴ
				public string MainColorLabel;                                       // メインカラー
				public string SubColorLabel;                                        // サブカラー
				public string FontColorLabel;                                       // フォントカラー
				public string VolumeLabel;                                          // 音量

				// スコアボードグループボックス
				public string ScoreBoardGroup;                                      // スコアボード (グループボックスの見出し)
				public string ScoreBoardSizeLabel;                                  // 大きさ
				public string ScoreBoardPositionLabel;                              // 表示位置
				public string ScoreBoardPositionRadio_Top;                          // 表示位置 -> 上
				public string ScoreBoardPositionRadio_Bottom;                       // 表示位置 -> 下

				// ボタン
				public string OKButton;                                             // OK
				public string CancelButton;                                         // キャンセル

				//------------------------------------------------------------------
				// ホットキー設定タブ
				//------------------------------------------------------------------
				public string TabPage_Hotkey;                                       // ホットキー設定

				public string HotkeyClearButton;                                    // クリア
			}

			/// <summary>
			/// バージョン情報フォーム
			/// </summary>
			public VersionInfo versionInfo;
			public struct VersionInfo
			{
				public string WindowTitle;                                          // ウィンドウタイトル
			}

			// F12 キーを単一でホットキーに設定した場合に表示される警告
			public string InvalidHotkeyWarningTitle;
			public string InvalidHotkeyWarningMessage;
		}

		/// <summary>
		/// 指定されたコードを元に、言語オブジェクトを取得
		/// </summary>
		/// <param name="Code">取得する言語のコード (例: "ja-JP")</param>
		public static Language Get( string Code )
		{
			Language Language;

			// 日本語以外はすべて英語にする
			if(Code == "ja-JP" )
			{
				Language = GetJapanese();
			}
			else
			{
				Language = GetEnglish();
			}

			return Language;
		}

		/// <summary>
		/// 日本語の言語オブジェクトを取得
		/// </summary>
		private static Language GetJapanese()
		{
			Language Japanese = new Language();

			// メインフォーム
			Japanese.mainForm.FileMenu = "ファイル(&F)";
			Japanese.mainForm.MenuItem_Exit = "終了(&X)";
			Japanese.mainForm.OptionMenu = "オプション(&O)";
			Japanese.mainForm.MenuItem_AlwayOnTop = "常に最前面に表示";
			Japanese.mainForm.MenuItem_StopUpdate = "反映を一時停止";
			Japanese.mainForm.MenuItem_Language = "Language(&L)";
			Japanese.mainForm.MenuItem_Language_Automatic = "自動";
			Japanese.mainForm.MenuItem_Settings = "設定(&C)...";
			Japanese.mainForm.HelpMenu = "ヘルプ(&H)";
			Japanese.mainForm.MenuItem_Manual = "ヘルプ";
			Japanese.mainForm.MenuItem_Version = "バージョン情報...";

			// 設定フォーム
			Japanese.settingsForm.WindowTitle = "OwScoreBoard 設定";
			Japanese.settingsForm.TabPage_General = "基本";
			Japanese.settingsForm.ProductionGroup = "勝敗演出";
			Japanese.settingsForm.EnableProductionCheckbox = "勝敗演出を有効にする";
			Japanese.settingsForm.NameLabel = "名前:";
			Japanese.settingsForm.LogoLabel = "ロゴ:";
			Japanese.settingsForm.MainColorLabel = "メインカラー:";
			Japanese.settingsForm.SubColorLabel = "サブカラー:";
			Japanese.settingsForm.FontColorLabel = "フォントカラー:";
			Japanese.settingsForm.VolumeLabel = "音量";
			Japanese.settingsForm.ScoreBoardGroup = "スコアボード";
			Japanese.settingsForm.ScoreBoardSizeLabel = "大きさ";
			Japanese.settingsForm.ScoreBoardPositionLabel = "表示位置";
			Japanese.settingsForm.ScoreBoardPositionRadio_Top = "上";
			Japanese.settingsForm.ScoreBoardPositionRadio_Bottom = "下";
			Japanese.settingsForm.OKButton = "OK";
			Japanese.settingsForm.CancelButton = "キャンセル";
			Japanese.settingsForm.TabPage_Hotkey = "ホットキー";
			Japanese.settingsForm.HotkeyClearButton = "クリア";

			// バージョン情報フォーム
			Japanese.versionInfo.WindowTitle = "OwScoreBoard バージョン情報";

			// F12 キーを単一でホットキーに設定した場合に表示される警告
			Japanese.InvalidHotkeyWarningMessage = "F12 キーは単体で設定しても動作しないことがあります。\r\nCtrl, Shift, Alt のいずれかと併せてご使用ください。\r\n\r\n警告を無視してこのまま続行しますか？";
			Japanese.InvalidHotkeyWarningTitle = "警告";

			return Japanese;
		}

		/// <summary>
		/// 英語の言語オブジェクトを取得
		/// </summary>
		private static Language GetEnglish()
		{
			Language English = new Language();

			// メインフォーム
			English.mainForm.FileMenu = "File(&F)";
			English.mainForm.MenuItem_Exit = "Quit(&X)";
			English.mainForm.OptionMenu = "Options(&O)";
			English.mainForm.MenuItem_AlwayOnTop = "Always On Top";
			English.mainForm.MenuItem_StopUpdate = "Suspend Updates";
			English.mainForm.MenuItem_Language = "Language(&L)";
			English.mainForm.MenuItem_Language_Automatic = "Automatic";
			English.mainForm.MenuItem_Settings = "Settings(&C)...";
			English.mainForm.HelpMenu = "Help(&H)";
			English.mainForm.MenuItem_Manual = "Help";
			English.mainForm.MenuItem_Version = "Version Info...";

			// 設定フォーム
			English.settingsForm.WindowTitle = "OwScoreBoard Settings";
			English.settingsForm.TabPage_General = "General";
			English.settingsForm.ProductionGroup = "Win-Loss Animation";
			English.settingsForm.EnableProductionCheckbox = "Enable Win-Loss Animation";
			English.settingsForm.NameLabel = "Name:";
			English.settingsForm.LogoLabel = "Image:";
			English.settingsForm.MainColorLabel = "Primary Color:";
			English.settingsForm.SubColorLabel = "Secondary Color:";
			English.settingsForm.FontColorLabel = "Font Color:";
			English.settingsForm.VolumeLabel = "Volume";
			English.settingsForm.ScoreBoardGroup = "Scoreboard";
			English.settingsForm.ScoreBoardSizeLabel = "Size";
			English.settingsForm.ScoreBoardPositionLabel = "Location";
			English.settingsForm.ScoreBoardPositionRadio_Top = "Top";
			English.settingsForm.ScoreBoardPositionRadio_Bottom = "Bottom";
			English.settingsForm.OKButton = "OK";
			English.settingsForm.CancelButton = "Cancel";
			English.settingsForm.TabPage_Hotkey = "HotKey";
			English.settingsForm.HotkeyClearButton = "Clear";

			// バージョン情報フォーム
			English.versionInfo.WindowTitle = "OwScoreBoard Version Info";

			// F12 キーを単一でホットキーに設定した場合に表示される警告
			English.InvalidHotkeyWarningMessage = "The F12 key may not operate even if it is set as a single hotkey.\r\nPlease use it together with Ctrl, Shift, Alt.\r\n\r\nIgnore the warning and continue this way?";
			English.InvalidHotkeyWarningTitle = "Caution";


			return English;
		}
	}
}
