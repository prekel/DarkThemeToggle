using System;
using System.IO;
using DarkThemeToggle.Core;
using Newtonsoft.Json;

namespace DarkThemeToggle.Plugin.QtCreator
{
	public class QtThemeToggleConfigLoader : AbstractPluginConfigLoader<QtThemeToggleConfigLoader.Config>
	{
		public override string ConfigFileName { get; } = "DarkThemeToggle.Plugin.QtCreator.json";

		public class Config
		{
			public string PathToQtCreatorConfigFile { get; set; } =
				"C:\\Users\\vladislav\\AppData\\Roaming\\QtProject\\QtCreator.ini";
			public string LightThemeName { get; set; } = "flat-light";
			public string DarkThemeName { get; set; } = "design";
		}
	}
}