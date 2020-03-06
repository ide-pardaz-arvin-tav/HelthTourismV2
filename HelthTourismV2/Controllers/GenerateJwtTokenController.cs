using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using HelthTourismV2.Utilities;
using Microsoft.IdentityModel.Tokens;

namespace HelthTourismV2.Controllers
{
    public class GenerateJwtTokenController : ApiController
    {
        public IHttpActionResult Authenticate()
        {
            try
            {
                string username = Thread.CurrentPrincipal.Identity.Name;
                if (username != null && username != "")
                {
                    string token = createToken(username);
                    return Ok(token);
                }
                return Content(HttpStatusCode.Unauthorized, "Please Login");
            }
            catch (Exception ee)
            {
                return Content(HttpStatusCode.Unauthorized, ee.Message);
            }
        }

        private string createToken(string username)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddDays(7);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,username) 
            });
            string dbHash = SecurityProtocol.FetchJwtProtocolKey();
            DateTime now = DateTime.UtcNow;
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(dbHash));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken token = (JwtSecurityToken)tokenHandler.CreateJwtSecurityToken(
                    issuer: "Yanal",
                    audience: "Yanal",
                    subject: claimsIdentity,
                    notBefore: issuedAt,
                    expires: expires,
                    signingCredentials: signingCredentials
                );
            string tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
