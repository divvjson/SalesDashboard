export function getFormattedCommandText(commandText) {
    const formattedCommandText = window.sqlFormatter.format(commandText, { language: 'tsql' });

    return formattedCommandText;
}
