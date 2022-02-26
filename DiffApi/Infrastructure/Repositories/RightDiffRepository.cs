using DiffApi.Db;
using DiffApi.Models;

namespace DiffApi.Infrastructure.Repositories
{
    public class RightDiffRepository : IRightDiffRepository
    {
        private readonly DiffContext _context;

        public RightDiffRepository(DiffContext context)
        {
            _context = context;
        }
        public RightDiff CreateRightDiff(RightDiff data)
        {
            _context.RightDiffs.Add(data);
            _context.SaveChanges();

            return data;
        }

        public RightDiff GetRightDiff(int id)
        {
            var diff = _context.RightDiffs.FirstOrDefault(x => x.Id == id);
            return diff;
        }

        public RightDiff UpdateRightDiff(RightDiff data)
        {
            var rightDiff = GetRightDiff(data.Id);
            rightDiff.Data = data.Data;
            _context.SaveChanges();

            return rightDiff;
        }
    }
}
