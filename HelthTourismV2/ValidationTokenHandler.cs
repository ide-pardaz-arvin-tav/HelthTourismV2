using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Services.Impl;
using HelthTourismV2.Utilities;
using Microsoft.IdentityModel.Tokens;

namespace HelthTourismV2
{
    public class ValidationTokenHandler : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization.Parameter == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    string token = "";
                    TryRetrieveToken(actionContext.Request, out token);
                    try
                    {
                        //when generate jwt
                        string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                        string[] usernameAndPassword = decodedToken.Split(':');
                        string username = usernameAndPassword[0];
                        string password = usernameAndPassword[1];
                        // user pass check
                        TblUserPass patient = new UserPassService().SelectUserPassByUsernameAndPassword(username, password);
                        if (patient.id != -1)
                        {
                            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                        }
                        else
                        {
                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                        }
                    }
                    catch
                    {
                        //when check Jwt
                        try
                        {
                            string sec = SecurityProtocol.FetchJwtProtocolKey();//88 string length
                            DateTime now = DateTime.UtcNow;
                            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sec));
                            SecurityToken securityToken;
                            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                            TokenValidationParameters validationParameters = new TokenValidationParameters()
                            {
                                ValidAudience = "Yanal",
                                ValidIssuer = "Yanal",
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                LifetimeValidator = LifetimeValidator,
                                IssuerSigningKey = securityKey
                            };
                            Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                            HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);
                        }
                        catch
                        {
                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                        }
                    }
                }
            }
            catch
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            try
            {
                token = null;
                string bearerToken = request.Headers.Authorization.Parameter;
                token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
                return true;
            }
            catch
            {
                token = null;
                return false;
            }
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                expires = expires.Value.AddSeconds(5);
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}