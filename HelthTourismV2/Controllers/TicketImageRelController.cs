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
    [RoutePrefix("api/TicketImageRelCore")]
    public class TicketImageRelController : ApiController
    {
        [Route("AddTicketImageRel")]
        [HttpPost]
        public IHttpActionResult AddTicketImageRel(TblTicketImageRel ticketImageRel)
        {
            var task = Task.Run(() => new TicketImageRelService().AddTicketImageRel(ticketImageRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblTicketImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteTicketImageRel")]
        [HttpPost]
        public IHttpActionResult DeleteTicketImageRel(int id)
        {
            var task = Task.Run(() => new TicketImageRelService().DeleteTicketImageRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateTicketImageRel")]
        [HttpPost]
        public IHttpActionResult UpdateTicketImageRel(List<object> ticketImageRelLogId)
        {
            TblTicketImageRel ticketImageRel = JsonConvert.DeserializeObject<TblTicketImageRel>(ticketImageRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(ticketImageRelLogId[1].ToString());
            var task = Task.Run(() => new TicketImageRelService().UpdateTicketImageRel(ticketImageRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllTicketImageRels")]
        [HttpGet]
        public IHttpActionResult SelectAllTicketImageRels()
        {
            var task = Task.Run(() => new TicketImageRelService().SelectAllTicketImageRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTicketImageRel> dto = new List<DtoTblTicketImageRel>();
                    foreach (TblTicketImageRel obj in task.Result)
                        dto.Add(new DtoTblTicketImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTicketImageRelById")]
        [HttpPost]
        public IHttpActionResult SelectTicketImageRelById(int id)
        {
            var task = Task.Run(() => new TicketImageRelService().SelectTicketImageRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblTicketImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTicketImageRelsByTicketId")]
        [HttpPost]
        public IHttpActionResult SelectTicketImageRelByTicketId(int ketId)
        {
            var task = Task.Run(() => new TicketImageRelService().SelectTicketImageRelByTicketId(ketId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTicketImageRel> dto = new List<DtoTblTicketImageRel>();
                    foreach (TblTicketImageRel obj in task.Result)
                        dto.Add(new DtoTblTicketImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTicketImageRelsByImageId")]
        [HttpPost]
        public IHttpActionResult SelectTicketImageRelByImageId(int geId)
        {
            var task = Task.Run(() => new TicketImageRelService().SelectTicketImageRelByImageId(geId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTicketImageRel> dto = new List<DtoTblTicketImageRel>();
                    foreach (TblTicketImageRel obj in task.Result)
                        dto.Add(new DtoTblTicketImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
