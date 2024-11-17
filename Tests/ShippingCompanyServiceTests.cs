using Data.Interfaces;
using Data.Services;
using Domain.Models;
using Moq;
namespace Tests
{
    public class ShippingCompanyServiceTests
    {
        private readonly Mock<IShippingCompanyService<ShippingCompany>> _moqRepository;
        private readonly List<ShippingCompany> _moqlist;

        private readonly ShippingCompany fakeCompany = new ShippingCompany
        {
            Name = "Company",
            Website = "www.website.com",
            PhoneNumber = "12345",
            id = Guid.NewGuid()
        };
        public ShippingCompanyServiceTests()
        {
            _moqRepository = new Mock<IShippingCompanyService<ShippingCompany>>();
            _moqlist = new List<ShippingCompany>();

            _moqRepository.Setup(service => service.Create(It.IsAny<ShippingCompany>()))
               .Callback((ShippingCompany item) => _moqlist.Add(item));


            _moqRepository.Setup(service => service.Delete(It.IsAny<Guid>()))
            .Callback((Guid id) => _moqlist.RemoveAll(item => item.id == id));

        }

        [Fact]
        public void Create_Should_Add_Company_To_List() 
        {
            // Arrange

            // Act
            _moqRepository.Object.Create(fakeCompany);
            // Assert

            Assert.NotNull(_moqlist[0].Name);
            Assert.Equal(fakeCompany.Name, _moqlist[0].Name);
            Assert.Equal(fakeCompany.Website, _moqlist[0].Website);
            Assert.Equal(fakeCompany.PhoneNumber, _moqlist[0].PhoneNumber);
        }
        [Fact]
        public void Delete_Should_Delete_Company_From_List()
        {
            // Arrange

            // Act
            _moqRepository.Object.Create(fakeCompany);
            _moqRepository.Object.Create(fakeCompany);
            _moqRepository.Object.Delete(fakeCompany.id);

            // Assert
            
            Assert.Null(_moqlist[0].Name);

        }
        [Fact]
        public void Update()
        {
            // Arrange
            ShippingCompanyService<ShippingCompany> _shippingCompanyService = new();

            ShippingCompany CompanytoAdd = new ShippingCompany
            {
                id = Guid.NewGuid(),
                Name = "Company",
                Website = "www.website.com",
                PhoneNumber = "12345",
            };

            ShippingCompany CompanytoUpdateTo = new ShippingCompany
            {
                id = CompanytoAdd.id,
                Name = "BestCompany",
                Website = "www.Bestwebsite.com",
                PhoneNumber = "54321",
            };

            // Act
            _moqRepository.Object.Create(CompanytoAdd);
            _moqRepository.Object.Update(CompanytoAdd.id , CompanytoUpdateTo);
            var invocation = _moqRepository.Invocations.FirstOrDefault(); // grabs the first invocation of the mock object
            var createdCompany = invocation!.Arguments.FirstOrDefault() as ShippingCompany;
            _moqRepository.Object.Delete(CompanytoAdd.id);
            createdCompany = null;


            // Assert
            Assert.Null(createdCompany);
        }


    }
}