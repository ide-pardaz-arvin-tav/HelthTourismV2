namespace HelthTourismV2.Models.Regular
{
    public class TblNewsImageRel
    {
        public int id { get; set; }
        public int NewsId { get; set; }
        public int ImageId { get; set; }

        public TblNewsImageRel(int id)
        {
            this.id = id;
        }

		public TblNewsImageRel(int id, int newsId, int imageId)
        {
            this.id = id;
            NewsId = newsId;
            ImageId = imageId;
        }
        public TblNewsImageRel(int newsId, int imageId)
        {
            NewsId = newsId;
            ImageId = imageId;
        }

        public TblNewsImageRel()
        {
            
        }
    }
}