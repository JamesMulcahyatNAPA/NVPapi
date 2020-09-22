using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NVPapi.Repositories;
using NVPapi.Models;

namespace NVPapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        // prepare for database queries
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        // retrieve all schedule documents
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult<Schedule>> GetAllSchedules()
        {
            var schedules = (await _scheduleRepository.GetAllSchedules());

            if (schedules.Count().Equals(0))
            {
                return NotFound("No records found.");
            }

            return Ok(schedules);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult<Schedule>> GetScheduleByID(int id)
        {
            var schedule = (await _scheduleRepository.GetScheduleByID(id));

            if (schedule == null)
            {
                return NotFound("No records found.");
            }

            return Ok(schedule);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> InsertSchedule(Schedule schedule)
        {
            var result = await _scheduleRepository.InsertSchedule(schedule);
            if (result < 1)
            {
                return Conflict("Unable to insert this record."); // duplicate record? HTTP 409
            }

            return Ok("Record inserted."); // success creation HTTP 201
        }

        // PUT api/<ScheduleController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult<Schedule>> UpdateSchedule(Schedule schedule, int id)
        {
            var result = await _scheduleRepository.UpdateSchedule(schedule, id);
            if (result < 1)
            {
                return Conflict("Unable to update this record."); // HTTP 409              
            }
            return Ok("Record updated.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _scheduleRepository.DeleteSchedule(id);
            if (result < 1)
            {
                return Conflict("Unable to delete this record."); // duplicate record HTTP 409              
            }
            return Ok("Record deleted.");

        }
    }
}

