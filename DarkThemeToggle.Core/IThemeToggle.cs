namespace DarkThemeToggle.Core
{
	public interface IThemeToggle
	{
		void Init(IPluginConfigLoader loader);
		void ToDark();
		void ToLight();
	}
}