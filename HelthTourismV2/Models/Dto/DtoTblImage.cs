using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblImage
    {
        public int id { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblImage(TblImage image, HttpStatusCode statusEffect)
        {
            id = image.id;
            Image = image.Image;
            Status = image.Status;

            StatusEffect = statusEffect;
        }

        public DtoTblImage()
        {
        }
    }
}