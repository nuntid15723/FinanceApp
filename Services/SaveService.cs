// SaveService.cs
using FinanceApp.Pages.Deposit.Dep_slip_deposit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace FinanceApp.Services
{
    public class SaveService : ISaveService
    {
        public List<Models.Deposit> datadetail = new List<Models.Deposit>();

        public async Task SaveData(List<Models.Deposit> data)
        {
            datadetail = new List<Models.Deposit>();
            datadetail.AddRange(data);
            foreach (var deposit in data)
            {
                var Item = deposit.deptSlip;
                Console.WriteLine($"Deposit ID: {Item.coop_id}");
            }
            Console.WriteLine($"Saving data...");
        }
    }

}

