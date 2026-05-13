using SElab5.Models;

 namespace SElab5.Services.Interfaces
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> GetAllRequestsAsync();
        Task<IEnumerable<Request>> GetUserRequestsAsync(int userId);
        Task<Request> GetRequestByIdAsync(int requestId);
        Task<bool> SubmitRequestAsync(Request request);
        Task<bool> UpdateRequestStatusAsync(int requestId, RequestStatus status);
        Task<bool> DeleteRequestAsync(int requestId);
    }
}

