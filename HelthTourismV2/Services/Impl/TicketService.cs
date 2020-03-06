using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class TicketService : ITicketService
    {
        public TblTicket AddTicket(TblTicket ticket)
        {
            return new TicketRepo().AddTicket(ticket);
        }
        public bool DeleteTicket(int id)
        {
            return new TicketRepo().DeleteTicket(id);
        }
        public bool UpdateTicket(TblTicket ticket, int logId)
        {
            return new TicketRepo().UpdateTicket(ticket, logId);
        }
        public List<TblTicket> SelectAllTickets()
        {
            return new TicketRepo().SelectAllTickets();
        }
        public TblTicket SelectTicketById(int id)
        {
            return (TblTicket)new TicketRepo().SelectTicketById(id);
        }
        public List<TblTicket> SelectTicketByIsRegistered(bool isRegistered)
        {
            return new TicketRepo().SelectTicketByIsRegistered(isRegistered);
        }
        public List<TblTicket> SelectTicketByUserPassId(int userPassId)
        {
            return new TicketRepo().SelectTicketByUserPassId(userPassId);
        }
        public TblTicket SelectTicketByEmail(string email)
        {
            return new TicketRepo().SelectTicketByEmail(email);
        }
        public TblTicket SelectTicketByTellNo(string tellNo)
        {
            return new TicketRepo().SelectTicketByTellNo(tellNo);
        }
        public List<TblImage>SelectImagesByTicketId(int ticketId)
        {
            List<TblTicketImageRel> stp1 = new TicketImageRelRepo().SelectTicketImageRelByTicketId(ticketId);
            List<TblImage> stp2 = new List<TblImage>();
            foreach (TblTicketImageRel rel in stp1)
                stp2.Add(new ImageRepo().SelectImageById(rel.ImageId));
            return stp2;
        }

    }
}