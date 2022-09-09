using System.Text;
using System;
using System.Reflection.Metadata;
using System.IdentityModel.Tokens.Jwt;

namespace BubbberDinner.Infrastructure.Authentication;

using System.Security.Claims;
using BubbberDinner.Application.Common.interfaces;
using BubbberDinner.Application.Common.interfaces.Authenticaiton;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName)
        };

        var securityToken = new JwtSecurityToken(
            issuer: "BubberDinner",
            expires: _dateTimeProvider.UtcNow.AddDays(1), //DateTime.Now.AddDays(1),
            claims: claims,
            signingCredentials: signCredentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);

        // throw new NotImplementedException();
    }
}