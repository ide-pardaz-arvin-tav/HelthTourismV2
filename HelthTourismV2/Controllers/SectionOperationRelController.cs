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
    [RoutePrefix("api/SectionOperationRelCore")]
    public class SectionOperationRelController : ApiController
    {
        [Route("AddSectionOperationRel")]
        [HttpPost]
        public IHttpActionResult AddSectionOperationRel(TblSectionOperationRel sectionOperationRel)
        {
            var task = Task.Run(() => new SectionOperationRelService().AddSectionOperationRel(sectionOperationRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblSectionOperationRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteSectionOperationRel")]
        [HttpPost]
        public IHttpActionResult DeleteSectionOperationRel(int id)
        {
            var task = Task.Run(() => new SectionOperationRelService().DeleteSectionOperationRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateSectionOperationRel")]
        [HttpPost]
        public IHttpActionResult UpdateSectionOperationRel(List<object> sectionOperationRelLogId)
        {
            TblSectionOperationRel sectionOperationRel = JsonConvert.DeserializeObject<TblSectionOperationRel>(sectionOperationRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(sectionOperationRelLogId[1].ToString());
            var task = Task.Run(() => new SectionOperationRelService().UpdateSectionOperationRel(sectionOperationRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllSectionOperationRels")]
        [HttpGet]
        public IHttpActionResult SelectAllSectionOperationRels()
        {
            var task = Task.Run(() => new SectionOperationRelService().SelectAllSectionOperationRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblSectionOperationRel> dto = new List<DtoTblSectionOperationRel>();
                    foreach (TblSectionOperationRel obj in task.Result)
                        dto.Add(new DtoTblSectionOperationRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSectionOperationRelById")]
        [HttpPost]
        public IHttpActionResult SelectSectionOperationRelById(int id)
        {
            var task = Task.Run(() => new SectionOperationRelService().SelectSectionOperationRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblSectionOperationRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSectionOperationRelsBySectionId")]
        [HttpPost]
        public IHttpActionResult SelectSectionOperationRelBySectionId(int tionId)
        {
            var task = Task.Run(() => new SectionOperationRelService().SelectSectionOperationRelBySectionId(tionId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblSectionOperationRel> dto = new List<DtoTblSectionOperationRel>();
                    foreach (TblSectionOperationRel obj in task.Result)
                        dto.Add(new DtoTblSectionOperationRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSectionOperationRelsByOperationId")]
        [HttpPost]
        public IHttpActionResult SelectSectionOperationRelByOperationId(int rationId)
        {
            var task = Task.Run(() => new SectionOperationRelService().SelectSectionOperationRelByOperationId(rationId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblSectionOperationRel> dto = new List<DtoTblSectionOperationRel>();
                    foreach (TblSectionOperationRel obj in task.Result)
                        dto.Add(new DtoTblSectionOperationRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
