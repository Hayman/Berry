using Cirrious.CrossCore.Plugins;

namespace Berry.Plugins.Analytics.Providers.XamarinInsights.Droid
{
    public class XamarinInsightsConfiguration
        : IMvxPluginConfiguration
    {
        public XamarinInsightsConfiguration(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string ApiKey { get; private set; }
    }
}