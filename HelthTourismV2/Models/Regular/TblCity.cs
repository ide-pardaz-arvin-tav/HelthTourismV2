namespace HelthTourismV2.Models.Regular
{
    public class TblCity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public TblCity(int id)
        {
            this.id = id;
        }

		public TblCity(int id, string name, int countryId)
        {
            this.id = id;
            Name = name;
            CountryId = countryId;
        }
        public TblCity(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }

        public TblCity()
        {
            
        }
    }
}