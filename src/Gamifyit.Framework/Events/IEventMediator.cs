namespace Gamifyit.Framework.Events
{
    using System.Threading.Tasks;

    public interface IEventMediator
    {
        Task Register(IEventHandler handler);

        Task Publish<TEvent>(TEvent publishedEvent);
    }
}
