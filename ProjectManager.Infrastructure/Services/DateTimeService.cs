using ProjectManager.Application.Common.Interfaces;


namespace ProjectManager.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow;

        public DateTime AddDays(DateTime date, int days)
        {
            return date.AddDays(days);
        }

        public string DateToString(DateTime date)
        {
            try
            {
                return date.ToShortDateString();
            }
            catch (Exception)
            {

                return string.Empty;
            }
        }

        public int DuriationInDays(DateTime start, DateTime end)
        {
            return end.Subtract(start).Days;
        }
    }
}
