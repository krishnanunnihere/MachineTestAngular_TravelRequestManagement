using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequestManagementAPI.Models;

namespace TravelRequestManagementAPI.Repository
{
    public interface IRegistrationRepository
    {
        Task<List<TblEmployeeRegistration>> GetEmployees();
        Task<int> AddEmployee(TblEmployeeRegistration employee);
        Task UpdateEmployee(TblEmployeeRegistration employee);

    }
}
