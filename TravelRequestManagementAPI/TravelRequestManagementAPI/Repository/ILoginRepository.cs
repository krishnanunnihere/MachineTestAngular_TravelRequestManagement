using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequestManagementAPI.Models;

namespace TravelRequestManagementAPI.Repository
{
    public interface ILoginRepository
    {
        public TblUser GetToken(TblUser user);
        Task<ActionResult<TblUser>> GetUserByPassword(string un, string pwd);
        public TblUser validateUser(string uname, string password);
        Task<int> AddLogin(TblUser user);
    }
}
