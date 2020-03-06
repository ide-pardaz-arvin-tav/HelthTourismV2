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
    [RoutePrefix("api/PatientSicknessRelCore")]
    public class PatientSicknessRelController : ApiController
    {
        [Route("AddPatientSicknessRel")]
        [HttpPost]
        public IHttpActionResult AddPatientSicknessRel(TblPatientSicknessRel patientSicknessRel)
        {
            var task = Task.Run(() => new PatientSicknessRelService().AddPatientSicknessRel(patientSicknessRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatientSicknessRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeletePatientSicknessRel")]
        [HttpPost]
        public IHttpActionResult DeletePatientSicknessRel(int id)
        {
            var task = Task.Run(() => new PatientSicknessRelService().DeletePatientSicknessRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdatePatientSicknessRel")]
        [HttpPost]
        public IHttpActionResult UpdatePatientSicknessRel(List<object> patientSicknessRelLogId)
        {
            TblPatientSicknessRel patientSicknessRel = JsonConvert.DeserializeObject<TblPatientSicknessRel>(patientSicknessRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(patientSicknessRelLogId[1].ToString());
            var task = Task.Run(() => new PatientSicknessRelService().UpdatePatientSicknessRel(patientSicknessRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPatientSicknessRels")]
        [HttpGet]
        public IHttpActionResult SelectAllPatientSicknessRels()
        {
            var task = Task.Run(() => new PatientSicknessRelService().SelectAllPatientSicknessRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientSicknessRel> dto = new List<DtoTblPatientSicknessRel>();
                    foreach (TblPatientSicknessRel obj in task.Result)
                        dto.Add(new DtoTblPatientSicknessRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientSicknessRelById")]
        [HttpPost]
        public IHttpActionResult SelectPatientSicknessRelById(int id)
        {
            var task = Task.Run(() => new PatientSicknessRelService().SelectPatientSicknessRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatientSicknessRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientSicknessRelsByPatientId")]
        [HttpPost]
        public IHttpActionResult SelectPatientSicknessRelByPatientId(int ientId)
        {
            var task = Task.Run(() => new PatientSicknessRelService().SelectPatientSicknessRelByPatientId(ientId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientSicknessRel> dto = new List<DtoTblPatientSicknessRel>();
                    foreach (TblPatientSicknessRel obj in task.Result)
                        dto.Add(new DtoTblPatientSicknessRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientSicknessRelsBySicknessId")]
        [HttpPost]
        public IHttpActionResult SelectPatientSicknessRelBySicknessId(int knessId)
        {
            var task = Task.Run(() => new PatientSicknessRelService().SelectPatientSicknessRelBySicknessId(knessId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientSicknessRel> dto = new List<DtoTblPatientSicknessRel>();
                    foreach (TblPatientSicknessRel obj in task.Result)
                        dto.Add(new DtoTblPatientSicknessRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientSicknessRelsByDoctorId")]
        [HttpPost]
        public IHttpActionResult SelectPatientSicknessRelByDoctorId(int torId)
        {
            var task = Task.Run(() => new PatientSicknessRelService().SelectPatientSicknessRelByDoctorId(torId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientSicknessRel> dto = new List<DtoTblPatientSicknessRel>();
                    foreach (TblPatientSicknessRel obj in task.Result)
                        dto.Add(new DtoTblPatientSicknessRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientSicknessRelsByHospitalId")]
        [HttpPost]
        public IHttpActionResult SelectPatientSicknessRelByHospitalId(int pitalId)
        {
            var task = Task.Run(() => new PatientSicknessRelService().SelectPatientSicknessRelByHospitalId(pitalId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientSicknessRel> dto = new List<DtoTblPatientSicknessRel>();
                    foreach (TblPatientSicknessRel obj in task.Result)
                        dto.Add(new DtoTblPatientSicknessRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientSicknessRelsByBeforeCureDesc")]
        [HttpPost]
        public IHttpActionResult SelectPatientSicknessRelByBeforeCureDesc(int oreCureDesc)
        {
            var task = Task.Run(() => new PatientSicknessRelService().SelectPatientSicknessRelByBeforeCureDesc(oreCureDesc));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientSicknessRel> dto = new List<DtoTblPatientSicknessRel>();
                    foreach (TblPatientSicknessRel obj in task.Result)
                        dto.Add(new DtoTblPatientSicknessRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientSicknessRelsByAfterCureDesc")]
        [HttpPost]
        public IHttpActionResult SelectPatientSicknessRelByAfterCureDesc(int erCureDesc)
        {
            var task = Task.Run(() => new PatientSicknessRelService().SelectPatientSicknessRelByAfterCureDesc(erCureDesc));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientSicknessRel> dto = new List<DtoTblPatientSicknessRel>();
                    foreach (TblPatientSicknessRel obj in task.Result)
                        dto.Add(new DtoTblPatientSicknessRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
