using Microsoft.AspNetCore.Components.Server.Circuits;

namespace SalesDashboard.Services
{
    public class CircuitService(CircuitAccessor circuitAccessor, AdventureWorksDbCommandService dbCommandService) : CircuitHandler
    {
        public override async Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            circuitAccessor.CircuitId = circuit.Id;

            await base.OnCircuitOpenedAsync(circuit, cancellationToken);
        }

        public override async Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            dbCommandService.RemoveDbCommandInfoByCircuitId(circuit.Id);

            await base.OnCircuitClosedAsync(circuit, cancellationToken);
        }
    }
}
