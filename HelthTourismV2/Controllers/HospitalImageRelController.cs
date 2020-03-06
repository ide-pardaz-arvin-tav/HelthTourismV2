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
    [RoutePrefix("api/HospitalImageRelCore")]
    public class HospitalImageRelController : ApiController
    {
        [Route("AddHospitalImageRel")]
        [HttpPost]
        public IHttpActionResult AddHospitalImageRel(TblHospitalImageRel hospitalImageRel)
        {
            var task = Task.Run(() => new HospitalImageRelService().AddHospitalImageRel(hospitalImageRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblHospitalImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteHospitalImageRel")]
        [HttpPost]
        public IHttpActionResult DeleteHospitalImageRel(int id)
        {
            var task = Task.Run(() => new HospitalImageRelService().DeleteHospitalImageRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateHospitalImageRel")]
        [HttpPost]
        public IHttpActionResult UpdateHospitalImageRel(List<object> hospitalImageRelLogId)
        {
            TblHospitalImageRel hospitalImageRel = JsonConvert.DeserializeObject<TblHospitalImageRel>(hospitalImageRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(hospitalImageRelLogId[1].ToString());
            var task = Task.Run(() => new HospitalImageRelService().UpdateHospitalImageRel(hospitalImageRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllHospitalImageRels")]
        [HttpGet]
        public IHttpActionResult SelectAllHospitalImageRels()
        {
            var task = Task.Run(() => new HospitalImageRelService().SelectAllHospitalImageRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblHospitalImageRel> dto = new List<DtoTblHospitalImageRel>();
                    foreach (TblHospitalImageRel obj in task.Result)
                        dto.Add(new DtoTblHospitalImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalImageRelById")]
        [HttpPost]
        public IHttpActionResult SelectHospitalImageRelById(int id)
        {
            var task = Task.Run(() => new HospitalImageRelService().SelectHospitalImageRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblHospitalImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalImageRelsByHospitalId")]
        [HttpPost]
        public IHttpActionResult SelectHospitalImageRelByHospitalId(int pitalId)
        {
            var task = Task.Run(() => new HospitalImageRelService().SelectHospitalImageRelByHospitalId(pitalId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblHospitalImageRel> dto = new List<DtoTblHospitalImageRel>();
                    foreach (TblHospitalImageRel obj in task.Result)
                        dto.Add(new DtoTblHospitalImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalImageRelsByImageId")]
        [HttpPost]
        public IHttpActionResult SelectHospitalImageRelByImageId(int geId)
        {
            var task = Task.Run(() => new HospitalImageRelService().SelectHospitalImageRelByImageId(geId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblHospitalImageRel> dto = new List<DtoTblHospitalImageRel>();
                    foreach (TblHospitalImageRel obj in task.Result)
                        dto.Add(new DtoTblHospitalImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
