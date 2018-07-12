namespace Gamifyit.Economics.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Economics.Model;

    public interface IBusinessRepository
    {
        Task Add(Business business);

        Task<IList<Business>> Search(BusinessSearchCriteria searchCriteria);
    }
}
