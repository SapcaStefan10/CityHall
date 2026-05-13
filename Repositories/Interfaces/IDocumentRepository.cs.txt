using SElab5.Models;

namespace SElab5.Repositories.Interfaces
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<IEnumerable<Document>> GetByOwnerIdAsync(int ownerId);
        Task<IEnumerable<Document>> GetByDepartmentIdAsync(int departmentId);
    }
}

