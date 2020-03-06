using System.Collections.Generic;
using System.Linq;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Api;
using HelthTourismV2.Utilities;

namespace HelthTourismV2.Repositories.Impl
{
    public class UserPassRepo : IUserPassRepo
    {
        public TblUserPass AddUserPass(TblUserPass userPass)
        {
            return (TblUserPass) new MainProvider().Add(userPass);
        }
        public bool DeleteUserPass(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblUserPass, id);
        }
        public bool UpdateUserPass(TblUserPass userPass, int logId)
        {
            return new MainProvider().Update(userPass, logId);
        }
        public List<TblUserPass> SelectAllUserPasss()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblUserPass).Cast<TblUserPass>().ToList();
        }
        public TblUserPass SelectUserPassById(int id)
        {
            return (TblUserPass)new MainProvider().SelectById(MainProvider.Tables.TblUserPass, id);
        }
        public TblUserPass SelectUserPassByUsernameAndPassword(string username ,string password)
        {
            return new MainProvider().SelectUserPassByUsernameAndPassword(username, password);
        }
        public TblUserPass SelectUserPassByUsername(string username)
        {
            return new MainProvider().SelectUserPassByUsername(username);
        }
        public TblUserPass SelectUserPassByPassword(string password)
        {
            return new MainProvider().SelectUserPassByPassword(password);
        }
        public List<TblUserPass> SelectUserPassByIsHelthApple(bool isHelthApple)
        {
            return new MainProvider().SelectUserPassByIsHelthApple(isHelthApple);
        }

    }
}