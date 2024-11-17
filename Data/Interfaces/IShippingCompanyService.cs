namespace Data.Interfaces
{
    public interface IShippingCompanyService<T>
    {
        void Create(T Company);
        void Delete(Guid id);
        void Update(Guid id, T Company);
    }
}