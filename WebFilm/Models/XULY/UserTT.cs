using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFilm.Models.XULY
{
    public class UserTT
    {

        Phim2Entities db = null;

        public  UserTT()
        {
            db = new Phim2Entities();
        }
        public int InsertUser(User us)
        {
            db.Users.Add(us);
            db.SaveChanges();
            return us.UserID;
        }
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        //public bool CheckEmail(string email)
        //{
        //    return db.Users.Count(x => x.Email == email) > 0;
        //}
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(string username, string password, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == username);

            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                //    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                //    {
                        //if (result.Status == false)
                        //{
                        //    return -1;
                        //}
                        //else
                        //{
                            if (result.UserPass == password)
                                return 1;
                            else
                                return -2;
                        //}
                   // }
                    //else
                    //{
                    //    return -3;
                    //}
                }
                else
                {
                    //if (result.Status == false)
                    //{
                    //    return -1;
                    //}
                    //else
                    //{
                        if (result.UserPass == password)
                            return 1;
                        else
                            return -2;
                    //}
                }
            }

        }
    }
}