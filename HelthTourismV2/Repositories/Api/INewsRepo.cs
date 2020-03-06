using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface INewsRepo
    {
        TblNews AddNews(TblNews news);
        bool DeleteNews(int id);
        bool UpdateNews(TblNews news, int logId);
        List<TblNews> SelectAllNewss();
        TblNews SelectNewsById(int id);
        TblNews SelectNewsByTitle(string title);

    }
}