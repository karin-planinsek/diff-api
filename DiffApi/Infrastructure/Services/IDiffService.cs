using DiffApi.Dto;

namespace DiffApi.Infrastructure.Services
{
    public interface IDiffService
    {
        DiffResponseDto GetDiff(byte[] leftDiff, byte[] rightDiff);
    }
}
