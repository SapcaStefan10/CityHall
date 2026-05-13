using SElab5.Models;

 namespace SElab5.Services.Interfaces
{
    public interface IHearingService
    {
        Task<IEnumerable<Hearing>> GetUserHearingsAsync(int userId);
        Task<IEnumerable<Hearing>> GetAllHearingsAsync();
        Task<bool> ScheduleHearingAsync(Hearing hearing);
    }
}

