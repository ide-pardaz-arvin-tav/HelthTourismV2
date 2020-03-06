using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblSickness
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int SectionId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblSickness(TblSickness sickness, HttpStatusCode statusEffect)
        {
            id = sickness.id;
            Name = sickness.Name;
            SectionId = sickness.SectionId;

            StatusEffect = statusEffect;
        }

        public DtoTblSickness()
        {
        }
    }
}