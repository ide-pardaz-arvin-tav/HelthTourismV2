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
    [RoutePrefix("api/CityCore")]
    public class CityController : ApiController
    {
        [Route("AddCity")]
        [HttpPost]
        public IHttpActionResult AddCity(TblCity city)
        {
            var task = Task.Run(() => new CityService().AddCity(city));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblCity(city, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteCity")]
        [HttpPost]
        public IHttpActionResult DeleteCity(int id)
        {
            var task = Task.Run(() => new CityService().DeleteCity(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateCity")]
        [HttpPost]
        public IHttpActionResult UpdateCity(List<object> cityLogId)
        {
            TblCity city = JsonConvert.DeserializeObject<TblCity>(cityLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(cityLogId[1].ToString());
            var task = Task.Run(() => new CityService().UpdateCity(city, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllCitys")]
        [HttpGet]
        public IHttpActionResult SelectAllCitys()
        {
            var task = Task.Run(() => new CityService().SelectAllCitys());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblCity> dto = new List<DtoTblCity>();
                    foreach (TblCity obj in task.Result)
                        dto.Add(new DtoTblCity(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCityById")]
        [HttpPost]
        public IHttpActionResult SelectCityById(int id)
        {
            var task = Task.Run(() => new CityService().SelectCityById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblCity(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCityByName")]
        [HttpPost]
        public IHttpActionResult SelectCityByName(string name)
        {
            var task = Task.Run(() => new CityService().SelectCityByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblCity(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCityByCountryId")]
        [HttpPost]
        public IHttpActionResult SelectCityByCountryId(int countryId)
        {
            var task = Task.Run(() => new CityService().SelectCityByCountryId(countryId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblCity> dto = new List<DtoTblCity>();
                    foreach (TblCity obj in task.Result)
                        dto.Add(new DtoTblCity(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
