using Berry.Plugins.Analytics;
using Cirrious.MvvmCross.ViewModels;

namespace Samples.Analytics.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private readonly IAnalytics _analytics;

        public FirstViewModel(IAnalytics analytics)
        {
            _analytics = analytics;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            _analytics.TrackScreen(typeof (FirstViewModel).Name);
        }
    }
}
