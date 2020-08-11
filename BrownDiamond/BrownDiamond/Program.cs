using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Charlotte.Tools;

namespace Charlotte
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			ProcMain.GUIMain(() => new MainWin(), APP_IDENT, APP_TITLE);
		}

		public const string APP_IDENT = "{29e8dd04-9e4f-4df7-9762-22fd13fd33b8}";
		public const string APP_TITLE = "BrownDiamond";
	}
}
