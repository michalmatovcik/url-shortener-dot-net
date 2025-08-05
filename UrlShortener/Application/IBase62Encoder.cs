namespace UrlShortener.Application;

public interface IBase62Encoder
{
    string Encode(int number);

    string Encode(Guid guid);
}