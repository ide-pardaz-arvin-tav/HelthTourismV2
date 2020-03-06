namespace HelthTourismV2.Models.Regular
{
    public class TblNews
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string MainData { get; set; }
        public string MainDataRtf { get; set; }

        public TblNews(int id)
        {
            this.id = id;
        }

		public TblNews(int id, string title, string mainData, string mainDataRtf)
        {
            this.id = id;
            Title = title;
            MainData = mainData;
            MainDataRtf = mainDataRtf;
        }
        public TblNews(string title, string mainData, string mainDataRtf)
        {
            Title = title;
            MainData = mainData;
            MainDataRtf = mainDataRtf;
        }

        public TblNews()
        {
            
        }
    }
}