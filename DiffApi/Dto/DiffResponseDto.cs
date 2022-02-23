namespace DiffApi.Models
{
    public class DiffResponseDto
    {
        public string DiffResultType { get; set; }
        public DiffDto[]? Diffs { get; set; }
    }

    public enum Response
    {
        Equals, ContentDoNotMatch, SizeDoNotMatch
    }
}
