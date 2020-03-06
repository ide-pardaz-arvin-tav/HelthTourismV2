namespace HelthTourismV2.Models.Regular
{
    public class TblConfig
    {
        public int id { get; set; }
        public string JwtKey { get; set; }

        public TblConfig(int id)
        {
            this.id = id;
        }

		public TblConfig(int id, string jwtKey)
        {
            this.id = id;
            JwtKey = jwtKey;
        }
        public TblConfig(string jwtKey)
        {
            JwtKey = jwtKey;
        }

        public TblConfig()
        {
            
        }
    }
}