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
    [RoutePrefix("api/NewsImageRelCore")]
    public class NewsImageRelController : ApiController
    {
        [Route("AddNewsImageRel")]
        [HttpPost]
        public IHttpActionResult AddNewsImageRel(TblNewsImageRel newsImageRel)
        {
            var task = Task.Run(() => new NewsImageRelService().AddNewsImageRel(newsImageRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblNewsImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteNewsImageRel")]
        [HttpPost]
        public IHttpActionResult DeleteNewsImageRel(int id)
        {
            var task = Task.Run(() => new NewsImageRelService().DeleteNewsImageRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateNewsImageRel")]
        [HttpPost]
        public IHttpActionResult UpdateNewsImageRel(List<object> newsImageRelLogId)
        {
            TblNewsImageRel newsImageRel = JsonConvert.DeserializeObject<TblNewsImageRel>(newsImageRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(newsImageRelLogId[1].ToString());
            var task = Task.Run(() => new NewsImageRelService().UpdateNewsImageRel(newsImageRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllNewsImageRels")]
        [HttpGet]
        public IHttpActionResult SelectAllNewsImageRels()
        {
            var task = Task.Run(() => new NewsImageRelService().SelectAllNewsImageRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblNewsImageRel> dto = new List<DtoTblNewsImageRel>();
                    foreach (TblNewsImageRel obj in task.Result)
                        dto.Add(new DtoTblNewsImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectNewsImageRelById")]
        [HttpPost]
        public IHttpActionResult SelectNewsImageRelById(int id)
        {
            var task = Task.Run(() => new NewsImageRelService().SelectNewsImageRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblNewsImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectNewsImageRelsByNewsId")]
        [HttpPost]
        public IHttpActionResult SelectNewsImageRelByNewsId(int sId)
        {
            var task = Task.Run(() => new NewsImageRelService().SelectNewsImageRelByNewsId(sId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblNewsImageRel> dto = new List<DtoTblNewsImageRel>();
                    foreach (TblNewsImageRel obj in task.Result)
                        dto.Add(new DtoTblNewsImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectNewsImageRelsByImageId")]
        [HttpPost]
        public IHttpActionResult SelectNewsImageRelByImageId(int geId)
        {
            var task = Task.Run(() => new NewsImageRelService().SelectNewsImageRelByImageId(geId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblNewsImageRel> dto = new List<DtoTblNewsImageRel>();
                    foreach (TblNewsImageRel obj in task.Result)
                        dto.Add(new DtoTblNewsImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
