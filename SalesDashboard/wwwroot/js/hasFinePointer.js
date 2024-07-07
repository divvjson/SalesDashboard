function hasFinePointer() {
    if (window.matchMedia("(pointer: fine)").matches) {
        return true;
    } else {
        return false;
    }
}
