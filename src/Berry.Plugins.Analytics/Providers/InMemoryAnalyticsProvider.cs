using System;

namespace Berry.Plugins.Analytics.Providers
{
    internal sealed class InMemoryAnalyticsProvider
        : IAnalyticsProvider
    {
        public void TrackEvent(string name)
        {
            System.Diagnostics.Debug.WriteLine(name);
        }

        public void TrackScreen(string name)
        {
            throw new NotImplementedException();
        }

        public void TrackException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
