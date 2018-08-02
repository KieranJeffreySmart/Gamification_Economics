namespace Gamifyit.Framework.DomainObjects
{
    public interface ICloneableEntity<out TModelState>
    {
        TModelState CloneState();
    }
}