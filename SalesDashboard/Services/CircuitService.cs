using Microsoft.AspNetCore.Components.Server.Circuits;

namespace SalesDashboard.Services
{
    public class CircuitService(CircuitAccessor circuitAccessor) : CircuitHandler
    {
        public override async Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            circuitAccessor.CircuitId = circuit.Id;

            await base.OnCircuitOpenedAsync(circuit, cancellationToken);
        }
    }
}
