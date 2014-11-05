using System;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;
using Xamarin;

namespace Berry.Plugins.Analytics.Providers.XamarinInsights.Droid
{
    public class XamarinInsightsProviderDroid : IXamarinInsightsProvider
    {
        public XamarinInsightsProviderDroid(string apiKey, Context context)
        {
            Insights.Initialize(apiKey, context);
        }

        public void TrackEvent(string name)
        {
        }

        public void TrackScreen(string name)
        {
        }

        public void TrackException(Exception ex)
        {
        }
    }
}
