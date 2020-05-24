google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

// Draw the chart and set the chart values
function drawChart() {
    var confirmed = parseInt(document.getElementById("totalConfirmed").innerHTML);
    var deaths = parseInt(document.getElementById("totalDeaths").innerHTML);
    var recovered = parseInt(document.getElementById("totalRecovered").innerHTML);
    var data = google.visualization.arrayToDataTable([
        ['Statistic', 'Status'],
        ['Recovered', recovered],
        ['Death', deaths],
        ['Active', confirmed - deaths - recovered],
    ]);

    // Optional; add a title and set the width and height of the chart
    var options = { 'title': 'Statistic', 'width': 'auto', 'height': 'auto', 'colors': ['#337AB7', '#666666','#FF9C00'] };

    // Display the chart inside the <div> element with id="piechart"
    var chart = new google.visualization.PieChart(document.getElementById('chart'));
    chart.draw(data, options);
}