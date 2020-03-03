using System;
using System.IO;
using DarkThemeToggle.Core;

namespace DarkThemeToggle.Plugin.FirefoxNewTabBackground
{
	public class FirefoxNewTabBackgroundToggle : IThemeToggle
	{
		private FirefoxNewTabBackgroundToggleConfigLoader.Config Config { get; set; }

		public void Init(IPluginConfigLoader loader)
		{
			loader.Load();
			Config = ((FirefoxNewTabBackgroundToggleConfigLoader)loader).Config1;
		}
		
		private void To(string color)
		{
			using (var sw = new StreamWriter(Config.PathTo_userChrome_css))
			{
				sw.WriteLine(Config.userChrome_css.Replace(Config.ReplaceString, color));
			}
			using (var sw = new StreamWriter(Config.PathTo_userContent_css))
			{
				sw.WriteLine(Config.userContent_css.Replace(Config.ReplaceString, color));
			}
		}

		public void ToDark()
		{
			To(Config.DarkColorHex);
		}

		public void ToLight()
		{
			To(Config.LightColorHex);
		}
	}
}
