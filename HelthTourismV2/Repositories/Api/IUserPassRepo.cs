using System.Collections.Generic;
using HelthTourismV2.Models.Regular;

namespace HelthTourismV2.Repositories.Api
{
    public interface IUserPassRepo
    {
        TblUserPass AddUserPass(TblUserPass userPass);
        bool DeleteUserPass(int id);
        bool UpdateUserPass(TblUserPass userPass, int logId);
        List<TblUserPass> SelectAllUserPasss();
        TblUserPass SelectUserPassById(int id);
        TblUserPass SelectUserPassByUsernameAndPassword(string username ,string password);
        TblUserPass SelectUserPassByUsername(string username);
        TblUserPass SelectUserPassByPassword(string password);
        List<TblUserPass> SelectUserPassByIsHelthApple(bool isHelthApple);

    }
}