using System;
using System.Collections.Generic;
using Berry.Plugins.Analytics.Providers;

namespace Berry.Plugins.Analytics
{
    public class Analytics : IAnalytics
    {
        private readonly IList<IAnalyticsProvider> _providers = new List<IAnalyticsProvider>();

        public void Subscribe(IAnalyticsProvider provider)
        {
            _providers.Add(provider);
        }

        public void TrackEvent(string name)
        {
            foreach (var provider in _providers)
                provider.TrackEvent(name);
        }

        public void TrackException(Exception exception)
        {
            foreach (var provider in _providers)
                provider.TrackException(exception);
        }

        public void TrackScreen(string name)
        {
            foreach (var provider in _providers)
                provider.TrackScreen(name);
        }

        public IEnumerable<IAnalyticsProvider> Providers { get { return _providers; } }
    }
}
