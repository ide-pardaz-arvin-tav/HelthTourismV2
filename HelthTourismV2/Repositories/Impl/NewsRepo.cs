using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class NewsRepo : INewsRepo
    {
        public TblNews AddNews(TblNews news)
        {
            return (TblNews) new MainProvider().Add(news);
        }
        public bool DeleteNews(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblNews, id);
        }
        public bool UpdateNews(TblNews news, int logId)
        {
            return new MainProvider().Update(news, logId);
        }
        public List<TblNews> SelectAllNewss()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblNews).Cast<TblNews>().ToList();
        }
        public TblNews SelectNewsById(int id)
        {
            return (TblNews)new MainProvider().SelectById(MainProvider.Tables.TblNews, id);
        }
        public TblNews SelectNewsByTitle(string title)
        {
            return new MainProvider().SelectNewsByTitle(title);
        }

    }
}