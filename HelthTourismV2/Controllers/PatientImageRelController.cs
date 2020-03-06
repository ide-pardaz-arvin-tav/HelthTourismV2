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
    [RoutePrefix("api/PatientImageRelCore")]
    public class PatientImageRelController : ApiController
    {
        [Route("AddPatientImageRel")]
        [HttpPost]
        public IHttpActionResult AddPatientImageRel(TblPatientImageRel patientImageRel)
        {
            var task = Task.Run(() => new PatientImageRelService().AddPatientImageRel(patientImageRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatientImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeletePatientImageRel")]
        [HttpPost]
        public IHttpActionResult DeletePatientImageRel(int id)
        {
            var task = Task.Run(() => new PatientImageRelService().DeletePatientImageRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdatePatientImageRel")]
        [HttpPost]
        public IHttpActionResult UpdatePatientImageRel(List<object> patientImageRelLogId)
        {
            TblPatientImageRel patientImageRel = JsonConvert.DeserializeObject<TblPatientImageRel>(patientImageRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(patientImageRelLogId[1].ToString());
            var task = Task.Run(() => new PatientImageRelService().UpdatePatientImageRel(patientImageRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPatientImageRels")]
        [HttpGet]
        public IHttpActionResult SelectAllPatientImageRels()
        {
            var task = Task.Run(() => new PatientImageRelService().SelectAllPatientImageRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientImageRel> dto = new List<DtoTblPatientImageRel>();
                    foreach (TblPatientImageRel obj in task.Result)
                        dto.Add(new DtoTblPatientImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientImageRelById")]
        [HttpPost]
        public IHttpActionResult SelectPatientImageRelById(int id)
        {
            var task = Task.Run(() => new PatientImageRelService().SelectPatientImageRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatientImageRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientImageRelsByPatientId")]
        [HttpPost]
        public IHttpActionResult SelectPatientImageRelByPatientId(int ientId)
        {
            var task = Task.Run(() => new PatientImageRelService().SelectPatientImageRelByPatientId(ientId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientImageRel> dto = new List<DtoTblPatientImageRel>();
                    foreach (TblPatientImageRel obj in task.Result)
                        dto.Add(new DtoTblPatientImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientImageRelsByImageId")]
        [HttpPost]
        public IHttpActionResult SelectPatientImageRelByImageId(int geId)
        {
            var task = Task.Run(() => new PatientImageRelService().SelectPatientImageRelByImageId(geId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatientImageRel> dto = new List<DtoTblPatientImageRel>();
                    foreach (TblPatientImageRel obj in task.Result)
                        dto.Add(new DtoTblPatientImageRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
