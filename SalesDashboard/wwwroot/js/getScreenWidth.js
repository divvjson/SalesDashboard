window.getScreenWidth = () => {
    return window.innerWidth;
};

window.resizeListener = (dotNetObj) => {
    window.addEventListener('resize', () => {
        dotNetObj.invokeMethodAsync('HandleResize');
    });
};
