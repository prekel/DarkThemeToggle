using System;

using Microsoft.Win32;

using DarkThemeToggle.Core;

namespace DarkThemeToggle.Plugin.WinAppColorMode
{
	public class WinAppColorModePlugin : IThemeToggle
	{
		public void Init(IPluginConfigLoader loader)
		{
			loader.Load();
		}

		private void Change(int value)
		{
			var r2 = Registry.CurrentUser
				.OpenSubKey("Software", true)
				.OpenSubKey("Microsoft", true)
				.OpenSubKey("Windows", true)
				.OpenSubKey("CurrentVersion", true)
				.OpenSubKey("Themes", true)
				.OpenSubKey("Personalize", true);

			r2.SetValue("AppsUseLightTheme", value);
		}

		public void ToDark()
		{
			Change(0);
		}

		public void ToLight()
		{
			Change(1);
		}
	}
}
