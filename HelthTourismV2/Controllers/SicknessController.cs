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
    [RoutePrefix("api/SicknessCore")]
    public class SicknessController : ApiController
    {
        [Route("AddSickness")]
        [HttpPost]
        public IHttpActionResult AddSickness(TblSickness sickness)
        {
            var task = Task.Run(() => new SicknessService().AddSickness(sickness));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblSickness(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteSickness")]
        [HttpPost]
        public IHttpActionResult DeleteSickness(int id)
        {
            var task = Task.Run(() => new SicknessService().DeleteSickness(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateSickness")]
        [HttpPost]
        public IHttpActionResult UpdateSickness(List<object> sicknessLogId)
        {
            TblSickness sickness = JsonConvert.DeserializeObject<TblSickness>(sicknessLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(sicknessLogId[1].ToString());
            var task = Task.Run(() => new SicknessService().UpdateSickness(sickness, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllSicknesss")]
        [HttpGet]
        public IHttpActionResult SelectAllSicknesss()
        {
            var task = Task.Run(() => new SicknessService().SelectAllSicknesss());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblSickness> dto = new List<DtoTblSickness>();
                    foreach (TblSickness obj in task.Result)
                        dto.Add(new DtoTblSickness(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSicknessById")]
        [HttpPost]
        public IHttpActionResult SelectSicknessById(int id)
        {
            var task = Task.Run(() => new SicknessService().SelectSicknessById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblSickness(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSicknessByName")]
        [HttpPost]
        public IHttpActionResult SelectSicknessByName(string name)
        {
            var task = Task.Run(() => new SicknessService().SelectSicknessByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblSickness(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSicknessBySectionId")]
        [HttpPost]
        public IHttpActionResult SelectSicknessBySectionId(int sectionId)
        {
            var task = Task.Run(() => new SicknessService().SelectSicknessBySectionId(sectionId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblSickness> dto = new List<DtoTblSickness>();
                    foreach (TblSickness obj in task.Result)
                        dto.Add(new DtoTblSickness(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
