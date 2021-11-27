using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequestManagementAPI.Models;

namespace TravelRequestManagementAPI.Repository
{
    public class LoginRepository:ILoginRepository
    {
        TravelRequestManagementDBContext db;
        public LoginRepository(TravelRequestManagementDBContext _db)
        {
            db = _db;
        }
        #region GetToken()
        public TblUser GetToken(TblUser login)
        {
            if (db != null)
            {
                TblUser dbUser = db.TblUser.FirstOrDefault(em => em.UserName == login.UserName && em.UserPassword == login.UserPassword);
                if (dbUser != null)
                {
                    return dbUser;
                }
            }
            return null;
        }
        #endregion
        #region GetUserByPassword()
        public async Task<ActionResult<TblUser>> GetUserByPassword(string un, string pwd)
        {
            if (db != null)
            {
                TblUser tbluser = await db.TblUser.FirstOrDefaultAsync(em => em.UserName == un && em.UserPassword == pwd);
                return tbluser;
            }
            return null;
        }
        #endregion

        #region ValidateUser()
        public TblUser validateUser(string username, string password)
        {
            Console.WriteLine(username, password);
            if (db != null)
            {
                TblUser dbuser = db.TblUser.FirstOrDefault(em => em.UserName == username && em.UserPassword == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;

        }
        #endregion

        #region AddLogin()
        public async Task<int> AddLogin(TblUser user)
        {
            if (db != null)
            {
                await db.TblUser.AddAsync(user);
                await db.SaveChangesAsync();
                return user.UserId;
            }
            return 0;
        }
        #endregion


    }
}
