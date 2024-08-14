let distributionOfSalesMap;
let stateProvinceSales = [];
let circles = [];
const baseMaxRadius = 750000; // Base maximum radius for the largest circle
const baseMinRadius = 50000; // Base minimum radius for the smallest circle

export function initializeMap() {
    const distributionOfSalesMapElement = document.getElementById('distributionOfSalesMap');

    if (distributionOfSalesMapElement) {
        distributionOfSalesMap = new google.maps.Map(distributionOfSalesMapElement, {
            center: { lat: 15, lng: 5 },
            disableDoubleClickZoom: true,
            fullscreenControl: false,
            mapTypeControl: false,
            streetViewControl: false,
            zoomControl: false,
            zoom: 2
        });

        distributionOfSalesMap.addListener('zoom_changed', updateCircles);
    }
}

export function updateMap(stateProvinceSalesParam) {
    stateProvinceSales = [];

    for (const circle of circles) {
        circle.setMap(null);
    }

    circles = [];

    let maxSales = -Infinity;
    let minSales = Infinity;

    // Find the min and max sales values
    for (const stateProvinceSaleParam of stateProvinceSalesParam) {
        maxSales = Math.max(maxSales, stateProvinceSaleParam.sales);
        minSales = Math.min(minSales, stateProvinceSaleParam.sales);
    }

    for (const stateProvinceSaleParam of stateProvinceSalesParam) {
        stateProvinceSales.push(stateProvinceSaleParam);
        const circle = createCircle(stateProvinceSaleParam, minSales, maxSales);
        circles.push(circle);
    }
}

function updateCircles() {
    let maxSales = -Infinity;
    let minSales = Infinity;

    for (const stateProvinceSale of stateProvinceSales) {
        maxSales = Math.max(maxSales, stateProvinceSale.sales);
        minSales = Math.min(minSales, stateProvinceSale.sales);
    }

    for (const circle of circles) {
        const radius = calculateRadius(circle.sales, minSales, maxSales);
        circle.setRadius(radius);
    }
}

function createCircle(stateProvinceSale, minSales, maxSales) {
    const circle = new google.maps.Circle({
        strokeColor: '#FF0000',
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: '#FF0000',
        fillOpacity: 0.35,
        map: distributionOfSalesMap,
        center: { lat: stateProvinceSale.latitude, lng: stateProvinceSale.longitude },
        sales: stateProvinceSale.sales,
        radius: calculateRadius(stateProvinceSale.sales, minSales, maxSales)
    });

    const formattedSales = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2,
        maximumFractionDigits: 2,
    }).format(stateProvinceSale.sales);

    const infoWindow = new google.maps.InfoWindow({
        content: `
            <div>
                <p><strong>State:</strong> ${stateProvinceSale.stateProvinceName}</p>
                <p><strong>Country:</strong> ${stateProvinceSale.countryRegionName}</p>
                <p><strong>Sales:</strong> ${formattedSales}</p>
            </div>
        `
    });

    circle.addListener('click', () => {
        infoWindow.setPosition(circle.getCenter());
        infoWindow.open(distributionOfSalesMap);
    });

    return circle;
}

function calculateRadius(sales, minSales, maxSales) {
    if (minSales === maxSales) {
        return baseMaxRadius / 2; // In case all sales are equal, return a fixed medium size
    }

    const zoomLevel = distributionOfSalesMap.getZoom();
    const adjustedMaxRadius = baseMaxRadius / Math.pow(1.5, zoomLevel - 2); // Adjust max radius based on zoom level
    const adjustedMinRadius = baseMinRadius / Math.pow(1.5, zoomLevel - 2); // Adjust min radius based on zoom level

    // Normalize the sales value to a range between adjustedMinRadius and adjustedMaxRadius
    const radius = ((sales - minSales) / (maxSales - minSales)) * (adjustedMaxRadius - adjustedMinRadius) + adjustedMinRadius;

    return radius;
}
