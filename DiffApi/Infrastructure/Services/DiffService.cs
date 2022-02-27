using DiffApi.Dto;
using System.Text;

namespace DiffApi.Infrastructure.Services
{
    public class DiffService : IDiffService
    {
        public DiffResponseDto GetDiff(byte[] leftDiff, byte[] rightDiff)
        {
            if (leftDiff.SequenceEqual(rightDiff)) 
                return new DiffResponseDto { DiffResultType = Response.Equals };
            else if (leftDiff.Length != rightDiff.Length) 
                return new DiffResponseDto { DiffResultType = Response.SizeDoNotMatch };
            else 
                return new DiffResponseDto { DiffResultType = Response.ContentDoNotMatch, Diffs = GetDiffDetails(leftDiff, rightDiff) };
        }

        // find diffs and calculate offsets and lengths
        public IEnumerable<DiffDto> GetDiffDetails(byte[] leftDiff, byte[] rightDiff)
        {
            List<DiffDto> diffs = new List<DiffDto>();
            var diffLength = 0;

            for (int i = 0; i < leftDiff.Length; i++)
            {
                if (leftDiff[i] == rightDiff[i])
                {
                    if (diffLength > 0)
                    {
                        diffs.Add(new DiffDto { Length = diffLength, Offset = i - diffLength });
                        diffLength = 0;
                    }
                }
                else diffLength++;
            }

            if (diffLength > 0)
                diffs.Add(new DiffDto { Length = diffLength, Offset = leftDiff.Length - diffLength });

            return diffs;
        }
    }
}
