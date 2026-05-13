using SElab5.Models;
using SElab5.Repositories.Interfaces;
using SElab5.Services.Interfaces;

namespace SElab5.Services
{
    public class HearingService : IHearingService
    {
        private readonly IHearingRepository _hearingRepository;

        public HearingService(IHearingRepository hearingRepository)
        {
            _hearingRepository = hearingRepository;
        }

        public async Task<IEnumerable<Hearing>> GetUserHearingsAsync(int userId)
        {
            return await _hearingRepository.GetByCitizenIdAsync(userId);
        }

        public async Task<IEnumerable<Hearing>> GetAllHearingsAsync()
        {
            return await _hearingRepository.GetAllAsync();
        }

        public async Task<bool> ScheduleHearingAsync(Hearing hearing)
        {
            hearing.CreatedAt = DateTime.Now;
            hearing.Status = HearingStatus.Scheduled;
            await _hearingRepository.AddAsync(hearing);
            return await _hearingRepository.SaveChangesAsync() > 0;
        }
    }
}

