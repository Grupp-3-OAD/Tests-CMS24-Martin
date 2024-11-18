using Data.Interfaces;
using Domain.Models;
using Moq;

namespace Tests;

public class EncryptionServiceTest
{
    private readonly Mock<IEncryptionService> _moqEncryptionService; 
    private readonly string textToEncrypt = "PYAH";
    private readonly string EncryptedText = "HAYP";
    public EncryptionServiceTest()
    {
        _moqEncryptionService = new Mock<IEncryptionService>();
        _moqEncryptionService.Setup(service => service.Encrypt(It.IsAny<string>()))
        .Returns(EncryptedText);
    }

    [Fact]
    public void Text_Should_Return_Encrypted()
    {
        // Arrange


        // Act
       string resultFromEncryption= _moqEncryptionService.Object.Encrypt(textToEncrypt);
        // Assert
        Assert.Equal(resultFromEncryption, EncryptedText);

    }
}
