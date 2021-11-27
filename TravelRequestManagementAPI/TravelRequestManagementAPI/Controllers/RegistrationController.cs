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
    public class RegistrationController : ControllerBase
    {
        IRegistrationRepository RegistrationRepository;
        public RegistrationController(IRegistrationRepository _p)
        {
            RegistrationRepository = _p;
        }
        #region GetEmployees()
        [HttpGet]

        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await RegistrationRepository.GetEmployees();
                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region AddEmployee()
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] TblEmployeeRegistration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var EmployeeId = await RegistrationRepository.AddEmployee(model);
                    if (EmployeeId > 0)
                    {
                        
                        return Ok(EmployeeId);
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
        #region UpdateEmployee()
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] TblEmployeeRegistration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await RegistrationRepository.UpdateEmployee(model);
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

    }
}
