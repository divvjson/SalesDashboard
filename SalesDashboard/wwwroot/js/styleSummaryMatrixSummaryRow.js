function styleSummaryMatrixSummaryRow(elementId) {
    const regionalSummaryMatrix = document.getElementById(elementId);
    if (regionalSummaryMatrix === undefined) {
        return;
    }

    const regionalSummaryMatrixTable = regionalSummaryMatrix.querySelector('table');
    if (regionalSummaryMatrixTable == undefined) {
        return;
    }

    const summaryRow = regionalSummaryMatrixTable.rows[regionalSummaryMatrixTable.rows.length - 1];
    if (summaryRow === undefined) {
        return;
    }

    const firstCell = summaryRow.cells[0];
    if (firstCell === undefined) {
        return;
    }

    const expandButton = firstCell.querySelector('button');
    if (expandButton === undefined || expandButton === null) {
        return;
    }

    expandButton.remove();

    const firstCellContainer = firstCell.querySelector('div');
    firstCellContainer.textContent = 'Summary';

    summaryRow.style.backgroundColor = 'var(--mud-palette-dark-lighten)';

    for (const cell of summaryRow.cells) {
        cell.style.color = 'white';
        cell.style.fontWeight = '500';
    }
}
