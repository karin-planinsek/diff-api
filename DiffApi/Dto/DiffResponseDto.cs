namespace DiffApi.Dto
{
    public class DiffResponseDto
    {
        public Response DiffResultType { get; set; }
        public IEnumerable<DiffDto>? Diffs { get; set; }
    }

    public enum Response
    {
        Equals, ContentDoNotMatch, SizeDoNotMatch
    }
}
