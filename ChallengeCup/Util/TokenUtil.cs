﻿using ChallengeCup.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChallengeCup.Util
{
    public static class TokenUtil<TUser> where TUser :IUser
    {
        public static object GetToken(TUser user,string rols)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Consts.Consts.Secret);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Aud,"api"),
                    new Claim(JwtRegisteredClaimNames.Iss,"lmy"),
                    new Claim(ClaimTypes.Role,rols),
                    new Claim(ClaimTypes.NameIdentifier,user.Name)
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            //return (new
            //{
            //    access_token = tokenString,
            //    token_type = "Bearer",
            //    profile = new
            //    {
            //        sid = user.Id,
            //        name = user.Username,
            //        auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
            //        expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
            //    }
            //});
            

            return new
            {
                token = tokenString
            };
        }

        public static string GetCurrentUser(HttpContext httpContext)
        {
            var claims = httpContext.User.Claims;

            foreach (var claim in claims)
            {
                if (ClaimTypes.NameIdentifier.Equals(claim.Type))
                {
                    return claim.Value;
                }
            }
            return null;
        }
    }
}
