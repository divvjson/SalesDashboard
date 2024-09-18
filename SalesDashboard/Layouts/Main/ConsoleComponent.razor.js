export function getFormattedCommandText(commandText) {
    const formattedCommandText = window.sqlFormatter.format(commandText, { language: 'tsql' });
    return formattedCommandText;
}

export function highlightCommandText() {
    const codeBlocks = document.querySelectorAll('pre code.command-text');
    for (const codeBlock of codeBlocks) {
        if (!codeBlock.dataset.highlighted) {
            hljs.highlightElement(codeBlock);
            codeBlock.dataset.highlighted = true;
        }
    }
}
