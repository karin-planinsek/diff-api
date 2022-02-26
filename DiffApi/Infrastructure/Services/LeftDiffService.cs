using DiffApi.Infrastructure.Repositories;
using DiffApi.Models;
using System.Text;

namespace DiffApi.Infrastructure.Services
{
    public class LeftDiffService : ILeftDiffService
    {
        private readonly ILeftDiffRepository _leftDiffRepository;

        public LeftDiffService(ILeftDiffRepository leftDiffRepository)
        {
            _leftDiffRepository = leftDiffRepository;
        }
        public void CreateDiff(int id, string data)
        {
            var left = new LeftDiff { Id = id, Data = Encoding.ASCII.GetBytes(data) };
            var leftId = FindDiffById(left.Id);

            if (leftId == null) _leftDiffRepository.CreateLeftDiff(left);
            else _leftDiffRepository.UpdateLeftDiff(left);
        }

        public LeftDiff FindDiffById(int id)
        {
            var leftDiff = _leftDiffRepository.GetLeftDiff(id);

            return leftDiff;
        }
    }
}
