namespace FinanceApp.Services;

public class LoginResult
{
    public string RESPONSE_CODE { get; set; }
    public string RESPONSE_MESSAGE { get; set; }
    public string REFRESH_TOKEN { get; set; }
    public string ACCESS_TOKEN { get; set; }
    public int PIN { get; set; }
    public bool RESULT { get; set; }
}


public class LoginModel
{
    public string app_version { get; set; }
    public string channel { get; set; }
    public string device_name { get; set; }
    public string ip_address { get; set; }
    public string is_root { get; set; }
    public string platform { get; set; }
    public string unique_id { get; set; }
    public string api_token { get; set; }
    public string fcm_token { get; set; }
    public string hms_token { get; set; }
    public string member_no { get; set; }
    public string password { get; set; }
    public string username { get; set; }
}
