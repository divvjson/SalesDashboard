export async function copyTextToClipboardAsync(text) {
    try {
        await navigator.clipboard.writeText(text);
    } catch (error) {
        console.error(`Error copying text to clipboard: ${error}`);
    }
}
