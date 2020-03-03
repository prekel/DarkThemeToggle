using System;
using System.IO;
using DarkThemeToggle.Core;

namespace DarkThemeToggle.Plugin.VisualStudio
{
	public class VisualStudioToggle : IThemeToggle
	{
		public VisualStudioToggleConfigLoader.Config Config { get; private set; }

		public void Init(IPluginConfigLoader loader)
		{
			loader.Load();
			Config = ((VisualStudioToggleConfigLoader)loader).Config1;
		}

		public void ToDark()
		{
			var file = "";
			using (var sr = new StreamReader(Config.PathToSettings))
			{
				file = sr.ReadToEnd();
			}

			file = file.Replace(Config.LightGuid, Config.DarkGuid);

			using (var sw = new StreamWriter(Config.PathToSettings))
			{
				sw.WriteLine(file);
			}
		}

		public void ToLight()
		{
			var file = "";
			using (var sr = new StreamReader(Config.PathToSettings))
			{
				file = sr.ReadToEnd();
			}

			file = file.Replace(Config.DarkGuid, Config.LightGuid);

			using (var sw = new StreamWriter(Config.PathToSettings))
			{
				sw.WriteLine(file);
			}
		}
	}
}
