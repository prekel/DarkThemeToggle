using System;
using DarkThemeToggle.Core;

namespace DarkThemeToggle.Plugin.FirefoxNewTabBackground
{
	public class FirefoxNewTabBackgroundToggleConfigLoader : AbstractPluginConfigLoader<FirefoxNewTabBackgroundToggleConfigLoader.Config>
	{
		public class Config
		{
			public string PathTo_userChrome_css { get; } =
				"C:\\Users\\vladislav\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\tiepgc3k.default-nightly\\chrome\\userChrome.css";
			public string PathTo_userContent_css { get; } =
				"C:\\Users\\vladislav\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\tiepgc3k.default-nightly\\chrome\\userContent.css";

			public string DarkColorHex { get; } = "#202120";
			public string LightColorHex { get; } = "#ffffff";

			public string userChrome_css { get; } = @"@-moz-document url(""about:newtab"") {
body { background-color: {{COLOR}} !important;}
}

browser { background-color: {{COLOR}} !important; }";

			public string userContent_css { get; } = @"@-moz-document url(""about:newtab"") {
    body { background-color: {{COLOR}} !important;}
}
    
@-moz-document url(chrome://browser/content/browser.xul) {
    browser[type=""content-primary""] {background: {{COLOR}} !important}
}";

			public string ReplaceString { get; } = "{{COLOR}}";

		}

		public override string ConfigFileName { get; } = "DarkThemeToggle.Plugin.FirefoxNewTabBackground.json";
	}
}
