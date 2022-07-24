using OwnerPermission.Models;

namespace OwnerPermission.Data
{
    public interface IDocumentRepository
    {
        Document Find(int documentId);
    }
}
