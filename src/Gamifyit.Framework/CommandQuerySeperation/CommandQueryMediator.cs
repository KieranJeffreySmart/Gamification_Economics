namespace Gamifyit.Framework.CommandQuerySeperation
{
    using System;
    using System.Threading.Tasks;

    public class CommandQueryMediator : ICommandMediator, IQueryMediator
    {
        private readonly ActionMediator<ActionHandlerAdaptor> actionMediator = new ActionMediator<ActionHandlerAdaptor>();
        private readonly FunctionMediator<FunctionHandlerAdaptor> functionMediator = new FunctionMediator<FunctionHandlerAdaptor>();

        public async Task Execute<TCommand>(TCommand publishedCommand) => await this.actionMediator.Mediate(publishedCommand);

        public async Task Register(ICommandHandler handler) =>
            await this.actionMediator.RegisterHandler(new ActionHandlerAdaptor(handler));

        public async Task<TResult> Execute<TQuery, TResult>(TQuery publishedQuery) => await this.functionMediator.Mediate<TQuery, TResult>(publishedQuery);

        public async Task Register(IQueryHandler handler) =>
            await this.functionMediator.RegisterHandler(new FunctionHandlerAdaptor(handler));
        
        private class ActionHandlerAdaptor : IActionHandler
        {
            private readonly ICommandHandler handler;

            public ActionHandlerAdaptor(ICommandHandler handler)
            {
                this.handler = handler;
            }

            public Type Type => this.handler.CommandType;

            public async Task Handle<TAction>(TAction action)
            {
                await this.handler.Execute(action);
            }
        }

        private class FunctionHandlerAdaptor : IFunctionHandler
        {
            private readonly IQueryHandler handler;

            public FunctionHandlerAdaptor(IQueryHandler handler)
            {
                this.handler = handler;
            }

            public Type Type => this.handler.QueryType;

            public async Task<TResult> Handle<TFunction, TResult>(TFunction action)
            {
                return await this.handler.Execute<TFunction, TResult>(action);
            }
        }
    }
}