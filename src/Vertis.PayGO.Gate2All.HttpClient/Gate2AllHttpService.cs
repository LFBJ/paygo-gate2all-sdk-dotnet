using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vertis.PayGO.Gate2All.HttpClient.CreditCard;

#if !NETSTANDARD
using Nito.AsyncEx;
#endif

// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

namespace Vertis.PayGO.Gate2All.HttpClient
{
    public class Gate2AllHttpService : IGate2AllHttpService
    {
        public virtual bool AvoidThrowingExceptions { get; set; }

        protected string JsonContentType => "application/json";

        protected System.Net.Http.HttpClient HttpClient { get; }

        public Gate2AllHttpService(System.Net.Http.HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public CreateAuthorizationResponse Authorize(CreateAuthorizationRequest request)
        {
#if !NETSTANDARD
            return AsyncContext.Run(async () => await AuthorizeAsync(request));
#else
            throw new NotSupportedException();
            #endif
        }

        public async Task<CreateAuthorizationResponse> AuthorizeAsync(CreateAuthorizationRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var httpRequest = CreateJsonHttpRequest(HttpMethod.Post, "v1/transactions", request))
            using (var httpResponse = await HttpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                var stream = await httpResponse.Content.ReadAsStreamAsync();

                if (httpResponse.IsSuccessStatusCode)
                    return DeserializeJsonFromStream<CreateAuthorizationResponse>(stream);

                var httpError = new Gate2AllHttpException
                {
                    StatusCode = (int) httpResponse.StatusCode,
                    Content = await StreamToStringAsync(stream)
                };

                if (AvoidThrowingExceptions)
                    return new CreateAuthorizationResponse{HttpError = httpError};

                throw httpError;
            }
        }

        #region Métodos Internos Auxiliares

        public virtual T TryDeserialize<T>(string jsonContents, out Exception exception)
        {
            exception = null;

            try
            {
                return JsonConvert.DeserializeObject<T>(jsonContents);
            }
            catch(Exception ex)
            {
                exception = ex;
                return default(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="relativeUri"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        protected virtual HttpRequestMessage CreateJsonHttpRequest(HttpMethod httpMethod, string relativeUri, object requestData = null)
        {
            if (string.IsNullOrWhiteSpace(relativeUri))
                throw new ArgumentException(
                    "A url relativa da requisição não pode ser nula ou vazia, e nem deve começar com uma barra.",
                    nameof(relativeUri));

            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(relativeUri, UriKind.Relative)
            };

            var jsonBody = ToJson(requestData) ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(jsonBody))
                request.Content = new StringContent(jsonBody, Encoding.UTF8, JsonContentType);

            request.Headers.TryAddWithoutValidation("TransactionId", Guid.NewGuid().ToString());
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));

            return request;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected virtual string ToJson(object data)
        {
            return data != null ? JsonConvert.SerializeObject(data) : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content;
            if (stream == null)
                return null;

            using (var sr = new StreamReader(stream))
                content = await sr.ReadToEndAsync();

            return content;
        }

        #endregion
    }
}
