namespace HelthTourismV2.Models.Regular
{
    public class TblCountry
    {
        public int id { get; set; }
        public string Name { get; set; }

        public TblCountry(int id)
        {
            this.id = id;
        }

		public TblCountry(int id, string name)
        {
            this.id = id;
            Name = name;
        }
        public TblCountry(string name)
        {
            Name = name;
        }

        public TblCountry()
        {
            
        }
    }
}