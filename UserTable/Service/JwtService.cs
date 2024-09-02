
using System;

using System.Collections.Generic;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;

using Microsoft.IdentityModel.Tokens;
 
namespace JwtExample.Services

{

    public class JwtService

    {

        private readonly string _key;

        private readonly string _issuer;

        private readonly string _audience;
 
        public JwtService(string key, string issuer, string audience)

        {

            _key = key;

            _issuer = issuer;

            _audience = audience;

        }
 
        public string GenerateToken(string userName)

        {

            var claims = new List<Claim>

            {

                new Claim(ClaimTypes.Name, userName)

            };

            // Creates a Security Key to sign JWT, this key converts into Byte Array and then passes into "SymmetricSecurityKey" object
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));

            // It creates Signing credentials which specifies Algorithm,                 [ USING HmacSha256 algorithm ]
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Creates a "JwtSecurityToken" object in which it specifying the Issue, Audience, Claims, Expiry Time, and Signing Credentials.
            var token = new JwtSecurityToken(

                issuer: _issuer,

                audience: _audience,

                claims: claims,

                expires: DateTime.Now.AddMinutes(30),

                signingCredentials: creds);
 
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }

}
