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
    [RoutePrefix("api/TicketCore")]
    public class TicketController : ApiController
    {
        [Route("AddTicket")]
        [HttpPost]
        public IHttpActionResult AddTicket(TblTicket ticket)
        {
            var task = Task.Run(() => new TicketService().AddTicket(ticket));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblTicket(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteTicket")]
        [HttpPost]
        public IHttpActionResult DeleteTicket(int id)
        {
            var task = Task.Run(() => new TicketService().DeleteTicket(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateTicket")]
        [HttpPost]
        public IHttpActionResult UpdateTicket(List<object> ticketLogId)
        {
            TblTicket ticket = JsonConvert.DeserializeObject<TblTicket>(ticketLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(ticketLogId[1].ToString());
            var task = Task.Run(() => new TicketService().UpdateTicket(ticket, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllTickets")]
        [HttpGet]
        public IHttpActionResult SelectAllTickets()
        {
            var task = Task.Run(() => new TicketService().SelectAllTickets());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTicket> dto = new List<DtoTblTicket>();
                    foreach (TblTicket obj in task.Result)
                        dto.Add(new DtoTblTicket(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTicketById")]
        [HttpPost]
        public IHttpActionResult SelectTicketById(int id)
        {
            var task = Task.Run(() => new TicketService().SelectTicketById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblTicket(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTicketByIsRegistered")]
        [HttpPost]
        public IHttpActionResult SelectTicketByIsRegistered(bool isRegistered)
        {
            var task = Task.Run(() => new TicketService().SelectTicketByIsRegistered(isRegistered));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTicket> dto = new List<DtoTblTicket>();
                    foreach (TblTicket obj in task.Result)
                        dto.Add(new DtoTblTicket(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTicketByUserPassId")]
        [HttpPost]
        public IHttpActionResult SelectTicketByUserPassId(int userPassId)
        {
            var task = Task.Run(() => new TicketService().SelectTicketByUserPassId(userPassId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTicket> dto = new List<DtoTblTicket>();
                    foreach (TblTicket obj in task.Result)
                        dto.Add(new DtoTblTicket(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTicketByEmail")]
        [HttpPost]
        public IHttpActionResult SelectTicketByEmail(string email)
        {
            var task = Task.Run(() => new TicketService().SelectTicketByEmail(email));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblTicket(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTicketByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectTicketByTellNo(string tellNo)
        {
            var task = Task.Run(() => new TicketService().SelectTicketByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblTicket(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectImageByTicketId")]
        [HttpPost]
        public IHttpActionResult SelectImageByTicketId(int ticketId)
        {
            var task = Task.Run(() => new TicketService().SelectImagesByTicketId(ticketId));
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
