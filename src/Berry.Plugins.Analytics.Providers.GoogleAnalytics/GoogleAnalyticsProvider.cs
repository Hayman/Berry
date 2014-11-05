using System;

namespace Berry.Plugins.Analytics.Providers.GoogleAnalytics
{
    public class GoogleAnalyticsProvider
        : IAnalyticsProvider
    {


        public GoogleAnalyticsProvider(string trackerId)
        {
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
