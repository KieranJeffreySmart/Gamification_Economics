namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Gamifyit.Framework.Events;

    public class WebsiteTest
    {
        protected readonly IEventMediator EventMediator;
        protected readonly ListEventHandler ListEventHandler = new ListEventHandler();

        public Dependancy Dependancy { get; }

        public WebsiteTest()
        {
            this.Dependancy = new Dependancy();
            this.EventMediator = this.Dependancy.GetService<IEventMediator>();
        }

        protected async Task SetupWebsite()
        {
            await this.SetupNotificationListner();
        }

        protected async Task SetupApplication()
        {
            await this.SetupNotificationListner();
        }

        protected void AmNotifiedOfEvent<TEvent>(Action<IEnumerable<TEvent>> assertList = null)
        {
            var eventsOfType = this.ListEventHandler.Events.OfType<TEvent>().ToList();
            eventsOfType.Any().Should().Be(true);

            assertList?.Invoke(eventsOfType);
        }

        private async Task SetupNotificationListner()
        {
            await this.EventMediator.Register(this.ListEventHandler);
        }
    }
}