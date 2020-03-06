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
    [RoutePrefix("api/CountryCore")]
    public class CountryController : ApiController
    {
        [Route("AddCountry")]
        [HttpPost]
        public IHttpActionResult AddCountry(TblCountry country)
        {
            var task = Task.Run(() => new CountryService().AddCountry(country));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblCountry(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteCountry")]
        [HttpPost]
        public IHttpActionResult DeleteCountry(int id)
        {
            var task = Task.Run(() => new CountryService().DeleteCountry(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateCountry")]
        [HttpPost]
        public IHttpActionResult UpdateCountry(List<object> countryLogId)
        {
            TblCountry country = JsonConvert.DeserializeObject<TblCountry>(countryLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(countryLogId[1].ToString());
            var task = Task.Run(() => new CountryService().UpdateCountry(country, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllCountrys")]
        [HttpGet]
        public IHttpActionResult SelectAllCountrys()
        {
            var task = Task.Run(() => new CountryService().SelectAllCountrys());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblCountry> dto = new List<DtoTblCountry>();
                    foreach (TblCountry obj in task.Result)
                        dto.Add(new DtoTblCountry(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCountryById")]
        [HttpPost]
        public IHttpActionResult SelectCountryById(int id)
        {
            var task = Task.Run(() => new CountryService().SelectCountryById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblCountry(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCountryByName")]
        [HttpPost]
        public IHttpActionResult SelectCountryByName(string name)
        {
            var task = Task.Run(() => new CountryService().SelectCountryByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblCountry(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
