using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IImageRepo
    {
        TblImage AddImage(TblImage image);
        bool DeleteImage(int id);
        bool UpdateImage(TblImage image, int logId);
        List<TblImage> SelectAllImages();
        TblImage SelectImageById(int id);
        TblImage SelectImageByImage(string image);

    }
}