using FinanceApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;

namespace FinanceApp.Pages.Deposit.Dashboard
{
	public partial class Dashboard
	{
		// private ElementReference PowerBIElement;
		// string TenantID = "{{ Your TenantID }}";
		// string ClientID = "{{ Your ClientID }}";
		// string ClientSecret = "{{ Your ClientSecret }}";
		// string workspaceId = "{{ Your workspaceId }}";
		// string reportId = "{{ Your reportId }}";
		// protected override async Task
		// OnAfterRenderAsync(bool firstRender)
		// {
		// 	if (firstRender)
		// 	{
		// 		// Authenticate using created credentials
		// 		AuthenticationResult authenticationResult = await DoAuthentication();
		// 		var tokenCredentials = new TokenCredentials(authenticationResult.AccessToken, "Bearer");

		// 		using (var client = new PowerBIClient(new Uri("https://api.powerbi.com/"), tokenCredentials))
		// 		{
		// 			var report = await client.Reports.GetReportInGroupAsync(new Guid(workspaceId), new Guid(reportId));
		// 			var generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view");
		// 			var tokenResponse = await client.Reports.GenerateTokenAsync(new Guid(workspaceId), new Guid(reportId), generateTokenRequestParameters);

		// 			// Call a method to create report in your Razor component
		// 			await CreateReport(tokenResponse.Token, report.EmbedUrl, report.Id.ToString());
		// 		}
		// 	}
		// }
		// private const string AuthorityFormat = "https://login.microsoftonline.com/{0}/v2.0";
		// private const string MSGraphScope = "https://analysis.windows.net/powerbi/api/.default";

		// private async Task<AuthenticationResult> DoAuthentication()
		// {
		// 	IConfidentialClientApplication daemonClient = ConfidentialClientApplicationBuilder
		// 		.Create(ClientID)
		// 		.WithAuthority(string.Format(AuthorityFormat, TenantID))
		// 		.WithClientSecret(ClientSecret)
		// 		.Build();

		// 	AuthenticationResult authResult = await daemonClient.AcquireTokenForClient(new[] { MSGraphScope }).ExecuteAsync();
		// 	return authResult;
		// }

		// private async Task CreateReport(string token, string embedUrl, string reportId)
		// {
		// 	// Call Interop.CreateReport or other method to embed the Power BI report in your Blazor component
		// 	await Interop.CreateReport(JSRuntime, PowerBIElement, token, embedUrl, reportId);
		// }
	}
}