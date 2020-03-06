using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblOperation
    {
        public int id { get; set; }
        public string OperationName { get; set; }
        public long OperationPrice { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblOperation(TblOperation operation, HttpStatusCode statusEffect)
        {
            id = operation.id;
            OperationName = operation.OperationName;
            OperationPrice = operation.OperationPrice;

            StatusEffect = statusEffect;
        }

        public DtoTblOperation()
        {
        }
    }
}