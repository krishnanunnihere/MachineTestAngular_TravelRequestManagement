using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequestManagementAPI.Models;

namespace TravelRequestManagementAPI.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        TravelRequestManagementDBContext db;

        public RegistrationRepository(TravelRequestManagementDBContext _db)
        {
            db = _db;
        }

        #region getEmployees()
        public async Task<List<TblEmployeeRegistration>> GetEmployees()
        {
            if (db != null)
            {
                return await db.TblEmployeeRegistration.ToListAsync();
            }
            return null;
        }
        #endregion
        #region AddEmployee()
        public async Task<int> AddEmployee(TblEmployeeRegistration employee)
        {
            if (db != null)
            {
                await db.TblEmployeeRegistration.AddAsync(employee);
                await db.SaveChangesAsync();
                return employee.EmpId;
            }
            return 0;
        }
        #endregion
        #region UpdateEmployee()
        public async Task UpdateEmployee(TblEmployeeRegistration employee)
        {
            if (db != null)
            {
                db.TblEmployeeRegistration.Update(employee);
                await db.SaveChangesAsync();
            }
        }
        #endregion

    }
}
