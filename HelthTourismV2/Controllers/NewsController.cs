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
    [RoutePrefix("api/NewsCore")]
    public class NewsController : ApiController
    {
        [Route("AddNews")]
        [HttpPost]
        public IHttpActionResult AddNews(TblNews news)
        {
            var task = Task.Run(() => new NewsService().AddNews(news));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblNews(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteNews")]
        [HttpPost]
        public IHttpActionResult DeleteNews(int id)
        {
            var task = Task.Run(() => new NewsService().DeleteNews(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateNews")]
        [HttpPost]
        public IHttpActionResult UpdateNews(List<object> newsLogId)
        {
            TblNews news = JsonConvert.DeserializeObject<TblNews>(newsLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(newsLogId[1].ToString());
            var task = Task.Run(() => new NewsService().UpdateNews(news, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllNewss")]
        [HttpGet]
        public IHttpActionResult SelectAllNewss()
        {
            var task = Task.Run(() => new NewsService().SelectAllNewss());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblNews> dto = new List<DtoTblNews>();
                    foreach (TblNews obj in task.Result)
                        dto.Add(new DtoTblNews(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectNewsById")]
        [HttpPost]
        public IHttpActionResult SelectNewsById(int id)
        {
            var task = Task.Run(() => new NewsService().SelectNewsById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblNews(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectNewsByTitle")]
        [HttpPost]
        public IHttpActionResult SelectNewsByTitle(string title)
        {
            var task = Task.Run(() => new NewsService().SelectNewsByTitle(title));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblNews(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectImageByNewsId")]
        [HttpPost]
        public IHttpActionResult SelectImageByNewsId(int newsId)
        {
            var task = Task.Run(() => new NewsService().SelectImagesByNewsId(newsId));
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
