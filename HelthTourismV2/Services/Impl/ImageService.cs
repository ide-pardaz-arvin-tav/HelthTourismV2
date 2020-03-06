using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class ImageService : IImageService
    {
        public TblImage AddImage(TblImage image)
        {
            return new ImageRepo().AddImage(image);
        }
        public bool DeleteImage(int id)
        {
            return new ImageRepo().DeleteImage(id);
        }
        public bool UpdateImage(TblImage image, int logId)
        {
            return new ImageRepo().UpdateImage(image, logId);
        }
        public List<TblImage> SelectAllImages()
        {
            return new ImageRepo().SelectAllImages();
        }
        public TblImage SelectImageById(int id)
        {
            return (TblImage)new ImageRepo().SelectImageById(id);
        }
        public TblImage SelectImageByImage(string image)
        {
            return new ImageRepo().SelectImageByImage(image);
        }

    }
}