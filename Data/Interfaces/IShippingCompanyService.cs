using Domain.Models;

namespace Data.Interfaces
{
    public interface IShippingCompanyService<T>
    {
        void Create(T Company);
        ShippingCompany Read(Guid id);
        void Update(Guid id,T Company);
        void Delete(Guid id);
        
    }
}