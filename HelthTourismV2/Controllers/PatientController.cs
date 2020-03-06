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
    [RoutePrefix("api/PatientCore")]
    public class PatientController : ApiController
    {
        [Route("AddPatient")]
        [HttpPost]
        public IHttpActionResult AddPatient(TblPatient patient)
        {
            var task = Task.Run(() => new PatientService().AddPatient(patient));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeletePatient")]
        [HttpPost]
        public IHttpActionResult DeletePatient(int id)
        {
            var task = Task.Run(() => new PatientService().DeletePatient(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdatePatient")]
        [HttpPost]
        public IHttpActionResult UpdatePatient(List<object> patientLogId)
        {
            TblPatient patient = JsonConvert.DeserializeObject<TblPatient>(patientLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(patientLogId[1].ToString());
            var task = Task.Run(() => new PatientService().UpdatePatient(patient, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPatients")]
        [HttpGet]
        public IHttpActionResult SelectAllPatients()
        {
            var task = Task.Run(() => new PatientService().SelectAllPatients());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatient> dto = new List<DtoTblPatient>();
                    foreach (TblPatient obj in task.Result)
                        dto.Add(new DtoTblPatient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientById")]
        [HttpPost]
        public IHttpActionResult SelectPatientById(int id)
        {
            var task = Task.Run(() => new PatientService().SelectPatientById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByName")]
        [HttpPost]
        public IHttpActionResult SelectPatientByName(string name)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByIsMan")]
        [HttpPost]
        public IHttpActionResult SelectPatientByIsMan(bool isMan)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByIsMan(isMan));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatient> dto = new List<DtoTblPatient>();
                    foreach (TblPatient obj in task.Result)
                        dto.Add(new DtoTblPatient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByCountryId")]
        [HttpPost]
        public IHttpActionResult SelectPatientByCountryId(int countryId)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByCountryId(countryId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatient> dto = new List<DtoTblPatient>();
                    foreach (TblPatient obj in task.Result)
                        dto.Add(new DtoTblPatient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByCityId")]
        [HttpPost]
        public IHttpActionResult SelectPatientByCityId(int cityId)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByCityId(cityId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatient> dto = new List<DtoTblPatient>();
                    foreach (TblPatient obj in task.Result)
                        dto.Add(new DtoTblPatient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByPassNoOrIdentification")]
        [HttpPost]
        public IHttpActionResult SelectPatientByPassNoOrIdentification(int passNoOrIdentification)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByPassNoOrIdentification(passNoOrIdentification));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatient> dto = new List<DtoTblPatient>();
                    foreach (TblPatient obj in task.Result)
                        dto.Add(new DtoTblPatient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByEmail")]
        [HttpPost]
        public IHttpActionResult SelectPatientByEmail(string email)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByEmail(email));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectPatientByTellNo(string tellNo)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByUserPassId")]
        [HttpPost]
        public IHttpActionResult SelectPatientByUserPassId(int userPassId)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByUserPassId(userPassId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPatient> dto = new List<DtoTblPatient>();
                    foreach (TblPatient obj in task.Result)
                        dto.Add(new DtoTblPatient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByParentalName")]
        [HttpPost]
        public IHttpActionResult SelectPatientByParentalName(string parentalName)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByParentalName(parentalName));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPatientByHelpName")]
        [HttpPost]
        public IHttpActionResult SelectPatientByHelpName(string helpName)
        {
            var task = Task.Run(() => new PatientService().SelectPatientByHelpName(helpName));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPatient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSicknessByPatientId")]
        [HttpPost]
        public IHttpActionResult SelectSicknessByPatientId(int patientId)
        {
            var task = Task.Run(() => new PatientService().SelectSicknesssByPatientId(patientId));
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
        [Route("SelectImageByPatientId")]
        [HttpPost]
        public IHttpActionResult SelectImageByPatientId(int patientId)
        {
            var task = Task.Run(() => new PatientService().SelectImagesByPatientId(patientId));
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
