namespace DiffApi.Models
{
    public class DiffResponse
    {
        public string DiffResultType { get; set; }
        public Diff[]? Diffs { get; set; }
    }

    public enum Response
    {
        Equals, ContentDoNotMatch, SizeDoNotMatch
    }
}
