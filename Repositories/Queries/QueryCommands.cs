namespace NVPapi.Repositories
{
    public class QueryCommandText : IQueryCommandText
    {

        public string GetAllSchedulesQuery => "select * from [NVPdb].[dbo].[Schedules]";

        public string GetScheduleByIDQuery => "select * from [NVPdb].[dbo].[Schedules] where Document_ID = @Document_ID";

        public string InsertScheduleQuery => "insert into [NVPdb].[dbo].[Schedules] " +
                "(From_IP, Location_ID, PDF_Path, Document_Text) " +
                "values (@From_IP, @Location_ID, @PDF_Path, @Document_Text)";
        //public string InsertScheduleQuery => "select * from [NVPdb].[dbo].[Schedules] where Document_ID = 111";
        //"output inserted.[Document_ID] " +


        public string UpdateScheduleQuery => "update [NVPdb].[dbo].[Schedules] " +
            "set Processed_Flag = @Processed_Flag, From_IP = @From_IP, Location_ID = @Location_ID, PDF_Path = @PDF_Path, " +
            "Document_Text = @Document_Text, Update_Date = GETDATE(), Updated_By = suser_name() where Document_ID = @Document_ID";

        public string DeleteScheduleQuery => "delete from [NVPdb].[dbo].[Schedules] where Document_ID = @Document_ID";

        //public string GetProductBySomethingSPROC => "DoSomethingSPROC";

    }
}
