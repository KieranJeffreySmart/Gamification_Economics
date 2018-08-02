namespace Gamifyit.Framework.Patterns
{
    using System;
    using System.Threading.Tasks;

    public interface IFunctionHandler
    {
        Type Type { get; }

        Task<TResult> Handle<TFunction, TResult>(TFunction action);
    }
}