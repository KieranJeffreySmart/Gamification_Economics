namespace Gamifyit.Framework.Patterns
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ActionMediator<THandler> where THandler : IActionHandler
    {
        private readonly List<THandler> registeredHandlers = new List<THandler>();

        public async Task RegisterHandler(THandler handler)
        {
            await Task.Run(() => this.registeredHandlers.Add(handler));
        }

        public async Task Mediate<TAction>(TAction publishedEvent)
        {
            foreach (var registeredHandler in this.registeredHandlers)
            {
                if (registeredHandler.Type.IsAssignableFrom(typeof(TAction)))
                {
                    await registeredHandler.Handle(publishedEvent);
                }
            }
        }
    }
}