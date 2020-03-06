using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class TicketImageRelRepo : ITicketImageRelRepo
    {
        public TblTicketImageRel AddTicketImageRel(TblTicketImageRel ticketImageRel)
        {
            return (TblTicketImageRel) new MainProvider().Add(ticketImageRel);
        }
        public bool DeleteTicketImageRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblTicketImageRel, id);
        }
        public bool UpdateTicketImageRel(TblTicketImageRel ticketImageRel, int logId)
        {
            return new MainProvider().Update(ticketImageRel, logId);
        }
        public List<TblTicketImageRel> SelectAllTicketImageRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblTicketImageRel).Cast<TblTicketImageRel>().ToList();
        }
        public TblTicketImageRel SelectTicketImageRelById(int id)
        {
            return (TblTicketImageRel)new MainProvider().SelectById(MainProvider.Tables.TblTicketImageRel, id);
        }
        public List<TblTicketImageRel> SelectTicketImageRelByTicketId(int ticketId)
        {
            return new MainProvider().SelectTicketImageRel(ticketId, MainProvider.TicketImageRel.TicketId);
        }
        public List<TblTicketImageRel> SelectTicketImageRelByImageId(int imageId)
        {
            return new MainProvider().SelectTicketImageRel(imageId, MainProvider.TicketImageRel.ImageId);
        }

    }
}