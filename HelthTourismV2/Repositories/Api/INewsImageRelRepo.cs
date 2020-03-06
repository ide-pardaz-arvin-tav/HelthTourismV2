using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface INewsImageRelRepo
    {
        TblNewsImageRel AddNewsImageRel(TblNewsImageRel newsImageRel);
        bool DeleteNewsImageRel(int id);
        bool UpdateNewsImageRel(TblNewsImageRel newsImageRel, int logId);
        List<TblNewsImageRel> SelectAllNewsImageRels();
        TblNewsImageRel SelectNewsImageRelById(int id);
        List<TblNewsImageRel> SelectNewsImageRelByNewsId(int newsId);
        List<TblNewsImageRel> SelectNewsImageRelByImageId(int imageId);

    }
}