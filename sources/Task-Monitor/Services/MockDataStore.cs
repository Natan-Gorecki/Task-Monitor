using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMonitor.Models;

namespace TaskMonitor.Services
{
    public class MockDataStore : IDataStore<Models.Task>
    {
        readonly List<Models.Task> items;

        public MockDataStore()
        {
            items = new List<Models.Task>()
            {
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Wstać rano", Description="Wczesne rozpoczęcie dnia jest bardzo ważne i rzutuje na cały dzień." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Pójść do pracy", Description="O godzinie 8 otworzyć biuro i rozpocząć prace." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "8 godzin pracy", Description="Intensywna praca nad rozwojem rozpoczętych projektów." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Pouczyć się Xamarina", Description="Dalsze poznawanie środowiska i nowych kontrolek Xamarin.Forms." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Odpocząć", Description="Zregenerować siły i dać sobię chwilę wytchnienia." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Wyspać się", Description="Żeby dobrze rozpocząć kolejny dzień, trzeba pójść spać o wczenej porze." }
            };
        }

        public async Task<bool> AddItemAsync(Models.Task item)
        {
            items.Add(item);

            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Models.Task item)
        {
            var oldItem = items.Where((Models.Task arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Models.Task arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await System.Threading.Tasks.Task.FromResult(true);
        }

        public async Task<Models.Task> GetItemAsync(string id)
        {
            return await System.Threading.Tasks.Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Models.Task>> GetItemsAsync(bool forceRefresh = false)
        {
            return await System.Threading.Tasks.Task.FromResult(items);
        }
    }
}