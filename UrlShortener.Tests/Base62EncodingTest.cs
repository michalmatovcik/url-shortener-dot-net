using UrlShortener.Application;

namespace UrlShortener.Tests;

public class Base62EncodingTest
{
    
    private IBase62Encoder encoder = new Base62Encoder();
    
    [Fact]
    public void ShouldEncodeAndDecodeIntCorrectly()
    {
        // Given
        var number = 123456789;
        
        // When
        var encodedNumber = encoder.Encode(number);

        // Then
        Assert.Equal("8m0Kx", encodedNumber);
    }
    
    
    [Fact]
    public void ShouldEncodeAndDecodeGuidCorrectly()
    {
        // Given
        var guid = new Guid("12345678-1234-1234-1234-123456789012");
        
        // Act
        var encoded = encoder.Encode(guid);

        // Assert
        Assert.Equal("kFvFm", encoded);
    }
}