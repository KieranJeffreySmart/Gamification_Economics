﻿using SpaceTrader.Framework.Events;
using System;
using System.Threading.Tasks;

namespace SpaceTrader.Framework
{
    public interface IEventHandler<TEvent>: IEventHandler where TEvent : Event
    {
        Task Handle(TEvent publishedEvent);
    }

    public interface IEventHandler
    {
        Guid Id { get; }
        string Name { get; }
        Type EventType { get; }
    }
}
