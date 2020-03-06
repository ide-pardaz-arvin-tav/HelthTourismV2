using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class NewsImageRelRepo : INewsImageRelRepo
    {
        public TblNewsImageRel AddNewsImageRel(TblNewsImageRel newsImageRel)
        {
            return (TblNewsImageRel) new MainProvider().Add(newsImageRel);
        }
        public bool DeleteNewsImageRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblNewsImageRel, id);
        }
        public bool UpdateNewsImageRel(TblNewsImageRel newsImageRel, int logId)
        {
            return new MainProvider().Update(newsImageRel, logId);
        }
        public List<TblNewsImageRel> SelectAllNewsImageRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblNewsImageRel).Cast<TblNewsImageRel>().ToList();
        }
        public TblNewsImageRel SelectNewsImageRelById(int id)
        {
            return (TblNewsImageRel)new MainProvider().SelectById(MainProvider.Tables.TblNewsImageRel, id);
        }
        public List<TblNewsImageRel> SelectNewsImageRelByNewsId(int newsId)
        {
            return new MainProvider().SelectNewsImageRel(newsId, MainProvider.NewsImageRel.NewsId);
        }
        public List<TblNewsImageRel> SelectNewsImageRelByImageId(int imageId)
        {
            return new MainProvider().SelectNewsImageRel(imageId, MainProvider.NewsImageRel.ImageId);
        }

    }
}