using DiffApi.Infrastructure.Repositories;
using DiffApi.Models;

namespace DiffApi.Infrastructure.Services
{
    public class LeftDiffService : ILeftDiffService
    {
        private readonly ILeftDiffRepository _leftDiffRepository;

        public LeftDiffService(ILeftDiffRepository leftDiffRepository)
        {
            _leftDiffRepository = leftDiffRepository;
        }
        public int CreateDiff(LeftDiff diff)
        {
            var leftDiff = _leftDiffRepository.CreateLeftDiff(diff);

            return leftDiff.Id;
        }

        public LeftDiff FindDiffById(int id)
        {
            var leftDiff = _leftDiffRepository.GetLeftDiff(id);

            return leftDiff;
        }

        public int UpdateDiff(LeftDiff diff)
        {
            var leftDiff = _leftDiffRepository.UpdateLeftDiff(diff);

            return leftDiff.Id;
        }
    }
}
