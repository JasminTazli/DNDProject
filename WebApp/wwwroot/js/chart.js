async function fetchData() {
    const edataResponse = await fetch('api/edata');
    const greenHouseResponse = await fetch('api/greenhouse');
    const waterResponse = await fetch('api/water');
    const wasteResponse = await fetch('api/waste');

    if (!edataResponse.ok || !greenHouseResponse.ok || !waterResponse.ok || !wasteResponse.ok) {
        console.error('Failed to fetch data from API');
        return;
    }

    const edataList = await edataResponse.json();
    const greenHouseList = await greenHouseResponse.json();
    const waterList = await waterResponse.json();
    const wasteList = await wasteResponse.json();

    drawCharts(edataList, greenHouseList, waterList, wasteList);
}

function drawCharts(edataList, greenHouseList, waterList, wasteList) {
    const edataLabels = edataList.map(e => new Date(e.Year).getFullYear());
    const greenHouseLabels = greenHouseList.map(g => new Date(g.Year).getFullYear());
    const waterLabels = waterList.map(w => new Date(w.Year).getFullYear());
    const wasteLabels = wasteList.map(w => new Date(w.Year).getFullYear());

    const totalEnergyData = edataList.map(e => e.TotalEnergy);
    const crudeFuelData = edataList.map(e => e.CrudeFuel);
    const gasFuelData = edataList.map(e => e.GasFuel);
    const purchElecData = edataList.map(e => e.PurchElec);
    const renewEnergyData = edataList.map(e => e.RenewEnergy);
    const fossilEnergyData = edataList.map(e => e.FossilEnergy);

    const scope12MarketData = greenHouseList.map(g => g.scope12Market);
    const scope12LocationData = greenHouseList.map(g => g.scope12location);
    const scope3SoldProductsData = greenHouseList.map(g => g.scope3soldproducts);

    const waterConsumptionData = waterList.map(w => w.WaterConsumption);
    const waterRecycledData = waterList.map(w => w.WaterRecycled);

    const totalWasteData = wasteList.map(w => w.TotalWaste);

    new Chart(document.getElementById('totalEnergyChart').getContext('2d'), createPieChartConfig('Total Energy Consumption', edataLabels, totalEnergyData));
    new Chart(document.getElementById('crudeFuelChart').getContext('2d'), createPieChartConfig('Crude Fuel', edataLabels, crudeFuelData));
    new Chart(document.getElementById('gasFuelChart').getContext('2d'), createPieChartConfig('Gas Fuel', edataLabels, gasFuelData));
    new Chart(document.getElementById('purchElecChart').getContext('2d'), createPieChartConfig('Purchased Electricity', edataLabels, purchElecData));
    new Chart(document.getElementById('renewEnergyChart').getContext('2d'), createPieChartConfig('Renewable Energy', edataLabels, renewEnergyData));
    new Chart(document.getElementById('fossilEnergyChart').getContext('2d'), createPieChartConfig('Fossil Energy', edataLabels, fossilEnergyData));

    new Chart(document.getElementById('scope12MarketChart').getContext('2d'), createPieChartConfig('Scope 1 and 2 Market-based', greenHouseLabels, scope12MarketData));
    new Chart(document.getElementById('scope12LocationChart').getContext('2d'), createPieChartConfig('Scope 1 and 2 Location-based', greenHouseLabels, scope12LocationData));
    new Chart(document.getElementById('scope3SoldProductsChart').getContext('2d'), createPieChartConfig('Scope 3 Sold Products', greenHouseLabels, scope3SoldProductsData));

    new Chart(document.getElementById('waterConsumptionChart').getContext('2d'), createPieChartConfig('Water Consumption', waterLabels, waterConsumptionData));
    new Chart(document.getElementById('waterRecycledChart').getContext('2d'), createPieChartConfig('Water Recycled', waterLabels, waterRecycledData));
    new Chart(document.getElementById('totalWasteChart').getContext('2d'), createPieChartConfig('Total Waste', wasteLabels, totalWasteData));

    // Add new graphs in the middle column
    new Chart(document.getElementById('edataGraph').getContext('2d'), createLineChartConfig('Energy Consumption', edataLabels, totalEnergyData));
    new Chart(document.getElementById('greenhouseGraph').getContext('2d'), createLineChartConfig('Greenhouse Gas (GHG) Emissions', greenHouseLabels, scope12MarketData));
    new Chart(document.getElementById('waterGraph').getContext('2d'), createLineChartConfig('Resource Consumption', waterLabels, waterConsumptionData));
}

function createPieChartConfig(label, labels, data) {
    return {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: label,
                data: data,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            plugins: {
                title: {
                    display: true,
                    text: label
                }
            }
        }
    };
}

function createLineChartConfig(label, labels, data) {
    return {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: label,
                data: data,
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderWidth: 1
            }]
        },
        options: {
            plugins: {
                title: {
                    display: true,
                    text: label
                }
            },
            scales: {
                x: {
                    beginAtZero: true
                },
                y: {
                    beginAtZero: true
                }
            }
        }
    };
}

fetchData();