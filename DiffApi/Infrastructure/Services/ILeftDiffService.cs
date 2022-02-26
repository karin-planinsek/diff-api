using DiffApi.Models;

namespace DiffApi.Infrastructure.Services
{
    public interface ILeftDiffService
    {
        void CreateDiff(int id, string data);
        LeftDiff FindDiffById(int id);
    }
}
