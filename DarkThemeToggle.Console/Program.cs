using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DarkThemeToggle.Core;
using static System.Console;

namespace DarkThemeToggle.Console
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WriteLine("Hello World!");

			//var asm = Assembly.LoadFile(
			//	"C:\\Users\\vladislav\\Projects\\DarkThemeToggle\\ClassLibrary1\\bin\\Debug\\netstandard2.0\\ClassLibrary1.dll");

			//var types = asm
			//	.GetTypes()
			//	.Where(t => t.GetInterfaces()
			//		.Any(i => i.FullName == typeof(IInterface1).FullName));

			//var plugins = types.Select(type => asm.CreateInstance(type.FullName) as IInterface1).ToList();

			//foreach (var i in plugins)
			//{
			//	i.Abc();
			//	WriteLine(i.Hello(3));
			//}


			//var asm = Assembly.LoadFile(
			//	"C:\\Users\\vladislav\\Projects\\DarkThemeToggle\\QtThemeToggle\\bin\\Debug\\netstandard2.0\\QtThemeToggle.dll");

			var asm = Assembly.LoadFrom("DarkThemeToggle.Plugin.QtCreator.dll");

			var types1 = asm
				.GetTypes()
				.Where(t => t.GetInterfaces()
					.Any(i => i.FullName == typeof(IThemeToggle).FullName));

			var plugins = types1.Select(type => asm.CreateInstance(type.FullName) as IThemeToggle).ToList();

			var types2 = asm
				.GetTypes()
				.Where(t => t.GetInterfaces()
					.Any(i => i.FullName == typeof(IPluginConfigLoader).FullName));

			var plugins2 = types2.Select(type => asm.CreateInstance(type.FullName) as IPluginConfigLoader).ToList();

			var loader = plugins2.First();
			if (loader.ConfigFileCreateState == PluginConfigFileCreateState.NotCreated)
			{
				loader.CreateConfigFile();
			}

			var plugin = plugins.First();
			plugin.Init(loader);
			plugin.ToLight();
		}
	}
}
