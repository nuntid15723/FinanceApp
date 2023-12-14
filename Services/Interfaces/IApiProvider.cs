namespace FinanceApp.Services;
public interface IApiProvider
{
    Task<HttpResponseMessage> PostAsync<T>(string uri, T item);
    Task<HttpResponseMessage> GetAsync(string uri);
    Task<string> GetStringAsync(string uri);
    Task<HttpResponseMessage> GetWithAuth(string url);
    Task<HttpResponseMessage> GetWithAuthBody<T>(string url, T bodyObject);
    Task<HttpResponseMessage> PostAsyncWithAuth<T>(string uri, T item);

    Task<HttpResponseMessage> DeleteAsyncWithAuth<T>(string uri, T item);
}
