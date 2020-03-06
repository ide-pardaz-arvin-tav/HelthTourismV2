using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface ITicketImageRelRepo
    {
        TblTicketImageRel AddTicketImageRel(TblTicketImageRel ticketImageRel);
        bool DeleteTicketImageRel(int id);
        bool UpdateTicketImageRel(TblTicketImageRel ticketImageRel, int logId);
        List<TblTicketImageRel> SelectAllTicketImageRels();
        TblTicketImageRel SelectTicketImageRelById(int id);
        List<TblTicketImageRel> SelectTicketImageRelByTicketId(int ticketId);
        List<TblTicketImageRel> SelectTicketImageRelByImageId(int imageId);

    }
}