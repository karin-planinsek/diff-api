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
            if (data == null) throw new ArgumentNullException("Data can't be null");

            _context.LeftDiffs.Add(data);
            return data;
        }

        public LeftDiff GetLeftDiff(int id)
        {
            return _context.LeftDiffs.FirstOrDefault(x => x.Id == id);
        }
    }
}
