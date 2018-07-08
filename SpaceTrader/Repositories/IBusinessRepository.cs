using SpaceTrader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceTrader.Repositories
{
    public interface IBusinessRepository
    {
        Task Add(Business business);

        Task<IList<Business>> Search(BusinessSearchCriteria searchCriteria);
    }
}
