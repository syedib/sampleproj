namespace WebApi.Dtos;

public class CreateUserDto
{
    public string Fullname { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public DateTimeOffset DateOfBirth { get; set; }
}
