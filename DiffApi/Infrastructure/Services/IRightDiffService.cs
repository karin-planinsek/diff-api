using DiffApi.Models;

namespace DiffApi.Infrastructure.Services
{
    public interface IRightDiffService
    {
        void CreateDiff(int id, string data);
        RightDiff FindDiffById(int id);
    }
}
