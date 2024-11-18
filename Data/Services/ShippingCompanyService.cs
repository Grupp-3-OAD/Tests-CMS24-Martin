using Data.Interfaces;
using Domain.Models;

namespace Data.Services
{
    public class ShippingCompanyService<T> : IShippingCompanyService<T>
    {

        public void Create(T Company)
        {
            throw new NotImplementedException();
        }

        public ShippingCompany Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, T Company)
        {
            throw new NotImplementedException();
        }
        
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}