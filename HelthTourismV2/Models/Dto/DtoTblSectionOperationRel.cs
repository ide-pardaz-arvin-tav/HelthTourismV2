using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblSectionOperationRel
    {
        public int id { get; set; }
        public int SectionId { get; set; }
        public int OperationId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblSectionOperationRel(TblSectionOperationRel sectionOperationRel, HttpStatusCode statusEffect)
        {
            id = sectionOperationRel.id;
            SectionId = sectionOperationRel.SectionId;
            OperationId = sectionOperationRel.OperationId;

            StatusEffect = statusEffect;
        }

        public DtoTblSectionOperationRel()
        {
        }
    }
}