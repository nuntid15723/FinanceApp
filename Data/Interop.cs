﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace FinanceApp.Data
{
	public class Interop
	{
		internal static ValueTask<object> CreateReport(
		   IJSRuntime jsRuntime,
		   ElementReference reportContainer,
		   string accessToken,
		   string embedUrl,
		   string embedReportId)
		{
			return jsRuntime.InvokeAsync<object>(
				"ShowMyPowerBI.showReport",
				reportContainer, accessToken, embedUrl,
				embedReportId);
		}
	}
}
