let employeeLocationMap;

export function initializeMap() {
    const employeeLocationMapElement = document.getElementById('employeeLocationMap');

    if (employeeLocationMapElement) {
        employeeLocationMap = new google.maps.Map(employeeLocationMapElement, {
            center: { lat: 15, lng: 5 },
            disableDoubleClickZoom: true,
            fullscreenControl: false,
            mapTypeControl: false,
            streetViewControl: false,
            zoomControl: false,
            zoom: 2
        });
    }
}
