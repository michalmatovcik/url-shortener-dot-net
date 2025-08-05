using System.Text;

namespace UrlShortener.Application;

public class Base62Encoder : IBase62Encoder
{
    public string Encode(int number)
    {
        const string characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var result = new StringBuilder();

        while (number > 0)
        {
            int remainder = number % characters.Length;
            result.Insert(0, characters[remainder]);
            number /= characters.Length;
        }

        return result.ToString();
    }

    public string Encode(Guid guid)
    {
        byte[] bytes = guid.ToByteArray();
        int number = BitConverter.ToInt32(bytes, 0);
        if (number < 0) number = -number; // Ensure positive
        
        return Encode(number);
    }
    
}