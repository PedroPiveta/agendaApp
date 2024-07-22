using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Activity;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace api.Controllers
{

    [ApiController]
    [Route("api/activity")]
    public class ActivityController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;
        public ActivityController(UserManager<AppUser> userManager,
        IActivityRepository activityRepository, IMapper mapper)
        {
            _userManager = userManager;
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserActivities()
        {
            var UserName = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(UserName);

            if (appUser == null)
            {
                return Unauthorized();
            }
            var activities = await _activityRepository.GetAllAsync(appUser);

            if (activities == null)
            {
                return NotFound();
            }

            var activitiesDto = _mapper.Map<List<GetActivityDto>>(activities);
            
            return Ok(activitiesDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityDto activityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UserName = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(UserName);
            Console.WriteLine(appUser?.Id);
            if (string.IsNullOrEmpty(appUser?.Id))
            {
                return Unauthorized("User ID not found.");
            }
            if (appUser == null)
            {
                return Unauthorized();
            }

            var createdActivity = await _activityRepository.CreateAsync(activityDto, appUser.Id);

            var createdActivityDto = _mapper.Map<GetActivityDto>(createdActivity);

            return CreatedAtAction(nameof(GetUserActivities), new { id = createdActivityDto.Id }, createdActivityDto);
        }
    }
}