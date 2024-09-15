using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace SalesDashboard.Services
{
    public class CircuitService(ProtectedSessionStorage protectedSessionStorage) : CircuitHandler
    {
        private readonly ProtectedSessionStorage _protectedSessionStorage = protectedSessionStorage;

        public override async Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            await _protectedSessionStorage.SetAsync("CircuitId", circuit.Id);

            await base.OnCircuitOpenedAsync(circuit, cancellationToken);
        }
    }
}
