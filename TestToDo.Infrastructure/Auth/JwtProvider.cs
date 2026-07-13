using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TestToDo.Application.Interfaces;
using TestToDo.Entities;

namespace TestToDo.Infrastructure.Auth;

public class JwtProvider : IJwtProvider
{
    private readonly IOptionsMonitor<JwtSettings> _jwtSettings;
    public JwtProvider(IOptionsMonitor<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }
    
    public string GenerateAccessJwtToken(User user)
    {
        var settings = _jwtSettings.CurrentValue;
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(settings.AccessTokenExpirationTimeInMinutes);

        var token = new JwtSecurityToken(
            issuer: settings.Issuer,
            audience: settings.Audience,
            expires: expires,
            claims: claims,
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshJwtToken(User user)
    {
        var randomNumbers = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumbers);
        return Convert.ToBase64String(randomNumbers);
    }

    public DateTime GetExpiryRefreshTokenDate()
    {
        var settings = _jwtSettings.CurrentValue;
        return DateTime.UtcNow.AddDays(settings.RefreshTokenExpirationTimeInDays);
    }
}