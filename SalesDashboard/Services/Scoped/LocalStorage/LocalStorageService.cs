using Microsoft.JSInterop;
using System.Text.Json;

namespace SalesDashboard.Services.Scoped.LocalStorage
{
    public class LocalStorageService(IJSRuntime jSRuntime)
    {
        public async Task<T?> GetItemAsync<T>(string key)
        {
            var value = await jSRuntime.InvokeAsync<string?>("localStorage.getItem", key);

            if (value is null)
            {
                return default;
            }

            var valueDeserialized = JsonSerializer.Deserialize<T>(value);

            return valueDeserialized;
        }

        public async Task SetItemAsync<T>(string key, T value)
        {
            var valueSerialized = JsonSerializer.Serialize(value);

            await jSRuntime.InvokeVoidAsync("localStorage.setItem", key, valueSerialized);
        }

        public async Task RemoveItemAsync(string key)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task ClearAsync()
        {
            await jSRuntime.InvokeVoidAsync("localStorage.clear");
        }
    }
}
