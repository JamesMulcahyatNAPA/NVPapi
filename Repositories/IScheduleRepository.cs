using System.Collections.Generic;
using System.Threading.Tasks;
using NVPapi.Models;

namespace NVPapi.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetAllSchedules();
        ValueTask<Schedule> GetScheduleByID(int id);
        ValueTask<int> InsertSchedule(Schedule entity);
        ValueTask<int> UpdateSchedule(Schedule entity, int id);
        ValueTask<int> DeleteSchedule(int id);
    }
}
