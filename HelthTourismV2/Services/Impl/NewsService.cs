using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class NewsService : INewsService
    {
        public TblNews AddNews(TblNews news)
        {
            return new NewsRepo().AddNews(news);
        }
        public bool DeleteNews(int id)
        {
            return new NewsRepo().DeleteNews(id);
        }
        public bool UpdateNews(TblNews news, int logId)
        {
            return new NewsRepo().UpdateNews(news, logId);
        }
        public List<TblNews> SelectAllNewss()
        {
            return new NewsRepo().SelectAllNewss();
        }
        public TblNews SelectNewsById(int id)
        {
            return (TblNews)new NewsRepo().SelectNewsById(id);
        }
        public TblNews SelectNewsByTitle(string title)
        {
            return new NewsRepo().SelectNewsByTitle(title);
        }
        public List<TblImage> SelectImagesByNewsId(int newsId)
        {
            List<TblNewsImageRel> stp1 = new NewsImageRelRepo().SelectNewsImageRelByNewsId(newsId);
            List<TblImage> stp2 = new List<TblImage>();
            foreach (TblNewsImageRel rel in stp1)
                stp2.Add(new ImageRepo().SelectImageById(rel.ImageId));
            return stp2;
        }
    }
}