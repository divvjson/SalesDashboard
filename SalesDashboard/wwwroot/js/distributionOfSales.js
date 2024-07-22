let distributionOfSalesMap;
let stateProvinceSales = [];
let circles = [];
const baseScaleFactor = 150;

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

window.updateMap = (stateProvinceSalesParam) => {
    stateProvinceSales = [];

    for (const circle of circles) {
        circle.setMap(null);
    }

    circles = [];

    for (const stateProvinceSaleParam of stateProvinceSalesParam) {
        stateProvinceSales.push(stateProvinceSaleParam);
        const circle = createCircle(stateProvinceSaleParam);
        circles.push(circle);
    }
};

function updateCircles() {
    for (const circle of circles) {
        const radius = calculateRadius(circle.totalSales);
        circle.setRadius(radius);
    }
}

function createCircle(stateProvinceSale) {
    const circle = new google.maps.Circle({
        strokeColor: '#FF0000',
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: '#FF0000',
        fillOpacity: 0.35,
        map: distributionOfSalesMap,
        center: { lat: stateProvinceSale.latitude, lng: stateProvinceSale.longitude },
        totalSales: stateProvinceSale.totalSales,
        radius: calculateRadius(stateProvinceSale.totalSales)
    });

    const formattedTotalSales = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 0,
        maximumFractionDigits: 0,
    }).format(stateProvinceSale.totalSales);

    const infoWindow = new google.maps.InfoWindow({
        content: `
            <div>
                <p><strong>State:</strong> ${stateProvinceSale.stateProvinceName}</p>
                <p><strong>Country:</strong> ${stateProvinceSale.countryRegionName}</p>
                <p><strong>Total Sales:</strong> ${formattedTotalSales}</p>
            </div>
        `
    });

    circle.addListener('click', () => {
        infoWindow.setPosition(circle.getCenter());
        infoWindow.open(distributionOfSalesMap);
    });

    return circle;
}

function calculateRadius(totalSales) {
    const zoomLevel = distributionOfSalesMap.getZoom();
    const adjustedScaleFactor = baseScaleFactor / Math.pow(1.5, zoomLevel - 2); // Adjust the scale factor based on zoom level
    const radius = Math.sqrt(totalSales) * adjustedScaleFactor;
    return radius;
}
