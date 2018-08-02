namespace Gamifyit.Framework.Patterns
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FunctionMediator<THandler> where THandler : IFunctionHandler
    {
        private readonly List<THandler> registeredHandlers = new List<THandler>();

        public async Task RegisterHandler(THandler handler)
        {
            await Task.Run(() => this.registeredHandlers.Add(handler));
        }

        public async Task<TResult> Mediate<TAction, TResult>(TAction publishedEvent)
        {
            foreach (var registeredHandler in this.registeredHandlers)
            {
                if (registeredHandler.Type.IsAssignableFrom(typeof(TAction)))
                {
                    return await registeredHandler.Handle<TAction, TResult>(publishedEvent);
                }
            }

            return default(TResult);
        }
    }
}