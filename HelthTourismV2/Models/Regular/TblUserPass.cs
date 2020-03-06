namespace HelthTourismV2.Models.Regular
{
    public class TblUserPass
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsHelthApple { get; set; }

        public TblUserPass(int id)
        {
            this.id = id;
        }

		public TblUserPass(int id, string username, string password, bool isHelthApple)
        {
            this.id = id;
            Username = username;
            Password = password;
            IsHelthApple = isHelthApple;
        }
        public TblUserPass(string username, string password, bool isHelthApple)
        {
            Username = username;
            Password = password;
            IsHelthApple = isHelthApple;
        }

        public TblUserPass()
        {
            
        }
    }
}