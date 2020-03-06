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
    [RoutePrefix("api/HospitalCore")]
    public class HospitalController : ApiController
    {
        [Route("AddHospital")]
        [HttpPost]
        public IHttpActionResult AddHospital(TblHospital hospital)
        {
            var task = Task.Run(() => new HospitalService().AddHospital(hospital));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblHospital(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteHospital")]
        [HttpPost]
        public IHttpActionResult DeleteHospital(int id)
        {
            var task = Task.Run(() => new HospitalService().DeleteHospital(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateHospital")]
        [HttpPost]
        public IHttpActionResult UpdateHospital(List<object> hospitalLogId)
        {
            TblHospital hospital = JsonConvert.DeserializeObject<TblHospital>(hospitalLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(hospitalLogId[1].ToString());
            var task = Task.Run(() => new HospitalService().UpdateHospital(hospital, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllHospitals")]
        [HttpGet]
        public IHttpActionResult SelectAllHospitals()
        {
            var task = Task.Run(() => new HospitalService().SelectAllHospitals());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblHospital> dto = new List<DtoTblHospital>();
                    foreach (TblHospital obj in task.Result)
                        dto.Add(new DtoTblHospital(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalById")]
        [HttpPost]
        public IHttpActionResult SelectHospitalById(int id)
        {
            var task = Task.Run(() => new HospitalService().SelectHospitalById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblHospital(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalByName")]
        [HttpPost]
        public IHttpActionResult SelectHospitalByName(string name)
        {
            var task = Task.Run(() => new HospitalService().SelectHospitalByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblHospital(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectHospitalByUserPassId")]
        [HttpPost]
        public IHttpActionResult SelectHospitalByUserPassId(int userPassId)
        {
            var task = Task.Run(() => new HospitalService().SelectHospitalByUserPassId(userPassId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblHospital> dto = new List<DtoTblHospital>();
                    foreach (TblHospital obj in task.Result)
                        dto.Add(new DtoTblHospital(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectImageByHospitalId")]
        [HttpPost]
        public IHttpActionResult SelectImageByHospitalId(int hospitalId)
        {
            var task = Task.Run(() => new HospitalService().SelectImagesByHospitalId(hospitalId));
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
        [Route("SelectSectionByHospitalId")]
        [HttpPost]
        public IHttpActionResult SelectSectionByHospitalId(int hospitalId)
        {
            var task = Task.Run(() => new HospitalService().SelectSectionsByHospitalId(hospitalId));
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

    }
}
