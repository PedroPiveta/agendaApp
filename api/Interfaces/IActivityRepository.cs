using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Activity;
using api.Models;

namespace api.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllAsync(AppUser user);
        Task<Activity> GetByIdAsync(int id);
        Task<Activity> CreateAsync(CreateActivityDto activity, string userId);
        Task<Activity?> UpdateAsync(UpdateActivityDto activity);
        Task<Activity?> DeleteAsync(int id);
    }
}