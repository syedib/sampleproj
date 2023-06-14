namespace WebApi.Models;

public class TokenVm
{
    public TokenVm(string token)
    {
        Token = token;
    }

    public string Token { get; private set; }
}
