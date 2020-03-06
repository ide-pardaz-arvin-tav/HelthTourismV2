using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface ITicketRepo
    {
        TblTicket AddTicket(TblTicket ticket);
        bool DeleteTicket(int id);
        bool UpdateTicket(TblTicket ticket, int logId);
        List<TblTicket> SelectAllTickets();
        TblTicket SelectTicketById(int id);
        List<TblTicket> SelectTicketByIsRegistered(bool isRegistered);
        List<TblTicket> SelectTicketByUserPassId(int userPassId);
        TblTicket SelectTicketByEmail(string email);
        TblTicket SelectTicketByTellNo(string tellNo);

    }
}