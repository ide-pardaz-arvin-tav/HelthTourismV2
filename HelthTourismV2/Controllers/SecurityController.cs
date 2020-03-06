using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;

namespace HelthTourismV2.Controllers
{
    [RoutePrefix("sec/SecurityCore")]
    public class SecurityController : ApiController
    {
        public bool IsApiLocked = false;
         
        [Route("LockApi")]
        [HttpGet]
        public IHttpActionResult LockApi()
        {
            
            IsApiLocked = true;
            return Ok();
        }

        [Route("UnlockApi")]
        [HttpGet]
        public IHttpActionResult UnlockApi()
        {
            IsApiLocked = true;
            return Ok();
        }

        [Route("ShowApiLockState")]
        [HttpGet]
        public bool ShowApiLockState()
        {
            return IsApiLocked;
        }
    }
}
