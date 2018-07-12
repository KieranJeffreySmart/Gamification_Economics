namespace Gamifyit.Politics.Model
{
    using System.Collections.Generic;

    public interface IState
    {
        IReadOnlyCollection<Regulation> Regulations { get; }
        IReadOnlyCollection<StateOffice> StateOffces { get; }
        IReadOnlyCollection<StateAgency> StateAgencies { get; } 
    }
}
