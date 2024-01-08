namespace FinanceApp.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ApiProvider : IApiProvider
{
    private readonly HttpClient _httpClient;


    public ApiProvider(HttpClient httpClient)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate;

        HttpClient client = new HttpClient(clientHandler);
        httpClient = client;

        _httpClient = httpClient;
    }

    // public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
    // {
    //     uri = ApiClient.API.ApibaseUrl + uri;
    //     var json = JsonConvert.SerializeObject(item);
    //     var content = new StringContent(json, Encoding.UTF8, "application/json");
    //     return await _httpClient.PostAsync(uri, content);
    // }
    public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
    {
        uri = ApiClient.API.ApibaseUrl + uri;
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync(uri, content);
    }
    public async Task<HttpResponseMessage> PostAsyncWithAuth<T>(string uri, T item)
    {
        uri = ApiClient.API.ApibaseUrl + uri;
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri),
            Content = content
        };
        request.Headers.Add("Accept", "application/json");
        var bearerToken = $"Bearer {Constants.authToken}";
        request.Headers.Add("Authorization", bearerToken);

        return await _httpClient.SendAsync(request);
    }



    public async Task<string> GetStringAsync(string uri)
    {
        uri = ApiClient.API.ApibaseUrl + uri;
        return await _httpClient.GetStringAsync(uri);
    }

    public async Task<HttpResponseMessage> GetAsync(string uri)
    {
        uri = ApiClient.API.ApibaseUrl + uri;
        var res = await _httpClient.GetAsync(uri); ;
        HttpContent contentRes = res.Content;
        var data = await contentRes.ReadAsStringAsync();

        return res;
    }


    public async Task<HttpResponseMessage> GetWithAuth(string url)
    {
        url = ApiClient.API.ApibaseUrl + url;
        var json = JsonConvert.SerializeObject(new
        {
            unique_id = Constants.UniqueId,
        });
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
            Content = content
        };
        request.Headers.Add("Accept", "application/json");
        var b1 = ($"Bearer {Constants.authToken}");
        request.Headers.Add("Authorization", b1);
        var res = await _httpClient.SendAsync(request);

        return res;
    }

    public async Task<HttpResponseMessage> GetWithAuthBody<T>(string url, T bodyObject)
    {
        url = ApiClient.API.ApibaseUrl + url;
        var json = JsonConvert.SerializeObject(bodyObject);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
            Content = content
        };
        request.Headers.Add("Accept", "application/json");
        var b1 = ($"Bearer {Constants.authToken}");
        request.Headers.Add("Authorization", b1);
        var res = await _httpClient.SendAsync(request);

        return res;
    }

    public async Task<HttpResponseMessage> DeleteAsyncWithAuth<T>(string uri, T item)
    {
        uri = ApiClient.API.ApibaseUrl + uri;
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uri),
            Content = content
        };
        request.Headers.Add("Accept", "application/json");
        var bearerToken = $"Bearer {Constants.authToken}";
        request.Headers.Add("Authorization", bearerToken);

        return await _httpClient.SendAsync(request);
    }


}
