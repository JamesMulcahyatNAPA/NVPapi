namespace NVPapi.Repositories
{
    public interface IQueryCommandText
    {
        string GetAllSchedulesQuery { get; }
        string GetScheduleByIDQuery { get; }
        string InsertScheduleQuery { get; }
        string UpdateScheduleQuery { get; }
        string DeleteScheduleQuery { get; }
    }
}