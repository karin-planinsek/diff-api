using DiffApi.Infrastructure.Repositories;
using DiffApi.Models;

namespace DiffApi.Infrastructure.Services
{
    public class RightDiffService : IRightDiffService
    {
        private readonly IRightDiffRepository _rightDiffRepository;

        public RightDiffService(IRightDiffRepository rightDiffRepository)
        {
            _rightDiffRepository = rightDiffRepository;
        }
        public void CreateDiff(RightDiff diff)
        {
            _rightDiffRepository.CreateRightDiff(diff);
        }

        public RightDiff FindDiffById(int id)
        {
            var rightDiff = _rightDiffRepository.GetRightDiff(id);

            return rightDiff;
        }

        public void UpdateDiff(RightDiff diff)
        {
            _rightDiffRepository.UpdateRightDiff(diff);
        }
    }
}
