using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequestManagementAPI.Models;

namespace TravelRequestManagementAPI.Repository
{
    public class ProjectRepository:IProjectRepository
    {
        TravelRequestManagementDBContext db;

        public ProjectRepository(TravelRequestManagementDBContext _db)
        {
            db = _db;
        }
        #region getProjects()
        public async Task<List<TblProject>> GetProjects()
        {
            if (db != null)
            {
                return await db.TblProject.ToListAsync();
            }
            return null;
        }
        #endregion
        #region AddProject()
        public async Task<int> AddProject(TblProject project)
        {
            if (db != null)
            {
                await db.TblProject.AddAsync(project);
                await db.SaveChangesAsync();
                return project.ProjectId;
            }
            return 0;
        }
        #endregion
    }
}
