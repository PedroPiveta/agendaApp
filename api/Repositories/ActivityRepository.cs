using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Activity;
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

        public Task<Activity> CreateAsync(CreateActivityDto activity)
        {
            throw new NotImplementedException();
        }

        public Task<Activity?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<Activity?> UpdateAsync(UpdateActivityDto activity)
        {
            throw new NotImplementedException();
        }
    }
}