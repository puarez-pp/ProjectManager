

namespace ProjectManager.Application.Common.Interfaces
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
        string DateToString(DateTime date);
        int DuriationInDays(DateTime start, DateTime end);
        DateTime AddDays(DateTime date, int days);
    }
}
