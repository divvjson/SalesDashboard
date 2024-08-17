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
            zoom: 2,
            mapId: 'employeeLocationMap'
        });
    }
}

export function updateMap(employeeLocationItems) {
    clearMarkers();

    const infoWindow = new google.maps.InfoWindow();

    for (const employeeLocationItem of employeeLocationItems) {
        if (employeeLocationItem.latitude && employeeLocationItem.longitude) {
            const markerElement = getMarkerElement(employeeLocationItem);
            const marker = new google.maps.marker.AdvancedMarkerElement({
                map: employeeLocationMap,
                position: {
                    lat: employeeLocationItem.latitude,
                    lng: employeeLocationItem.longitude
                },
                title: `${employeeLocationItem.firstName} ${employeeLocationItem.lastName}`,
                content: markerElement,
                gmpClickable: true,
            });

            markers.push(marker);

            marker.addListener('click', () => {
                infoWindow.close();
                //infoWindow.setContent(`<div><strong>${employeeLocationItem.firstName} ${employeeLocationItem.lastName}</strong></div>`);
                infoWindow.setContent(`
                    <div>
                        <p><strong>Name:</strong> ${employeeLocationItem.firstName} ${employeeLocationItem.lastName}</p>
                        <p><strong>Job Title:</strong> ${employeeLocationItem.jobTitle}</p>
                        <p><strong>Department:</strong> ${employeeLocationItem.department}</p>
                        <p><strong>Address:</strong> ${employeeLocationItem.address}</p>
                        <p><strong>City:</strong> ${employeeLocationItem.city}</p>
                        <p><strong>State:</strong> ${employeeLocationItem.stateProvinceName}</p>
                        <p><strong>Country:</strong> ${employeeLocationItem.countryRegionName}</p>
                    </div>
                `);
                infoWindow.open(marker.map, marker);
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

function getMarkerElement(employeeLocationItem) {
    const markerElement = document.createElement('div');

    markerElement.style.backgroundColor = 'var(--mud-palette-primary)';
    markerElement.style.color = 'white';
    markerElement.style.width = '40px';
    markerElement.style.height = '40px';
    markerElement.style.borderRadius = '50%';
    markerElement.style.display = 'flex';
    markerElement.style.justifyContent = 'center';
    markerElement.style.alignItems = 'center';
    markerElement.style.fontWeight = 'bold';
    markerElement.style.fontSize = '14px';
    markerElement.style.border = '2px solid white'; // Optional: for a better contrast
    markerElement.style.boxShadow = '0 2px 6px rgba(0, 0, 0, 0.3)'; // Optional: to add some depth
    markerElement.textContent = `${employeeLocationItem.firstName.charAt(0)}${employeeLocationItem.lastName.charAt(0)}`.toUpperCase();

    return markerElement;
}