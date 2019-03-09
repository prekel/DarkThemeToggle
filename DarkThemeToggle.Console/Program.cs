using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using static System.Console;

using DarkThemeToggle.Core;

namespace DarkThemeToggle.Console
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WriteLine("Hello World!");

			var plugins1 = new List<(IThemeToggle, IPluginConfigLoader)>();

			var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "DarkThemeToggle.Plugin.*.dll");

			var asms = files.Select(Assembly.LoadFrom);

			//var asms = new List<Assembly>
			//{
			//	Assembly.LoadFrom("DarkThemeToggle.Plugin.QtCreator.dll"),
			//	Assembly.LoadFrom("DarkThemeToggle.Plugin.WinAppColorMode.dll"),
			//	Assembly.LoadFrom("DarkThemeToggle.Plugin.VisualStudio.dll")
			//};

			foreach (var i in asms)
			{
				var pl = i
					.GetTypes()
					.Where(t => t.GetInterfaces()
						.Any(p => p.FullName == typeof(IThemeToggle).FullName))
					.Select(type => i.CreateInstance(type.FullName) as IThemeToggle)
					.First();

				var pll = i
					.GetTypes()
					.Where(t => t.GetInterfaces()
						.Any(p => p.FullName == typeof(IPluginConfigLoader).FullName))
					.Select(type => i.CreateInstance(type.FullName) as IPluginConfigLoader)
					.First();

				plugins1.Add((pl, pll));
			}

			foreach (var (plugin, pluginConfigLoader) in plugins1)
			{
				if (pluginConfigLoader.ConfigFileCreateState == PluginConfigFileCreateState.NotCreated)
				{
					pluginConfigLoader.CreateConfigFile();
				}

				plugin.Init(pluginConfigLoader);

				if (args[0] == "0")
				{
					plugin.ToDark();
				}
				else
				{
					plugin.ToLight();
				}
			}
		}
	}
}
