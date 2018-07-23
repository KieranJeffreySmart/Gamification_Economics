namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System;

    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    using Microsoft.Extensions.DependencyInjection;

    public class Dependancy
    {
        private ServiceProvider provider;

        private static readonly Dependancy instance = new Dependancy();

        public static ServiceProvider Provider => instance.GetProvider();

        private IServiceCollection Collection { get; } = new ServiceCollection();

        private ServiceProvider GetProvider()
        {
            return this.provider ?? this.Setup();
        }

        private ServiceProvider Setup()
        {
            this.Collection.AddSingleton<IEventMediator, EventMediator>();
            this.Collection.AddSingleton<InMemoryMembershipRepository>();
            this.Collection.AddSingleton<IMembershipRepository>(
                    x => new EventPublshingMembershipRepositoryDecorator(
                        x.GetService<InMemoryMembershipRepository>(),
                        x.GetService<IEventMediator>()));

            this.provider = this.Collection.BuildServiceProvider();

            return this.provider;
        }

        public T Resolve<T>()
        {
            return this.provider.GetService<T>();
        }
    }
}