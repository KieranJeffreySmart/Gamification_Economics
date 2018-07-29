namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System;

    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events.Publishers;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    using Microsoft.Extensions.DependencyInjection;

    public class Dependancy
    {
        private ServiceProvider provider;

        private IServiceCollection collection;
        
        public T GetService<T>()
        {
            return this.GetProvider().GetService<T>();
        }

        private IServiceCollection GetCollection()
        {
            return this.collection ?? (this.collection = this.Setup());
        }

        private ServiceProvider GetProvider()
        {
            return this.provider ?? (this.provider = this.GetCollection().BuildServiceProvider());
        }

        private IServiceCollection Setup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IEventMediator, EventMediator>();

            serviceCollection.AddSingleton<InMemoryMembershipRepository>();
            serviceCollection.AddSingleton<IMembershipRepository>(
                    x => new MembershipRepositoryDecorator(
                        x.GetService<InMemoryMembershipRepository>(),
                        x.GetService<IEventMediator>()));

            serviceCollection.AddSingleton<InMemoryGameTypeRepository>();
            serviceCollection.AddSingleton <IGameTypeRepository>(
                x => new GameTypeRepositoryDecorator(
                    x.GetService<InMemoryGameTypeRepository>(),
                    x.GetService<IEventMediator>()));

            serviceCollection.AddSingleton<InMemoryGameRepository>();
            serviceCollection.AddSingleton<IGameRepository>(
                x => new GameRepositoryDecorator(
                    x.GetService<InMemoryGameRepository>(),
                    x.GetService<IEventMediator>()));

            serviceCollection.AddSingleton<InMemoryCharacterRepository>();
            serviceCollection.AddSingleton<ICharacterRepository>(
                x => new CharacterRepositoryDecorator(
                    x.GetService<InMemoryCharacterRepository>(),
                    x.GetService<IEventMediator>()));

            serviceCollection.AddSingleton<ILookupRepository, InMemoryLookupRepository>();

            serviceCollection.BuildServiceProvider();

            return serviceCollection;
        }
    }
}