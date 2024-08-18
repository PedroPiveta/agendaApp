using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Activity;
using api.Enums;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _context;
        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> CreateAsync(CreateActivityDto activityDto, string id)
        {
            var activity = new Activity
            {
                Title = activityDto.Title,
                Description = activityDto.Description,
                ActivityDatetime = activityDto.ActivityDatetime,
                IsRecurrent = activityDto.IsRecurrent,
                UserId = id,
                DiasSemana = activityDto.DiasSemana.Select(day => Enum.Parse<DiasSemana>(day)).ToList()
            };

            var createdActivity = await _context.Activities.AddAsync(activity);

            await _context.SaveChangesAsync();

            return createdActivity.Entity;
        }


        public async Task<Activity?> DeleteAsync(int id)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);

            if (activity == null)
            {
                return null;
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();

            return activity;
        }


        public async Task<List<Activity>> GetAllAsync(AppUser user)
        {
            return await _context.Activities.Where(u => u.UserId == user.Id)
                   .Select(a => new Activity
                   {
                       Id = a.Id,
                       Title = a.Title,
                       Description = a.Description,
                       ActivityDatetime = a.ActivityDatetime,
                       IsRecurrent = a.IsRecurrent,
                       UserId = a.UserId,
                       DiasSemana = a.DiasSemana
                   }).ToListAsync();
        }

        public Task<Activity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Activity?> UpdateAsync(UpdateActivityDto activity)
        {
            var oldActivity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == activity.Id);

            if (oldActivity == null)
            {
                return null;
            }

            oldActivity.Title = activity.Title;
            oldActivity.Description = activity.Description;
            oldActivity.ActivityDatetime = activity.ActivityDatetime;
            oldActivity.IsRecurrent = activity.IsRecurrent;
            oldActivity.DiasSemana = activity.DiasSemana.Select(day => Enum.Parse<DiasSemana>(day)).ToList();

            await _context.SaveChangesAsync();

            return oldActivity;
        }
    }
}