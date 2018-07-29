namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Gamifyit.Framework.Events;

    using Xbehave;

    public class WebsiteTest
    {
        protected readonly IEventMediator EventMediator;
        protected readonly ListEventHandler listEventHandler = new ListEventHandler();

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

        protected void IAmNotifiedOfEvent<TEvent>()
        {
            this.listEventHandler.Events.OfType<TEvent>().Count().Should().Be(1);
        }

        private async Task SetupNotificationListner()
        {
            await this.EventMediator.Register(this.listEventHandler);
        }
    }
}