using SpaceTrader.Framework.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTrader.Framework
{
    public class EventMediator : IEventMediator
    {
        private readonly List<IEventHandler> registeredHandlers = new List<IEventHandler>();

        public async Task Publish<TEvent>(TEvent publishedEvent) where TEvent : Event
        {
            await Task.Run(() =>
            {
                var handlers = registeredHandlers.OfType<IEventHandler<TEvent>>();

                foreach (var handler in handlers)
                {
                    handler.Handle(publishedEvent);
                }
            });
        }

        public async Task Register<TEvent>(IEventHandler<TEvent> handler) where TEvent : Event
        {
            await Task.Run(() =>
            {
                registeredHandlers.Add(handler);
            });
        }
    }
}
