namespace HelthTourismV2.Models.Regular
{
    public class TblSection
    {
        public int id { get; set; }
        public string SectionName { get; set; }

        public TblSection(int id)
        {
            this.id = id;
        }

		public TblSection(int id, string sectionName)
        {
            this.id = id;
            SectionName = sectionName;
        }
        public TblSection(string sectionName)
        {
            SectionName = sectionName;
        }

        public TblSection()
        {
            
        }
    }
}