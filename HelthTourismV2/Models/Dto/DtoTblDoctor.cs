using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblDoctor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int SectionId { get; set; }
        public bool NowActive { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblDoctor(TblDoctor doctor, HttpStatusCode statusEffect)
        {
            id = doctor.id;
            Name = doctor.Name;
            SectionId = doctor.SectionId;
            NowActive = doctor.NowActive;

            StatusEffect = statusEffect;
        }

        public DtoTblDoctor()
        {
        }
    }
}