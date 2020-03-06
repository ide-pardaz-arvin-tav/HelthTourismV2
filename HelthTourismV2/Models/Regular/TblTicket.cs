namespace HelthTourismV2.Models.Regular
{
    public class TblTicket
    {
        public int id { get; set; }
        public bool IsRegistered { get; set; }
        public int UserPassId { get; set; }
        public string Email { get; set; }
        public string TellNo { get; set; }
        public string Data { get; set; }

        public TblTicket(int id)
        {
            this.id = id;
        }

		public TblTicket(int id, bool isRegistered, int userPassId, string email, string tellNo, string data)
        {
            this.id = id;
            IsRegistered = isRegistered;
            UserPassId = userPassId;
            Email = email;
            TellNo = tellNo;
            Data = data;
        }
        public TblTicket(bool isRegistered, int userPassId, string email, string tellNo, string data)
        {
            IsRegistered = isRegistered;
            UserPassId = userPassId;
            Email = email;
            TellNo = tellNo;
            Data = data;
        }

        public TblTicket()
        {
            
        }
    }
}