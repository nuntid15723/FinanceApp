namespace FinanceApp.Services;

public interface IApiService
{
    Task<LoginResult> Login(string username, string password, string selectedDatabase);
}

