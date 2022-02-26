using DiffApi.Db;
using DiffApi.Models;

namespace DiffApi.Infrastructure.Repositories
{
    public class LeftDiffRepository : ILeftDiffRepository
    {
        private readonly DiffContext _context;

        public LeftDiffRepository(DiffContext context)
        {
            _context = context;
        }
        public LeftDiff CreateLeftDiff(LeftDiff data)
        {
            _context.LeftDiffs.Add(data);
            _context.SaveChanges();
            
            return data;
        }

        public LeftDiff GetLeftDiff(int id)
        {
            var diff = _context.LeftDiffs.FirstOrDefault(x => x.Id == id);
            return diff;
        }

        public LeftDiff UpdateLeftDiff(LeftDiff data)
        {
            var leftDiff = GetLeftDiff(data.Id);
            leftDiff.Data = data.Data;
            _context.SaveChanges();

            return leftDiff;
        }
    }
}
