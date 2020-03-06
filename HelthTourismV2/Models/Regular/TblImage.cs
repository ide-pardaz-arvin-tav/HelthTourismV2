namespace HelthTourismV2.Models.Regular
{
    public class TblImage
    {
        public int id { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }

        public TblImage(int id)
        {
            this.id = id;
        }

		public TblImage(int id, string image, int status)
        {
            this.id = id;
            Image = image;
            Status = status;
        }
        public TblImage(string image, int status)
        {
            Image = image;
            Status = status;
        }

        public TblImage()
        {
            
        }
    }
}