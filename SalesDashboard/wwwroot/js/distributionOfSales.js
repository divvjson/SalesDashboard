let map;

window.initializeMap = () => {
    if (!map) {
        map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: 0, lng: 0 },
            disableDoubleClickZoom: true,
            fullscreenControl: false,
            mapTypeControl: false,
            streetViewControl: false,
            zoomControl: false,
            zoom: 2
        });
    }
};

window.updateMap = (salesData) => {

};
