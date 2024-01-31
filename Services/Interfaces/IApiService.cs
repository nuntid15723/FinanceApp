namespace FinanceApp.Services;

public interface IApiService
{
    Task<LoginResult> Login(string user_name, string password,string selectedDatabase);
}

