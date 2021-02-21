using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmpireEye;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RebelsController : ControllerBase
    {

        private readonly ILogger<RebelsController> _logger;
        private readonly IRebelService _rebelService;

        public RebelsController(ILogger<RebelsController> logger, IRebelService rebelService)
        {
            _logger = logger;
            _rebelService = rebelService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("All the rebels");
                return Ok(_rebelService.GetRebels());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed getting the rebels from our system {ex}");
            }
            return BadRequest("Failed getting the rebels");
        }

        [HttpGet("{rebel}")]
        public IActionResult GetSingle(string rebel)
        {
            try
            {
                _logger.LogInformation($"Get this rebel {rebel}");
                var rebelSearched = _rebelService.GetRebel(rebel);
                if (rebelSearched != null)
                {
                    return Ok(rebelSearched);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed getting the rebel from our system {ex}");
            }
            return BadRequest("Failed getting the rebel");
        }

        [HttpPost]
        public IActionResult AddRebel([FromBody] RebelParams rebel)
        {
            try
            {
                if(rebel!=null)
                {
                    _rebelService.AddRebel(rebel);
                    _logger.LogInformation("Rebel Added to the system");
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to add the new rebel: {ex}");
            }
            return BadRequest("Failed to add the new rebel");
        }


        [HttpPut]
        public IActionResult Update([FromBody] RebelParams rebel)
        {
            try
            {
                if (rebel != null)
                {
                    _rebelService.UpdateRebel(rebel);
                    _logger.LogInformation("Rebel Updated in the system");
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to update the rebel: {ex}");
            }
            return BadRequest("Failed to update the rebel");
        }
    }
}
