let distributionOfSalesMap;
let circles = [];

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
    }
};

window.updateMap = (stateProvinceSales) => {
    for (const circle of circles) {
        circle.setMap(null);
    }

    circles = [];

    for (const stateProvinceSale of stateProvinceSales) {
        const scaleFactor = 150; // Adjust this factor to control the size of the circles
        const circle = new google.maps.Circle({
            strokeColor: '#FF0000',
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: '#FF0000',
            fillOpacity: 0.35,
            map: distributionOfSalesMap,
            center: { lat: stateProvinceSale.latitude, lng: stateProvinceSale.longitude },
            radius: Math.sqrt(stateProvinceSale.totalSales) * scaleFactor
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
