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
    [RoutePrefix("api/OperationImageRelCore")]
    public class OperationImageRelController : ApiController
    {
        [Route("AddOperationImageRel")]
        [HttpPost]
        public IHttpActionResult AddOperationImageRel(TblOperationImageRel operationImageRel)
        {
            var task = Task.Run(() => new OperationImageRelService().AddOperationImageRel(operationImageRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblOperationImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteOperationImageRel")]
        [HttpPost]
        public IHttpActionResult DeleteOperationImageRel(int id)
        {
            var task = Task.Run(() => new OperationImageRelService().DeleteOperationImageRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateOperationImageRel")]
        [HttpPost]
        public IHttpActionResult UpdateOperationImageRel(List<object> operationImageRelLogId)
        {
            TblOperationImageRel operationImageRel = JsonConvert.DeserializeObject<TblOperationImageRel>(operationImageRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(operationImageRelLogId[1].ToString());
            var task = Task.Run(() => new OperationImageRelService().UpdateOperationImageRel(operationImageRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllOperationImageRels")]
        [HttpGet]
        public IHttpActionResult SelectAllOperationImageRels()
        {
            var task = Task.Run(() => new OperationImageRelService().SelectAllOperationImageRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblOperationImageRel> dto = new List<DtoTblOperationImageRel>();
                    foreach (TblOperationImageRel obj in task.Result)
                        dto.Add(new DtoTblOperationImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectOperationImageRelById")]
        [HttpPost]
        public IHttpActionResult SelectOperationImageRelById(int id)
        {
            var task = Task.Run(() => new OperationImageRelService().SelectOperationImageRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblOperationImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectOperationImageRelsByOperationId")]
        [HttpPost]
        public IHttpActionResult SelectOperationImageRelByOperationId(int rationId)
        {
            var task = Task.Run(() => new OperationImageRelService().SelectOperationImageRelByOperationId(rationId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblOperationImageRel> dto = new List<DtoTblOperationImageRel>();
                    foreach (TblOperationImageRel obj in task.Result)
                        dto.Add(new DtoTblOperationImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectOperationImageRelsByImageId")]
        [HttpPost]
        public IHttpActionResult SelectOperationImageRelByImageId(int geId)
        {
            var task = Task.Run(() => new OperationImageRelService().SelectOperationImageRelByImageId(geId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblOperationImageRel> dto = new List<DtoTblOperationImageRel>();
                    foreach (TblOperationImageRel obj in task.Result)
                        dto.Add(new DtoTblOperationImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
