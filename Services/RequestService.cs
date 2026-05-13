using SElab5.Models;
using SElab5.Repositories.Interfaces;
using SElab5.Services.Interfaces;

namespace SElab5.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await _requestRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Request>> GetUserRequestsAsync(int userId)
        {
            return await _requestRepository.GetByCitizenIdAsync(userId);
        }

        public async Task<Request> GetRequestByIdAsync(int requestId)
        {
            return await _requestRepository.GetByIdAsync(requestId);
        }

        public async Task<bool> SubmitRequestAsync(Request request)
        {
            request.CreatedAt = DateTime.Now;
            request.UpdatedAt = DateTime.Now;
            request.Status = RequestStatus.Pending;

            await _requestRepository.AddAsync(request);
            return await _requestRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRequestStatusAsync(int requestId, RequestStatus status)
        {
            var request = await _requestRepository.GetByIdAsync(requestId);
            if (request == null) return false;

            request.Status = status;
            request.UpdatedAt = DateTime.Now;

            _requestRepository.Update(request);
            return await _requestRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRequestAsync(int requestId)
        {
            var request = await _requestRepository.GetByIdAsync(requestId);
            if (request == null) return false;

            _requestRepository.Remove(request);
            return await _requestRepository.SaveChangesAsync() > 0;
        }
    }
}

