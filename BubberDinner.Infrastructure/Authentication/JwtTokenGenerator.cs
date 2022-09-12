using System.Text;
using System;
using System.Reflection.Metadata;
using System.IdentityModel.Tokens.Jwt;

namespace BubbberDinner.Infrastructure.Authentication;

using System.Security.Claims;
using BubbberDinner.Application.Common.interfaces;
using BubbberDinner.Application.Common.interfaces.Authenticaiton;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName)
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes), //DateTime.Now.AddDays(1),
            audience: _jwtSettings.Audience,
            claims: claims,
            signingCredentials: signCredentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);

        // throw new NotImplementedException();
    }
}