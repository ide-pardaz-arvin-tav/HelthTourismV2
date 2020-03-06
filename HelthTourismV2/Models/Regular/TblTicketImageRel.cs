namespace HelthTourismV2.Models.Regular
{
    public class TblTicketImageRel
    {
        public int id { get; set; }
        public int TicketId { get; set; }
        public int ImageId { get; set; }

        public TblTicketImageRel(int id)
        {
            this.id = id;
        }

		public TblTicketImageRel(int id, int ticketId, int imageId)
        {
            this.id = id;
            TicketId = ticketId;
            ImageId = imageId;
        }
        public TblTicketImageRel(int ticketId, int imageId)
        {
            TicketId = ticketId;
            ImageId = imageId;
        }

        public TblTicketImageRel()
        {
            
        }
    }
}