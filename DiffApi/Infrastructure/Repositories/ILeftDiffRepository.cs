using DiffApi.Models;

namespace DiffApi.Infrastructure.Repositories
{
    public interface ILeftDiffRepository
    {
        LeftDiff GetLeftDiff(int id);
        LeftDiff CreateLeftDiff(LeftDiff data);
    }
}
