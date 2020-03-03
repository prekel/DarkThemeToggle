using System;
using System.Collections.Generic;
using System.Text;
using DarkThemeToggle.Core;

namespace DarkThemeToggle.Plugin.VisualStudio
{
	public class VisualStudioToggleConfigLoader : AbstractPluginConfigLoader<VisualStudioToggleConfigLoader.Config>
	{
		public class Config
		{
			public string PathToSettings { get; } =
				"C:\\Users\\vladislav\\AppData\\Local\\Microsoft\\VisualStudio\\15.0_66d2d504\\Settings\\CurrentSettings.vssettings";

			public string LightGuid { get; } = "DE3DBBCD-F642-433C-8353-8F1DF4370ABA";
			public string DarkGuid { get; } = "1DED0138-47CE-435E-84EF-9EC1F439B749";
		}

		public override string ConfigFileName { get; } = "DarkThemeToggle.Plugin.VisualStudio.json";
	}
}
