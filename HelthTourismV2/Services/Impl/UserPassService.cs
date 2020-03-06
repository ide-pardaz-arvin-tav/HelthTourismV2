using System.Collections.Generic;
using HelthTourismV2.Models.Regular;
using HelthTourismV2.Repositories.Impl;
using HelthTourismV2.Services.Api;

namespace HelthTourismV2.Services.Impl
{
    public class UserPassService : IUserPassService
    {
        public TblUserPass AddUserPass(TblUserPass userPass)
        {
            return new UserPassRepo().AddUserPass(userPass);
        }
        public bool DeleteUserPass(int id)
        {
            return new UserPassRepo().DeleteUserPass(id);
        }
        public bool UpdateUserPass(TblUserPass userPass, int logId)
        {
            return new UserPassRepo().UpdateUserPass(userPass, logId);
        }
        public List<TblUserPass> SelectAllUserPasss()
        {
            return new UserPassRepo().SelectAllUserPasss();
        }
        public TblUserPass SelectUserPassById(int id)
        {
            return (TblUserPass)new UserPassRepo().SelectUserPassById(id);
        }
        public TblUserPass SelectUserPassByUsernameAndPassword(string username ,string password)
        {
            return new UserPassRepo().SelectUserPassByUsernameAndPassword(username, password);
        }
        public TblUserPass SelectUserPassByUsername(string username)
        {
            return new UserPassRepo().SelectUserPassByUsername(username);
        }
        public TblUserPass SelectUserPassByPassword(string password)
        {
            return new UserPassRepo().SelectUserPassByPassword(password);
        }
        public List<TblUserPass> SelectUserPassByIsHelthApple(bool isHelthApple)
        {
            return new UserPassRepo().SelectUserPassByIsHelthApple(isHelthApple);
        }

    }
}