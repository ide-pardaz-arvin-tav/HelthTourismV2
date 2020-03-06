using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using HelthTourismV2.Models.Dto;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Services.Impl;

namespace HelthTourismV2.Controllers
{
    [RoutePrefix("api/UserPassCore")]
    public class UserPassController : ApiController
    {
        [Route("AddUserPass")]
        [HttpPost]
        public IHttpActionResult AddUserPass(TblUserPass userPass)
        {
            var task = Task.Run(() => new UserPassService().AddUserPass(userPass));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblUserPass(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteUserPass")]
        [HttpPost]
        public IHttpActionResult DeleteUserPass(int id)
        {
            var task = Task.Run(() => new UserPassService().DeleteUserPass(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateUserPass")]
        [HttpPost]
        public IHttpActionResult UpdateUserPass(List<object> userPassLogId)
        {
            TblUserPass userPass = JsonConvert.DeserializeObject<TblUserPass>(userPassLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(userPassLogId[1].ToString());
            var task = Task.Run(() => new UserPassService().UpdateUserPass(userPass, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllUserPasss")]
        [HttpGet]
        public IHttpActionResult SelectAllUserPasss()
        {
            var task = Task.Run(() => new UserPassService().SelectAllUserPasss());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblUserPass> dto = new List<DtoTblUserPass>();
                    foreach (TblUserPass obj in task.Result)
                        dto.Add(new DtoTblUserPass(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectUserPassById")]
        [HttpPost]
        public IHttpActionResult SelectUserPassById(int id)
        {
            var task = Task.Run(() => new UserPassService().SelectUserPassById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblUserPass(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectUserPassByUsernameAndPassword")]
        [HttpPost]
        public IHttpActionResult SelectUserPassByUsernameAndPassword(List<object> usernamePassword)
        {
            string username = JsonConvert.DeserializeObject<string>(usernamePassword[0].ToString());
            string password = JsonConvert.DeserializeObject<string>(usernamePassword[1].ToString());
            var task = Task.Run(() => new UserPassService().SelectUserPassByUsernameAndPassword(username, password));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblUserPass(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectUserPassByUsername")]
        [HttpPost]
        public IHttpActionResult SelectUserPassByUsername(string username)
        {
            var task = Task.Run(() => new UserPassService().SelectUserPassByUsername(username));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblUserPass(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectUserPassByPassword")]
        [HttpPost]
        public IHttpActionResult SelectUserPassByPassword(string password)
        {
            var task = Task.Run(() => new UserPassService().SelectUserPassByPassword(password));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblUserPass(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectUserPassByIsHelthApple")]
        [HttpPost]
        public IHttpActionResult SelectUserPassByIsHelthApple(bool isHelthApple)
        {
            var task = Task.Run(() => new UserPassService().SelectUserPassByIsHelthApple(isHelthApple));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblUserPass> dto = new List<DtoTblUserPass>();
                    foreach (TblUserPass obj in task.Result)
                        dto.Add(new DtoTblUserPass(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
