namespace Gamifyit.Framework.Events
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EventMediator : IEventMediator
    {
        private readonly ActionMediator<ActionHandlerAdaptor> mediator = new ActionMediator<ActionHandlerAdaptor>();

        public async Task Publish<TEvent>(TEvent publishedEvent) => await this.mediator.Mediate(publishedEvent);

        public async Task Register(IEventHandler handler) =>
            await this.mediator.RegisterHandler(new ActionHandlerAdaptor(handler));
        
        private class ActionHandlerAdaptor : IActionHandler
        {
            private readonly IEventHandler eventHadler;

            public ActionHandlerAdaptor(IEventHandler eventHadler)
            {
                this.eventHadler = eventHadler;
            }

            public Type Type => this.eventHadler.EventType;

            public async Task Handle<TAction>(TAction action)
            {
                await this.eventHadler.Handle(action);
            }
        }
    }

}
