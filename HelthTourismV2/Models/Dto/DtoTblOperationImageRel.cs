using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblOperationImageRel
    {
        public int id { get; set; }
        public int OperationId { get; set; }
        public int ImageId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblOperationImageRel(TblOperationImageRel operationImageRel, HttpStatusCode statusEffect)
        {
            id = operationImageRel.id;
            OperationId = operationImageRel.OperationId;
            ImageId = operationImageRel.ImageId;

            StatusEffect = statusEffect;
        }

        public DtoTblOperationImageRel()
        {
        }
    }
}