namespace Gamifyit.Framework
{
    using System;
    using System.Threading.Tasks;

    public interface IFunctionHandler
    {
        Type Type { get; }

        Task<TResult> Handle<TFunction, TResult>(TFunction action);
    }
}