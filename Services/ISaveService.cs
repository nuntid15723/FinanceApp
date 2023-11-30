// ISaveService.cs
namespace FinanceApp.Services
{
    public interface ISaveService
    {
        Task SaveData(List<Models.Deposit> data);
    }

}
