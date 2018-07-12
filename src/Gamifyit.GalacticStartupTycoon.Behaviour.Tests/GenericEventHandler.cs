namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.Events;

    public class GenericEventHandler : IEventHandler<Event>
    {
        public List<Event> Events = new List<Event>();

        public async Task Handle(Event publishedEvent)
        {
            await Task.Run(() => this.Events.Add(publishedEvent));
        }

        public Guid Id { get; } = Guid.NewGuid();

        public string Name => this.GetType().Name;

        public Type EventType => typeof(Event);
    }
}