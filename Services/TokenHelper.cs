using System;
using System.IdentityModel.Tokens.Jwt;
namespace FinanceApp.Services
{
	public static class TokenHelper
	{
		public static (string CoopControl, string CoopId, string Name, string Email, string Actort, string ApvlevelId, string WorkDate) DecodeToken(string accessToken)
		{
			var handler = new JwtSecurityTokenHandler();
			var token = handler.ReadJwtToken(accessToken);

			// Get Payload
			var payload = token.Payload;

			// Get values from Payload
			var CoopControl = payload["CoopControl"].ToString();
			var CoopId = payload["CoopId"].ToString();
			var Name = payload["name"].ToString();
			var Email = payload["email"].ToString();
			var Actort = payload["actort"].ToString();
			var ApvlevelId = payload["ApvlevelId"].ToString();
			var WorkDate = payload["WorkDate"].ToString();

			// Return values as a Tuple
			return (CoopControl, CoopId, Name, Email, Actort, ApvlevelId, WorkDate);
		}

	}
}
