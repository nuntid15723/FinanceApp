namespace FinanceApp.Services;

public class LoginResult
{
    public string RESPONSE_CODE { get; set; }
    public string RESPONSE_MESSAGE { get; set; }
    public string refreshToken { get; set; }
    public string accessToken { get; set; }
    public string coopControl { get; set; }
    public string coopId { get; set; }
    public string fullName { get; set; }
    public string apvLevelId { get; set; }
    public string userName { get; set; }
    public int PIN { get; set; }
    public bool isLoading { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public string application_name { get; set; }
    public string application { get; set; }

    public AuthenticationRes Content { get; set; }
    public List<AmsecUseappss> amsecUseappss { get; set; }
}

public class AuthenticationRes
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public bool Success { get; set; }
    public object Content { get; set; }
}
public class AmsecUseappss
{
    public string coop_control { get; set; }
    public string coop_id { get; set; }
    public string user_name { get; set; }
    public string application { get; set; }
    public string application_name { get; set; }
    public bool permiss_flag { get; set; }
}

public class LoginModel
{
    public string coop_control { get; set; }
    public string coop_id { get; set; }
    public string api_token { get; set; }
    public string full_name { get; set; }
    public string description { get; set; }
    public string apvlevel_id { get; set; }
    public bool success { get; set; }
    public string fcm_token { get; set; }
    public string refreshToken { get; set; }
    public string password { get; set; }
    public string user_name { get; set; }
}
