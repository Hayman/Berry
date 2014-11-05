using System;
using Berry.Plugins.Analytics.Providers;
using FakeItEasy;
using Xunit;

namespace Berry.Plugins.Analytics.Test
{
    public class AnalyticsProvidersTests
    {
        [Fact]
        public void CanTrackEvent()
        {
            var provider = A.Fake<IAnalyticsProvider>();
            var analytics = new Analytics();
            analytics.Subscribe(provider);

            analytics.TrackEvent(A.Dummy<string>());

            A.CallTo(() => provider.TrackEvent(A<string>._)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => provider.TrackException(A<Exception>._)).MustNotHaveHappened();
            A.CallTo(() => provider.TrackScreen(A<string>._)).MustNotHaveHappened();
        }

        [Fact]
        public void CanTrackException()
        {
            var provider = A.Fake<IAnalyticsProvider>();
            var analytics = new Analytics();
            analytics.Subscribe(provider);

            analytics.TrackException(A.Dummy<Exception>());

            A.CallTo(() => provider.TrackException(A<Exception>._)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => provider.TrackEvent(A<string>._)).MustNotHaveHappened();
            A.CallTo(() => provider.TrackScreen(A<string>._)).MustNotHaveHappened();
        }

        [Fact]
        public void CanTrackScreen()
        {
            var provider = A.Fake<IAnalyticsProvider>();
            var analytics = new Analytics();
            analytics.Subscribe(provider);

            analytics.TrackScreen(A.Dummy<string>());

            A.CallTo(() => provider.TrackScreen(A<string>._)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => provider.TrackEvent(A<string>._)).MustNotHaveHappened();
            A.CallTo(() => provider.TrackException(A<Exception>._)).MustNotHaveHappened();
        }

        [Fact]
        public void CanRegisterMultipleSubscribers()
        {
            var p1 = A.Fake<IAnalyticsProvider>();
            var p2 = A.Fake<IAnalyticsProvider>();

            var analytics = new Analytics();
            analytics.Subscribe(p1);
            analytics.Subscribe(p2);

            analytics.TrackEvent(A.Dummy<string>());

            A.CallTo(() => p1.TrackEvent(A<string>._)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => p2.TrackEvent(A<string>._)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void CanTrackEventTwiceOnProvider()
        {
            var provider = A.Fake<IAnalyticsProvider>();
            var analytics = new Analytics();
            analytics.Subscribe(provider);

            analytics.TrackEvent(A.Dummy<string>());
            analytics.TrackEvent(A.Dummy<string>());

            A.CallTo(() => provider.TrackEvent(A<string>._)).MustHaveHappened(Repeated.Exactly.Twice);
        }

        [Fact]
        public void CanTrackEventNTimesOnProvider()
        {
            var provider = A.Fake<IAnalyticsProvider>();
            var analytics = new Analytics();
            analytics.Subscribe(provider);

            var count = new Random().Next(1000);

            for (int i = 0; i < count; i++)
            {
                analytics.TrackEvent(A.Dummy<string>());
            }

            Console.WriteLine("Executed '{0}' times", count);
            A.CallTo(() => provider.TrackEvent(A<string>._)).MustHaveHappened(Repeated.Exactly.Times(count));
        }
    }
}
