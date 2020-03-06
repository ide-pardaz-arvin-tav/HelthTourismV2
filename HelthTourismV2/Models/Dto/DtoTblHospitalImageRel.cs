using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblHospitalImageRel
    {
        public int id { get; set; }
        public int HospitalId { get; set; }
        public int ImageId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblHospitalImageRel(TblHospitalImageRel hospitalImageRel, HttpStatusCode statusEffect)
        {
            id = hospitalImageRel.id;
            HospitalId = hospitalImageRel.HospitalId;
            ImageId = hospitalImageRel.ImageId;

            StatusEffect = statusEffect;
        }

        public DtoTblHospitalImageRel()
        {
        }
    }
}