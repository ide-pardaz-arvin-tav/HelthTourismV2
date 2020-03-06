using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblPatientImageRel
    {
        public int id { get; set; }
        public int PatientId { get; set; }
        public int ImageId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblPatientImageRel(TblPatientImageRel patientImageRel, HttpStatusCode statusEffect)
        {
            id = patientImageRel.id;
            PatientId = patientImageRel.PatientId;
            ImageId = patientImageRel.ImageId;

            StatusEffect = statusEffect;
        }

        public DtoTblPatientImageRel()
        {
        }
    }
}