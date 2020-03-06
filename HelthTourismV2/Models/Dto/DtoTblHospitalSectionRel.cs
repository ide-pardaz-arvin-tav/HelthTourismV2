using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblHospitalSectionRel
    {
        public int id { get; set; }
        public int HospitalId { get; set; }
        public int SectionId { get; set; }
        public int DoctorId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblHospitalSectionRel(TblHospitalSectionRel hospitalSectionRel, HttpStatusCode statusEffect)
        {
            id = hospitalSectionRel.id;
            HospitalId = hospitalSectionRel.HospitalId;
            SectionId = hospitalSectionRel.SectionId;
            DoctorId = hospitalSectionRel.DoctorId;

            StatusEffect = statusEffect;
        }

        public DtoTblHospitalSectionRel()
        {
        }
    }
}