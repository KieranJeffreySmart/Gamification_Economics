namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.Events;

    public class ListEventHandler : IEventHandler
    {
        public List<Event> Events { get; } = new List<Event>();

        public Guid Id { get; } = Guid.NewGuid();

        public string Name => this.GetType().Name;

        public Type EventType => typeof(Event);

        public async Task Handle<TEvent>(TEvent publishedEvent)
        {
            await this.Handle(publishedEvent as Event);
        }

        public async Task Handle(Event publishedEvent)
        {
            await Task.Run(() => this.Events.Add(publishedEvent));
        }
    }
}