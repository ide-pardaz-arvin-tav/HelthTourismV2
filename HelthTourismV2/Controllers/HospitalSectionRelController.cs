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
    [RoutePrefix("api/HospitalSectionRelCore")]
    public class HospitalSectionRelController : ApiController
    {
        [Route("AddHospitalSectionRel")]
        [HttpPost]
        public IHttpActionResult AddHospitalSectionRel(TblHospitalSectionRel hospitalSectionRel)
        {
            var task = Task.Run(() => new HospitalSectionRelService().AddHospitalSectionRel(hospitalSectionRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblHospitalSectionRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteHospitalSectionRel")]
        [HttpPost]
        public IHttpActionResult DeleteHospitalSectionRel(int id)
        {
            var task = Task.Run(() => new HospitalSectionRelService().DeleteHospitalSectionRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateHospitalSectionRel")]
        [HttpPost]
        public IHttpActionResult UpdateHospitalSectionRel(List<object> hospitalSectionRelLogId)
        {
            TblHospitalSectionRel hospitalSectionRel = JsonConvert.DeserializeObject<TblHospitalSectionRel>(hospitalSectionRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(hospitalSectionRelLogId[1].ToString());
            var task = Task.Run(() => new HospitalSectionRelService().UpdateHospitalSectionRel(hospitalSectionRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllHospitalSectionRels")]
        [HttpGet]
        public IHttpActionResult SelectAllHospitalSectionRels()
        {
            var task = Task.Run(() => new HospitalSectionRelService().SelectAllHospitalSectionRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblHospitalSectionRel> dto = new List<DtoTblHospitalSectionRel>();
                    foreach (TblHospitalSectionRel obj in task.Result)
                        dto.Add(new DtoTblHospitalSectionRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalSectionRelById")]
        [HttpPost]
        public IHttpActionResult SelectHospitalSectionRelById(int id)
        {
            var task = Task.Run(() => new HospitalSectionRelService().SelectHospitalSectionRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblHospitalSectionRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalSectionRelsByHospitalId")]
        [HttpPost]
        public IHttpActionResult SelectHospitalSectionRelByHospitalId(int pitalId)
        {
            var task = Task.Run(() => new HospitalSectionRelService().SelectHospitalSectionRelByHospitalId(pitalId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblHospitalSectionRel> dto = new List<DtoTblHospitalSectionRel>();
                    foreach (TblHospitalSectionRel obj in task.Result)
                        dto.Add(new DtoTblHospitalSectionRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalSectionRelsBySectionId")]
        [HttpPost]
        public IHttpActionResult SelectHospitalSectionRelBySectionId(int tionId)
        {
            var task = Task.Run(() => new HospitalSectionRelService().SelectHospitalSectionRelBySectionId(tionId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblHospitalSectionRel> dto = new List<DtoTblHospitalSectionRel>();
                    foreach (TblHospitalSectionRel obj in task.Result)
                        dto.Add(new DtoTblHospitalSectionRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalSectionRelsByDoctorId")]
        [HttpPost]
        public IHttpActionResult SelectHospitalSectionRelByDoctorId(int torId)
        {
            var task = Task.Run(() => new HospitalSectionRelService().SelectHospitalSectionRelByDoctorId(torId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblHospitalSectionRel> dto = new List<DtoTblHospitalSectionRel>();
                    foreach (TblHospitalSectionRel obj in task.Result)
                        dto.Add(new DtoTblHospitalSectionRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
