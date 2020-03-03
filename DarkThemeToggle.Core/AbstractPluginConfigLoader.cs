using System.IO;
using Newtonsoft.Json;

namespace DarkThemeToggle.Core
{
	public abstract class AbstractPluginConfigLoader<T> : IPluginConfigLoader
		where T : new()
	{
		public T Config1 { get; private set; }

		private PluginConfigFileCreateState _configFileCreateState;

		public PluginConfigFileCreateState ConfigFileCreateState
		{
			get
			{
				if (_configFileCreateState != PluginConfigFileCreateState.NotCreated) return _configFileCreateState;
				if (File.Exists(ConfigFileName))
				{
					_configFileCreateState = PluginConfigFileCreateState.AlreadyCreated;
				}

				return _configFileCreateState;
			}
		}

		public void CreateConfigFile()
		{
			try
			{
				using (var sw = new StreamWriter(ConfigFileName))
				{
					Config1 = new T();
					sw.Write(JsonConvert.SerializeObject(Config1, Formatting.Indented));
					_configFileCreateState = PluginConfigFileCreateState.Created;
				}
			}
			catch
			{
				_configFileCreateState = PluginConfigFileCreateState.Failed;
			}
		}

		public abstract string ConfigFileName { get; }

		public PluginConfigLoadState LoadState { get; private set; }

		public void Load()
		{
			try
			{
				using (var sr = new StreamReader(ConfigFileName))
				{
					var c = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
					Config1 = c;
					LoadState = PluginConfigLoadState.Loaded;
				}
			}
			catch
			{
				LoadState = PluginConfigLoadState.Failed;
			}
		}
	}
}