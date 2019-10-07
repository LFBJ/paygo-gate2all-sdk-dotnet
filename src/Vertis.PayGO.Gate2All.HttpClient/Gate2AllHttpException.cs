using System;

namespace Vertis.PayGO.Gate2All.HttpClient
{
    public class Gate2AllHttpException : Exception, IGate2AllHttpError
    {
        public int StatusCode { get; set; }

        public string Content { get; set; }
    }
}
