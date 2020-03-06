using System.Net;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Models.Dto
{
    public class DtoTblTicketImageRel
    {
        public int id { get; set; }
        public int TicketId { get; set; }
        public int ImageId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public DtoTblTicketImageRel(TblTicketImageRel ticketImageRel, HttpStatusCode statusEffect)
        {
            id = ticketImageRel.id;
            TicketId = ticketImageRel.TicketId;
            ImageId = ticketImageRel.ImageId;

            StatusEffect = statusEffect;
        }

        public DtoTblTicketImageRel()
        {
        }
    }
}