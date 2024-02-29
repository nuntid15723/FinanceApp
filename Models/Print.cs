namespace FinanceApp.Models
{
	public class Print
	{
		public PrintResponse printResponse { get; set; }

	}
	public class PrintResponse
	{
		public string? Message { get; set; }
		public bool Success { get; set; }
		public object? Content { get; set; }
	}

}
