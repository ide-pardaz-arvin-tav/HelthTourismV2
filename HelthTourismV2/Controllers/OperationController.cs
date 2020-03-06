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
    [RoutePrefix("api/OperationCore")]
    public class OperationController : ApiController
    {
        [Route("AddOperation")]
        [HttpPost]
        public IHttpActionResult AddOperation(TblOperation operation)
        {
            var task = Task.Run(() => new OperationService().AddOperation(operation));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblOperation(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteOperation")]
        [HttpPost]
        public IHttpActionResult DeleteOperation(int id)
        {
            var task = Task.Run(() => new OperationService().DeleteOperation(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateOperation")]
        [HttpPost]
        public IHttpActionResult UpdateOperation(List<object> operationLogId)
        {
            TblOperation operation = JsonConvert.DeserializeObject<TblOperation>(operationLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(operationLogId[1].ToString());
            var task = Task.Run(() => new OperationService().UpdateOperation(operation, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllOperations")]
        [HttpGet]
        public IHttpActionResult SelectAllOperations()
        {
            var task = Task.Run(() => new OperationService().SelectAllOperations());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblOperation> dto = new List<DtoTblOperation>();
                    foreach (TblOperation obj in task.Result)
                        dto.Add(new DtoTblOperation(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectOperationById")]
        [HttpPost]
        public IHttpActionResult SelectOperationById(int id)
        {
            var task = Task.Run(() => new OperationService().SelectOperationById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblOperation(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectOperationByOperationName")]
        [HttpPost]
        public IHttpActionResult SelectOperationByOperationName(string operationName)
        {
            var task = Task.Run(() => new OperationService().SelectOperationByOperationName(operationName));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblOperation(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectImageByOperationId")]
        [HttpPost]
        public IHttpActionResult SelectImageByOperationId(int operationId)
        {
            var task = Task.Run(() => new OperationService().SelectImagesByOperationId(operationId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblImage> dto = new List<DtoTblImage>();
                    foreach (TblImage obj in task.Result)
                        dto.Add(new DtoTblImage(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
