using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.Exceptions;
using Cirrious.CrossCore.Plugins;

namespace Berry.Plugins.Analytics.Providers.XamarinInsights.Droid
{
    public class Plugin
        : IMvxConfigurablePlugin
    {
        private XamarinInsightsConfiguration _configuration;

        public void Load()
        {
            var globals = Mvx.Resolve<IMvxAndroidGlobals>();
            var xi = new XamarinInsightsProviderDroid(_configuration.ApiKey, globals.ApplicationContext);

            Mvx.RegisterSingleton<IXamarinInsightsProvider>(xi);
            Mvx.Resolve<IAnalytics>().Subscribe(xi);
        }

        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (configuration != null && !(configuration is XamarinInsightsConfiguration))
            {
                throw new MvxException("You must use a XamarinInsightsConfiguration object for configuring the XamarinInsights plugin, but you supplied {0}", configuration.GetType().Name);
            }
            _configuration = (XamarinInsightsConfiguration)configuration;
        }
    }
}