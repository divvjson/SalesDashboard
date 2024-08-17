let employeeLocationMap;
let markers = [];

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

export function updateMap(employeeLocationItems) {
    clearMarkers();

    const infoWindow = new google.maps.InfoWindow();

    for (const employeeLocationItem of employeeLocationItems) {
        if (employeeLocationItem.latitude && employeeLocationItem.longitude) {
            const marker = new google.maps.Marker({
                position: {
                    lat: employeeLocationItem.latitude,
                    lng: employeeLocationItem.longitude
                },
                map: employeeLocationMap,
                title: `${employeeLocationItem.firstName} ${employeeLocationItem.lastName}`
            });

            markers.push(marker);

            marker.addListener('click', () => {
                infoWindow.setContent(`<div><strong>${employeeLocationItem.firstName} ${employeeLocationItem.lastName}</strong></div>`);
                infoWindow.open(employeeLocationMap, marker);
            });
        }
    }
}

function clearMarkers() {
    for (let i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }
    markers = [];
}
