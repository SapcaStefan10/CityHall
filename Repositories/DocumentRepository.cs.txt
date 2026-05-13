using Microsoft.EntityFrameworkCore;
using SElab5.Data;
using SElab5.Models;
using SElab5.Repositories.Interfaces;

namespace SElab5.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Document>> GetByOwnerIdAsync(int ownerId)
        {
            return await _dbSet.Where(d => d.OwnerID == ownerId)
                               .ToListAsync();
        }

        public async Task<IEnumerable<Document>> GetByDepartmentIdAsync(int departmentId)
        {
            return await _dbSet.Where(d => d.DepartmentID == departmentId)
                               .ToListAsync();
        }
    }
}

