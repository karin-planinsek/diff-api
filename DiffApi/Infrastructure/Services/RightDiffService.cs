using DiffApi.Infrastructure.Repositories;
using DiffApi.Models;
using System.Text;

namespace DiffApi.Infrastructure.Services
{
    public class RightDiffService : IRightDiffService
    {
        private readonly IRightDiffRepository _rightDiffRepository;

        public RightDiffService(IRightDiffRepository rightDiffRepository)
        {
            _rightDiffRepository = rightDiffRepository;
        }
        public void CreateDiff(int id, string data)
        {
            var right = new RightDiff { Id = id, Data = Encoding.ASCII.GetBytes(data) };
            var rightId = FindDiffById(id);

            if (rightId == null) _rightDiffRepository.CreateRightDiff(right);
            else _rightDiffRepository.UpdateRightDiff(right);
        }

        public RightDiff FindDiffById(int id)
        {
            var rightDiff = _rightDiffRepository.GetRightDiff(id);

            return rightDiff;
        }
    }
}
