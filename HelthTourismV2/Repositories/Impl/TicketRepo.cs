using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class TicketRepo : ITicketRepo
    {
        public TblTicket AddTicket(TblTicket ticket)
        {
            return (TblTicket) new MainProvider().Add(ticket);
        }
        public bool DeleteTicket(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblTicket, id);
        }
        public bool UpdateTicket(TblTicket ticket, int logId)
        {
            return new MainProvider().Update(ticket, logId);
        }
        public List<TblTicket> SelectAllTickets()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblTicket).Cast<TblTicket>().ToList();
        }
        public TblTicket SelectTicketById(int id)
        {
            return (TblTicket)new MainProvider().SelectById(MainProvider.Tables.TblTicket, id);
        }
        public List<TblTicket> SelectTicketByIsRegistered(bool isRegistered)
        {
            return new MainProvider().SelectTicketByIsRegistered(isRegistered);
        }
        public List<TblTicket> SelectTicketByUserPassId(int userPassId)
        {
            return new MainProvider().SelectTicketByUserPassId(userPassId);
        }
        public TblTicket SelectTicketByEmail(string email)
        {
            return new MainProvider().SelectTicketByEmail(email);
        }
        public TblTicket SelectTicketByTellNo(string tellNo)
        {
            return new MainProvider().SelectTicketByTellNo(tellNo);
        }

    }
}