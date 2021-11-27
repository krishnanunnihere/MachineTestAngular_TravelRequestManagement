using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequestManagementAPI.Models;
using TravelRequestManagementAPI.Repository;

namespace TravelRequestManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelRequestController : ControllerBase
    {
        IRequestRepository RequestRepository;
        public TravelRequestController(IRequestRepository _p)
        {
            RequestRepository = _p;
        }


        #region GetTravelRequests()
        [HttpGet]

        [Route("GetTravelRequests")]
        public async Task<IActionResult> GetTravelRequests()
        {
            try
            {
                var requests = await RequestRepository.GetTravelRequests();
                if (requests == null)
                {
                    return NotFound();
                }
                return Ok(requests);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region AddTravelRequest()
        [HttpPost]
        [Route("AddTravelRequest")]
        public async Task<IActionResult> AddTravelRequest([FromBody] TblRequestTable model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var RequestId = await RequestRepository.AddTravelRequest(model);
                    if (RequestId > 0)
                    {
                        return Ok(RequestId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }
        #endregion

        #region UpdateTravelRequest()
        [HttpPut]
        [Route("UpdateTravelRequest")]
        public async Task<IActionResult> UpdateTravelRequest([FromBody] TblRequestTable model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await RequestRepository.UpdateTravelRequest(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        #endregion
        #region DeleteTravelRequest
        [HttpDelete]
        [Route("DeleteTravelRequest")]
        public async Task<IActionResult> DeleteTravelRequest(int id)
        {
            try
            {
                var exp = await RequestRepository.DeleteTravelRequest(id);
                if (exp == null)
                {
                    return NotFound();
                }
                return Ok(exp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
