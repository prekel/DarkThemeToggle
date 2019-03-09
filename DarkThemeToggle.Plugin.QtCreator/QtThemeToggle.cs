using System;
using System.IO;
using IniFileParser;
using IniFileParser.Model;

using DarkThemeToggle.Core;

namespace DarkThemeToggle.Plugin.QtCreator
{
	public class QtThemeToggle : IThemeToggle
	{
		public QtThemeToggleConfigLoader.Config Config { get; private set; }

		public void Init(IPluginConfigLoader configLoader)
		{
			configLoader.Load();
			Config = ((QtThemeToggleConfigLoader)configLoader).Config1;
		}

		private void ToTheme(string themeName)
		{
			var parser = new IniFileParser.IniFileParser();
			IniData data;
			using (var sr = new StreamReader(Config.PathToQtCreatorConfigFile))
			{
				data = parser.ReadData(sr);
			}
			data["Core"]["CreatorTheme"] = themeName;
			using (var sw = new StreamWriter(Config.PathToQtCreatorConfigFile))
			{
				parser.WriteData(sw, data);
			}
		}

		public void ToDark()
		{
			ToTheme(Config.DarkThemeName);
		}

		public void ToLight()
		{
			ToTheme(Config.LightThemeName);
		}
	}
}
