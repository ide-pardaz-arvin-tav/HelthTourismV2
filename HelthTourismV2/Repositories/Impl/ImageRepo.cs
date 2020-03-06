using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class ImageRepo : IImageRepo
    {
        public TblImage AddImage(TblImage image)
        {
            return (TblImage) new MainProvider().Add(image);
        }
        public bool DeleteImage(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblImage, id);
        }
        public bool UpdateImage(TblImage image, int logId)
        {
            return new MainProvider().Update(image, logId);
        }
        public List<TblImage> SelectAllImages()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblImage).Cast<TblImage>().ToList();
        }
        public TblImage SelectImageById(int id)
        {
            return (TblImage)new MainProvider().SelectById(MainProvider.Tables.TblImage, id);
        }
        public TblImage SelectImageByImage(string image)
        {
            return new MainProvider().SelectImageByImage(image);
        }

    }
}