namespace HelthTourismV2.Models.Regular
{
    public class TblSickness
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int SectionId { get; set; }

        public TblSickness(int id)
        {
            this.id = id;
        }

		public TblSickness(int id, string name, int sectionId)
        {
            this.id = id;
            Name = name;
            SectionId = sectionId;
        }
        public TblSickness(string name, int sectionId)
        {
            Name = name;
            SectionId = sectionId;
        }

        public TblSickness()
        {
            
        }
    }
}