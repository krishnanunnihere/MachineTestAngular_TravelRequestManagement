using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequestManagementAPI.Models;

namespace TravelRequestManagementAPI.Repository
{
    public class RequestRepository:IRequestRepository
    {
        TravelRequestManagementDBContext db;
        public RequestRepository(TravelRequestManagementDBContext _db)
        {
            db = _db;
        }
        #region getTravelRequests()
        public async Task<List<TblRequestTable>> GetTravelRequests()
        {
            if (db != null)
            {
                return await db.TblRequestTable.ToListAsync();
            }
            return null;
        }
        #endregion
        #region AddTravelRequest()
        public async Task<int> AddTravelRequest(TblRequestTable request)
        {
            if (db != null)
            {
                await db.TblRequestTable.AddAsync(request);
                await db.SaveChangesAsync();
                return request.RequestId;
            }
            return 0;
        }
        #endregion
        #region UpdateTravelRequest()
        public async Task UpdateTravelRequest(TblRequestTable request)
        {
            if (db != null)
            {
                db.TblRequestTable.Update(request);
                await db.SaveChangesAsync();
            }
        }
        #endregion
        #region DeleteEmployee

        public async Task<TblRequestTable> DeleteTravelRequest(int id)
        {
            if (db != null)
            {
                TblRequestTable dbemp = db.TblRequestTable.Find(id);
                db.TblRequestTable.Remove(dbemp);
                await db.SaveChangesAsync();
                return (dbemp);
            }
            return null;
        }
        #endregion
    }
}
