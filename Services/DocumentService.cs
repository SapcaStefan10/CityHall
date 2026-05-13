using SElab5.Models;
using SElab5.Repositories.Interfaces;
using SElab5.Services.Interfaces;

namespace SElab5.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<IEnumerable<Document>> GetUserDocumentsAsync(int userId)
        {
            return await _documentRepository.GetByOwnerIdAsync(userId);
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllAsync();
        }

        public async Task<bool> UploadDocumentAsync(Document document)
        {
            document.CreatedAt = DateTime.Now;
            await _documentRepository.AddAsync(document);
            return await _documentRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDocumentAsync(int documentId)
        {
            var doc = await _documentRepository.GetByIdAsync(documentId);
            if (doc == null) return false;
            _documentRepository.Remove(doc);
            return await _documentRepository.SaveChangesAsync() > 0;
        }
    }
}

