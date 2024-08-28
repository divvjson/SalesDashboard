export function initializeResizeListener(dotNetObj) {
    window.addEventListener('resize', () => {
        dotNetObj.invokeMethodAsync('HandleResize');
    });
}

export function getScreenWidth() {
    return window.innerWidth;
}
