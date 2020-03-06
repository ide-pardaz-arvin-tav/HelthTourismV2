using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class NewsImageRelService : INewsImageRelService
    {
        public TblNewsImageRel AddNewsImageRel(TblNewsImageRel newsImageRel)
        {
            return new NewsImageRelRepo().AddNewsImageRel(newsImageRel);
        }
        public bool DeleteNewsImageRel(int id)
        {
            return new NewsImageRelRepo().DeleteNewsImageRel(id);
        }
        public bool UpdateNewsImageRel(TblNewsImageRel newsImageRel, int logId)
        {
            return new NewsImageRelRepo().UpdateNewsImageRel(newsImageRel, logId);
        }
        public List<TblNewsImageRel> SelectAllNewsImageRels()
        {
            return new NewsImageRelRepo().SelectAllNewsImageRels();
        }
        public TblNewsImageRel SelectNewsImageRelById(int id)
        {
            return (TblNewsImageRel)new NewsImageRelRepo().SelectNewsImageRelById(id);
        }
        public List<TblNewsImageRel> SelectNewsImageRelByNewsId(int newsId)
        {
            return new NewsImageRelRepo().SelectNewsImageRelByNewsId(newsId);
        }
        public List<TblNewsImageRel> SelectNewsImageRelByImageId(int imageId)
        {
            return new NewsImageRelRepo().SelectNewsImageRelByImageId(imageId);
        }

    }
}