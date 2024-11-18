using Data.Interfaces;
using Domain.Models;
using Moq;
namespace Tests;

public class ShippingCompanyServiceTests
{
    private readonly Mock<IShippingCompanyService<ShippingCompany>> _moqRepository;
    private readonly List<ShippingCompany> _moqlist;

    private readonly ShippingCompany fakeCompany = new ShippingCompany
    {
        Name = "Company1",
        Website = "www.website.com",
        PhoneNumber = "12345",
        id = Guid.NewGuid()
    };

    private readonly ShippingCompany fakeCompany1 = new ShippingCompany
    {
        Name = "Company2",
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

        _moqRepository.Setup(service => service.Read(It.IsAny<Guid>()))
            .Returns((Guid id) => _moqlist.Find(item => item.id == id));

        _moqRepository.Setup(service => service.Update(It.IsAny<Guid>(), It.IsAny<ShippingCompany>()))
            .Callback((Guid id, ShippingCompany item) =>
            {
                int theIndex = _moqlist.FindIndex(theCompany => theCompany.id == id);
                if (theIndex != -1)
                {
                    _moqlist[theIndex] = item;
                }
            }
            );

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
    public void Read_Should_Return_Index_by_ID_To_Caller()
    {
        // Arrange

        // Act
        _moqRepository.Object.Create(fakeCompany);
        _moqRepository.Object.Create(fakeCompany1);
        var readResultCompany = _moqRepository.Object.Read(fakeCompany.id);
        // Assert
        Assert.NotEqual(readResultCompany.Name, fakeCompany1.Name);


    }

    [Fact]
    public void Update_should_update_company_In_list_with_new_company()
    {
        // Arrange

        // Act
        _moqRepository.Object.Create(fakeCompany);
        _moqRepository.Object.Update(fakeCompany.id, fakeCompany1);


        // Assert
        Assert.Equal(_moqlist[0].Name, fakeCompany1.Name);
    }

    [Fact]
    public void Delete_Should_Delete_Company_From_List()
    {
        // Arrange

        // Act
        _moqRepository.Object.Create(fakeCompany);
        _moqRepository.Object.Delete(fakeCompany.id);

        // Assert

        Assert.Empty(_moqlist);

    }
}