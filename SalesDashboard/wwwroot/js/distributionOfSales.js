let distributionOfSalesMap;
let circles = [];
const baseScaleFactor = 150; // Initial scale factor

window.initializeMap = () => {
    const distributionOfSalesMapElement = document.getElementById('distributionOfSalesMap');

    if (distributionOfSalesMapElement) {
        distributionOfSalesMap = new google.maps.Map(distributionOfSalesMapElement, {
            center: { lat: 0, lng: 0 },
            disableDoubleClickZoom: true,
            fullscreenControl: false,
            mapTypeControl: false,
            streetViewControl: false,
            zoomControl: false,
            zoom: 2
        });

        distributionOfSalesMap.addListener('zoom_changed', updateCircles);
    }
};

window.updateMap = (stateProvinceSales) => {
    for (const circle of circles) {
        circle.setMap(null);
    }

    circles = [];

    for (const stateProvinceSale of stateProvinceSales) {
        const circle = new google.maps.Circle({
            strokeColor: '#FF0000',
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: '#FF0000',
            fillOpacity: 0.35,
            map: distributionOfSalesMap,
            center: { lat: stateProvinceSale.latitude, lng: stateProvinceSale.longitude },
            radius: calculateRadius(stateProvinceSale.totalSales)
        });

        const infoWindow = new google.maps.InfoWindow({
            content: `<div><strong>${stateProvinceSale.countryRegionName}</strong><br>Sales: ${stateProvinceSale.totalSales}</div>`
        });

        circle.addListener('click', () => {
            infoWindow.setPosition(circle.getCenter());
            infoWindow.open(distributionOfSalesMap);
        });

        circles.push(circle);
    }
};

function updateCircles() {
    const zoomLevel = distributionOfSalesMap.getZoom();
    for (const circle of circles) {
        const originalSales = Math.pow(circle.getRadius() / baseScaleFactor, 2);
        circle.setRadius(calculateRadius(originalSales));
    }
}

function calculateRadius(sales) {
    const zoomLevel = distributionOfSalesMap.getZoom();
    const adjustedScaleFactor = baseScaleFactor / Math.pow(2, zoomLevel - 2); // Adjust the scale factor based on zoom level
    return Math.sqrt(sales) * adjustedScaleFactor;
}
