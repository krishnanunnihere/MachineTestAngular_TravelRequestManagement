using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequestManagementAPI.Models;

namespace TravelRequestManagementAPI.Repository
{
   public  interface IProjectRepository
    {
        Task<List<TblProject>> GetProjects();
        Task<int> AddProject(TblProject project);
    }
}
