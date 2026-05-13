using SElab5.Models;
using SElab5.Repositories.Interfaces;
using SElab5.Services.Interfaces;

namespace SElab5.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IHearingRepository _hearingRepository;

        public UserService(
            IUserRepository userRepository, 
            IRequestRepository requestRepository, 
            IDocumentRepository documentRepository, 
            IHearingRepository hearingRepository)
        {
            _userRepository = userRepository;
            _requestRepository = requestRepository;
            _documentRepository = documentRepository;
            _hearingRepository = hearingRepository;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return null;

            // Simple password check (In production, use BCrypt or similar)
            if (user.PasswordHash == password) 
            {
                return user;
            }

            return null;
        }

        public async Task<bool> RegisterAsync(User user, string password)
        {
            if (await _userRepository.ExistsAsync(user.Email))
            {
                return false;
            }

            user.PasswordHash = password; // Should be hashed!
            user.RoleID = 1; // Default to Citizen
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetUserProfileAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return false;

            // Delete related data first (Manual Cascade)
            var requests = await _requestRepository.GetByCitizenIdAsync(userId);
            foreach (var r in requests) _requestRepository.Remove(r);

            var docs = await _documentRepository.GetByOwnerIdAsync(userId);
            foreach (var d in docs) _documentRepository.Remove(d);

            var hearings = await _hearingRepository.GetByCitizenIdAsync(userId);
            foreach (var h in hearings) _hearingRepository.Remove(h);

            _userRepository.Remove(user);
            return await _userRepository.SaveChangesAsync() > 0;
        }
    }
}

