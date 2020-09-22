using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using NVPapi.Models;
using Dapper;

namespace NVPapi.Repositories
{
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private readonly IQueryCommandText _commandText;

        public ScheduleRepository(IConfiguration configuration, IQueryCommandText commandText) : base(configuration)
        {
            _commandText = commandText;
        }
        public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {

            return await WithConnection(async conn =>
            {
                // no input needed
                var query = await conn.QueryAsync<Schedule>(_commandText.GetAllSchedulesQuery);
                return query;
            });

        }

        public async ValueTask<Schedule> GetScheduleByID(int id)
        {
            // test the following return for db access issues later (jjm)
            return await WithConnection(async conn =>
            {
                // Document_ID
                var query = await conn.QueryFirstOrDefaultAsync<Schedule>(_commandText.GetScheduleByIDQuery, new { Document_ID = id });
                return query;
            });

        }

        public async ValueTask<int> InsertSchedule(Schedule entity)
        {
            var result = 0;
            await WithConnection(async conn =>
            {
                // From_IP, Location_ID, PDF_Path, Document_Text
                result = await conn.ExecuteAsync(_commandText.InsertScheduleQuery,
                    new
                    {
                        From_IP = entity.From_IP,
                        Location_ID = entity.Location_ID,
                        PDF_Path = entity.PDF_Path,
                        Document_Text = entity.Document_Text
                    });

            });
            return result;

        }
        public async ValueTask<int> UpdateSchedule(Schedule entity, int id)
        {
            var result = 0;
            await WithConnection(async conn =>
            {
                // Processed_Flag, From_IP, Location_ID, PDF_Path, Document_Text
                result = await conn.ExecuteAsync(_commandText.UpdateScheduleQuery,
                    new
                    {
                        Document_ID = id,
                        Processed_Flag = entity.Processed_Flag,
                        From_IP = entity.From_IP,
                        Location_ID = entity.Location_ID,
                        PDF_Path = entity.PDF_Path,
                        Document_Text = entity.Document_Text
                    });
            });
            return result;
        }

        public async ValueTask<int> DeleteSchedule(int id)
        {
            var result = 0;
            await WithConnection(async conn =>
            {
                // Document_ID
                result = await conn.ExecuteAsync(_commandText.DeleteScheduleQuery, new { Document_ID = id });
            });
            return result;
        }


    }
}
