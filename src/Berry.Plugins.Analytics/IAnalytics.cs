using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berry.Plugins.Analytics.Providers;

namespace Berry.Plugins.Analytics
{
    public interface IAnalytics
    {
        IEnumerable<IAnalyticsProvider> Providers { get; }
        void Subscribe(IAnalyticsProvider provider);
        void TrackEvent(string name);
        void TrackException(Exception exception);
        void TrackScreen(string name);
    }
}
