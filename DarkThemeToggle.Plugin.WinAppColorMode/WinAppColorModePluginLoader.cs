using System;

using DarkThemeToggle.Core;

namespace DarkThemeToggle.Plugin.WinAppColorMode
{
	public class WinAppColorModePluginLoader : AbstractPluginConfigLoader<WinAppColorModePluginLoader.Config>
	{
		public class Config
		{

		}

		public override string ConfigFileName { get; } = "DarkThemeToggle.Plugin.WinAppColorMode.json";
	}
}