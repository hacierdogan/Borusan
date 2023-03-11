using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        protected IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var statusList = await _statusService.TGetAll();

            if (statusList.Count > 0)
            {
                var resultList = from status in statusList
                             select new
                             {
                                 Id = status.Id,
                                 Status = status.StatusStr
                             };
                return Ok(resultList.ToList());
            }
            return NoContent();
        }
    }
}
