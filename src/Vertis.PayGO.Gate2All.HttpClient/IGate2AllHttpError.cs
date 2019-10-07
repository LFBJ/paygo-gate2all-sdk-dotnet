namespace Vertis.PayGO.Gate2All.HttpClient
{
    public interface IGate2AllHttpError
    {
        int StatusCode { get; }

        string Content { get; }
    }
}
