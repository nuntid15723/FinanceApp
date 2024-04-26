using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;


namespace FinanceApp.Services
{
	public class GetUserDataList
	{
		private readonly IJSRuntime _jsRuntime;

		public GetUserDataList(IJSRuntime jsRuntime)
		{
			_jsRuntime = jsRuntime;
		}

		// ฟังก์ชันนี้ใช้ DI เพื่อรับ IJSRuntime
		public async Task<(string coopControl, string coop_id, string user_name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag)> GetDataList()
		{
			var bearerToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
			string accessToken = bearerToken;
			string application = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "application");
			string save_status = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "save_status");
			string checkFlag = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "check_flag");

			// ดำเนินการอื่นๆ ตามที่ต้องการ
			var (coopControl, coop_id, name, email, actort, apvlevelId, workDate) = TokenHelper.DecodeToken(accessToken);
			return (coopControl, coop_id, name, email, actort, apvlevelId, workDate, application, save_status, checkFlag);
		}
	}

}
