namespace FinanceApp;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using FinanceApp.Services;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

public partial class LoginBase : ComponentBase
{
    [Inject]
    protected LoginService LoginService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    protected string user_name;
    protected string password;
    protected string selectedDatabase;
    protected string coopcontrol;
    protected string errorMessage;
    protected LoginResult loginResponse;
    protected bool isLoading;
    public List<Connection> connections = new List<Connection>();


    public async Task selectedBase(ChangeEventArgs e)
    {
        string value = e.Value.ToString();

        string[] values = value.Split('*');
        string id = values[0];
        string name = values[1];
        string coop_control = values[2];
        selectedDatabase = id;
        coopcontrol = coop_control;
        Console.WriteLine($"coopcontrol :{coopcontrol}");
        StateHasChanged();


    }
    public async Task<bool> IsUserAuthenticated()
    {
        // Check if there is a valid token
        string bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        return !string.IsNullOrEmpty(bearerToken);
    }
    public async Task LoadConnections()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync($"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.OfGetConnection}");
        Console.WriteLine($"response.IsSuccessStatusCode :{response.IsSuccessStatusCode}");
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            using (JsonReader jsonReader = new JsonTextReader(new StringReader(jsonString)))
            {
                JsonSerializer serializer = new JsonSerializer();
                connections = serializer.Deserialize<List<Connection>>(jsonReader);
            }
            Console.WriteLine($"connections :{jsonString}");
            foreach (var connection in connections)
            {
                Console.WriteLine($"id: {connection.Id},coopcontrol: {connection.coopcontrol}, connectionName: {connection.ConnectionName}");
            }

        }
        else
        {
            errorMessage = "Username และ password ไม่สามารถเว้นว่างได้.";
            return;
        }
    }
    public class Connection
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("coopcontrol")]
        public string coopcontrol { get; set; }

        [JsonPropertyName("connectionName")]
        public string ConnectionName { get; set; }
    }
    protected async Task SubmitForm()
    {
        try
        {
            isLoading = true;
            string bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
            var request = new HttpRequestMessage(HttpMethod.Get, bearerToken);
            // Add the Authorization header
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
            Console.WriteLine($"request :{request.Headers.Authorization}");
            if (selectedDatabase == null)
            {
                if (connections.Count > 0)
                {
                    selectedDatabase = $"{connections[0].Id}";
                }

            }
            loginResponse = await LoginService.Login(user_name, password, selectedDatabase, coopcontrol);
            if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password))
            {
                errorMessage = "Username และ password ไม่สามารถเว้นว่างได้.";
                return;
            }
            if (loginResponse.Success)
            {

                // string accessToken = loginResponse.Content.AccessToken;
                // TokenHelper.DecodeToken(accessToken);
                ApiClient.authToken = loginResponse.accessToken;
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", loginResponse.accessToken);
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "refreshToken", loginResponse.refreshToken);
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "pin", loginResponse.PIN);
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "user_name", user_name);
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "coopControl", loginResponse.coopControl);
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "coopId", loginResponse.coopId);
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "fullName", loginResponse.fullName);
                var amsecUseappssJson = JsonConvert.SerializeObject(loginResponse.amsecUseappss);
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "amsecUseappss", amsecUseappssJson);
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "base_type", selectedDatabase);
                // await JSRuntime.InvokeVoidAsync("localStorage.setItem", "amsecUseappss", loginResponse.amsecUseappss);
                NavigationManager.NavigateTo("index", true);
                Console.WriteLine($"amsecUseappssJson :{amsecUseappssJson}");
            }
            else
            {
                errorMessage = loginResponse.RESPONSE_MESSAGE;
                Console.WriteLine($"loginResponse: {JsonConvert.SerializeObject(loginResponse)}");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            isLoading = false;
        }
        finally
        {
            isLoading = false;
        }

    }

}
