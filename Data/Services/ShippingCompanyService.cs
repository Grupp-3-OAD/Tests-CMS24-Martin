﻿using Data.Interfaces;

namespace Data.Services
{
    public class ShippingCompanyService<T> : IShippingCompanyService<T>
    {

        public void Create(T Company)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }


        public void Update(Guid id, T Company)
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine("Hello World with the help of depedency injection!");
        }
    }
}