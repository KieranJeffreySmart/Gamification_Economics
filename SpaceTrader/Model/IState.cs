using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public interface IState
    {
        IReadOnlyCollection<Regulation> Regulations { get; }
        IReadOnlyCollection<StateOffice> StateOffces { get; }
        IReadOnlyCollection<StateAgency> StateAgencies { get; } 
    }
}
