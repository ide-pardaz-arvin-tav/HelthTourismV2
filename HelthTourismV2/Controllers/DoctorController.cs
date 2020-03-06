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
    [RoutePrefix("api/DoctorCore")]
    public class DoctorController : ApiController
    {
        [Route("AddDoctor")]
        [HttpPost]
        public IHttpActionResult AddDoctor(TblDoctor doctor)
        {
            var task = Task.Run(() => new DoctorService().AddDoctor(doctor));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteDoctor")]
        [HttpPost]
        public IHttpActionResult DeleteDoctor(int id)
        {
            var task = Task.Run(() => new DoctorService().DeleteDoctor(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateDoctor")]
        [HttpPost]
        public IHttpActionResult UpdateDoctor(List<object> doctorLogId)
        {
            TblDoctor doctor = JsonConvert.DeserializeObject<TblDoctor>(doctorLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(doctorLogId[1].ToString());
            var task = Task.Run(() => new DoctorService().UpdateDoctor(doctor, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllDoctors")]
        [HttpGet]
        public IHttpActionResult SelectAllDoctors()
        {
            var task = Task.Run(() => new DoctorService().SelectAllDoctors());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDoctor> dto = new List<DtoTblDoctor>();
                    foreach (TblDoctor obj in task.Result)
                        dto.Add(new DtoTblDoctor(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorById")]
        [HttpPost]
        public IHttpActionResult SelectDoctorById(int id)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorByName")]
        [HttpPost]
        public IHttpActionResult SelectDoctorByName(string name)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblDoctor(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorBySectionId")]
        [HttpPost]
        public IHttpActionResult SelectDoctorBySectionId(int sectionId)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorBySectionId(sectionId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDoctor> dto = new List<DtoTblDoctor>();
                    foreach (TblDoctor obj in task.Result)
                        dto.Add(new DtoTblDoctor(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDoctorByNowActive")]
        [HttpPost]
        public IHttpActionResult SelectDoctorByNowActive(bool nowActive)
        {
            var task = Task.Run(() => new DoctorService().SelectDoctorByNowActive(nowActive));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDoctor> dto = new List<DtoTblDoctor>();
                    foreach (TblDoctor obj in task.Result)
                        dto.Add(new DtoTblDoctor(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
