public partial class ScheduleTaskVm
{
    public string StatusBootstrapClass
    {
        get
        {
            return Status switch
            {
                ScheduleStatus.Completed => "success",
                ScheduleStatus.InProgress => "primary",
                ScheduleStatus.Pending => "secondary",
                ScheduleStatus.Cancelled => "danger",
                _ => "light"
            };
        }
    }
}