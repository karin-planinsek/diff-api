using DiffApi.Models;

namespace DiffApi.Infrastructure.Services
{
    public interface ILeftDiffService
    {
        int CreateDiff(LeftDiff diff);
        int UpdateDiff(LeftDiff diff);
        LeftDiff FindDiffById(int id);
    }
}
