namespace DarkThemeToggle.Core
{
	public interface IPluginConfigLoader
	{
		PluginConfigFileCreateState ConfigFileCreateState { get; }
		void CreateConfigFile();

		string ConfigFileName { get; }

		PluginConfigLoadState LoadState { get; }
		void Load();
	}

	public enum PluginConfigLoadState
	{
		NotStarted, Loaded, Failed
	}

	public enum PluginConfigFileCreateState
	{
		NotCreated, AlreadyCreated, Created, Failed
	}
}