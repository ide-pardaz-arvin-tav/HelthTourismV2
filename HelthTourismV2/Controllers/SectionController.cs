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
    [RoutePrefix("api/SectionCore")]
    public class SectionController : ApiController
    {
        [Route("AddSection")]
        [HttpPost]
        public IHttpActionResult AddSection(TblSection section)
        {
            var task = Task.Run(() => new SectionService().AddSection(section));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblSection(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteSection")]
        [HttpPost]
        public IHttpActionResult DeleteSection(int id)
        {
            var task = Task.Run(() => new SectionService().DeleteSection(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateSection")]
        [HttpPost]
        public IHttpActionResult UpdateSection(List<object> sectionLogId)
        {
            TblSection section = JsonConvert.DeserializeObject<TblSection>(sectionLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(sectionLogId[1].ToString());
            var task = Task.Run(() => new SectionService().UpdateSection(section, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllSections")]
        [HttpGet]
        public IHttpActionResult SelectAllSections()
        {
            var task = Task.Run(() => new SectionService().SelectAllSections());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblSection> dto = new List<DtoTblSection>();
                    foreach (TblSection obj in task.Result)
                        dto.Add(new DtoTblSection(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSectionById")]
        [HttpPost]
        public IHttpActionResult SelectSectionById(int id)
        {
            var task = Task.Run(() => new SectionService().SelectSectionById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblSection(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSectionBySectionName")]
        [HttpPost]
        public IHttpActionResult SelectSectionBySectionName(string sectionName)
        {
            var task = Task.Run(() => new SectionService().SelectSectionBySectionName(sectionName));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblSection(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectOperationBySectionId")]
        [HttpPost]
        public IHttpActionResult SelectOperationBySectionId(int sectionId)
        {
            var task = Task.Run(() => new SectionService().SelectOperationsBySectionId(sectionId));
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

    }
}
