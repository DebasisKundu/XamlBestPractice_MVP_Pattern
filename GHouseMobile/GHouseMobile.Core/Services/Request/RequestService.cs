using GHouseMobile.Core.Enums;
using GHouseMobile.Core.Exceptions;
using GHouseMobile.Core.Services.Connections;
using GHouseMobile.Core.Services.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GHouseMobile.Core.Services.Request
{
    public class RequestService : IRequestService
    {
        readonly JsonSerializerSettings _serializerSettings;
        readonly IConnectivityService _connectivityService;
        readonly IExceptionService _exceptionService;

        public RequestService(IConnectivityService connectivityService, IExceptionService exceptionService)
        {
            _connectivityService = connectivityService;
            _exceptionService = exceptionService;

            _serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string? token = "")
        {
            var httpClient = CreateHttpClient(token);
            var response = await ExecuteWithPolicy(() => httpClient.GetAsync(uri))
                .ConfigureAwait(false);

            await HandleRespone(response).ConfigureAwait(false);

            var serialized = await response.Content.ReadAsStringAsync();
            var result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings)!);

            return result;
        }

        public async Task<TResult> Post<TResult>(string uri, TResult data, string? token = "")
        {
            return await Post<TResult, TResult>(uri, data, token);
        }

        public async Task<TResult> Post<TRequest, TResult>(string uri, TRequest data, string? token = "")
        {
            var httpClient = CreateHttpClient(token);
            var serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await ExecuteWithPolicy(() => httpClient.PostAsync(uri, stringContent));

            await HandleRespone(response);

            serialized = await response.Content.ReadAsStringAsync();
            var result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings)!);

            return result;
        }

        HttpClient CreateHttpClient(string? token = "")
        {
            if (!_connectivityService.IsConnected)
            {
                throw new ConnectivityException();
            }

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return httpClient;
        }

        async Task HandleRespone(HttpResponseMessage httpResponse)
        {
            if (!httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.StatusCode == HttpStatusCode.Forbidden || httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnAuthorizeException(content);
                }

                throw new HttpRequestException(content);
            }
        }

        async Task<HttpResponseMessage> ExecuteWithPolicy(Func<Task<HttpResponseMessage>> action)
        {
            var policy = Policy
                .Handle<WebException>(ex =>
                {
                    _exceptionService.Log(ExceptionLevel.Critical, ex);
                    return true;
                }).WaitAndRetryAsync(GlobalSettings.HttpRequestRetryAttempt,
                retryAttemp => TimeSpan.FromSeconds(Math.Pow(2, retryAttemp))
                );

            return await policy.ExecuteAsync(action);
        }
    }
}
