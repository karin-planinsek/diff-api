using DiffApi.Models;

namespace DiffApi.Infrastructure.Services
{
    public interface IRightDiffService
    {
        void CreateDiff(RightDiff diff);
        void UpdateDiff(RightDiff diff);
        RightDiff FindDiffById(int id);
    }
}
