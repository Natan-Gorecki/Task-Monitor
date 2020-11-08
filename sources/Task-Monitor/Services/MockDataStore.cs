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
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "First item", Description="This is an item description." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Second item", Description="This is an item description." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Third item", Description="This is an item description." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description="This is an item description." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description="This is an item description." },
                new Models.Task { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description="This is an item description." }
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