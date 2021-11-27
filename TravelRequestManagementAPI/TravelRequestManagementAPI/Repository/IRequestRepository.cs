using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequestManagementAPI.Models;

namespace TravelRequestManagementAPI.Repository
{
    public interface IRequestRepository
    {
        Task<List<TblRequestTable>> GetTravelRequests();
        Task<int> AddTravelRequest(TblRequestTable request);
        Task UpdateTravelRequest(TblRequestTable request);
        Task<TblRequestTable> DeleteTravelRequest(int id);
    }
}
