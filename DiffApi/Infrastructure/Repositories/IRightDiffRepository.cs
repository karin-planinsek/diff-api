using DiffApi.Models;

namespace DiffApi.Infrastructure.Repositories
{
    public interface IRightDiffRepository
    {
        RightDiff GetRightDiff(int id);
        RightDiff CreateRightDiff(RightDiff data);
        RightDiff UpdateRightDiff(RightDiff data);
    }
}
