namespace TestToDo.Infrastructure.Auth;

public class JwtSettings
{
    public const string SectionName = "Jwt";
    public string Secret { get; init; } = null!;
    public string Audience { get;init; }= null!;
    public string Issuer { get;init; }= null!;
    public int AccessTokenExpirationTimeInMinutes { get;init; }
    public int RefreshTokenExpirationTimeInDays { get;init; }
}