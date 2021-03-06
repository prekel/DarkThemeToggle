﻿using System;
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

			//var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "DarkThemeToggle.Plugin.*.dll");

			//var assemblies = files.Select(Assembly.LoadFrom);

			var plugins1 = Directory.GetFiles(Directory.GetCurrentDirectory(), "DarkThemeToggle.Plugin.*.dll")
					.Select(Assembly.LoadFrom)
					.Select(i => new
					{
						i,
						pl = i.GetTypes()
							.Where(t => t.GetInterfaces().Any(p => p.FullName == typeof(IThemeToggle).FullName))
							.Select(type => i.CreateInstance(type.FullName) as IThemeToggle)
							.First()
					})
					.Select(j => new
					{
						j,
						pll = j.i.GetTypes()
							.Where(t => t.GetInterfaces()
								.Any(p => p.FullName == typeof(IPluginConfigLoader).FullName))
							.Select(type => j.i.CreateInstance(type.FullName) as IPluginConfigLoader)
							.First()
					})
					.Select(p => (p.j.pl, p.pll))
			.ToList();

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
