using SElab5.Models;

namespace SElab5.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<IEnumerable<Document>> GetUserDocumentsAsync(int userId);
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<bool> UploadDocumentAsync(Document document);
        Task<bool> DeleteDocumentAsync(int documentId);
    }
}

