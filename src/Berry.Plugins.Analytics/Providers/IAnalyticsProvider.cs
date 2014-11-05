using System;

namespace Berry.Plugins.Analytics.Providers
{
    public interface IAnalyticsProvider
    {
        void TrackEvent(string name);
        void TrackScreen(string name);
        void TrackException(Exception ex);
    }
}