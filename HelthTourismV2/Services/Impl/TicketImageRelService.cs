using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class TicketImageRelService : ITicketImageRelService
    {
        public TblTicketImageRel AddTicketImageRel(TblTicketImageRel ticketImageRel)
        {
            return new TicketImageRelRepo().AddTicketImageRel(ticketImageRel);
        }
        public bool DeleteTicketImageRel(int id)
        {
            return new TicketImageRelRepo().DeleteTicketImageRel(id);
        }
        public bool UpdateTicketImageRel(TblTicketImageRel ticketImageRel, int logId)
        {
            return new TicketImageRelRepo().UpdateTicketImageRel(ticketImageRel, logId);
        }
        public List<TblTicketImageRel> SelectAllTicketImageRels()
        {
            return new TicketImageRelRepo().SelectAllTicketImageRels();
        }
        public TblTicketImageRel SelectTicketImageRelById(int id)
        {
            return (TblTicketImageRel)new TicketImageRelRepo().SelectTicketImageRelById(id);
        }
        public List<TblTicketImageRel> SelectTicketImageRelByTicketId(int ticketId)
        {
            return new TicketImageRelRepo().SelectTicketImageRelByTicketId(ticketId);
        }
        public List<TblTicketImageRel> SelectTicketImageRelByImageId(int imageId)
        {
            return new TicketImageRelRepo().SelectTicketImageRelByImageId(imageId);
        }

    }
}