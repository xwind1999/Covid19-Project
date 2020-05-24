var list = [];
$(document).ready(function () {
    var country = document.getElementById("country").value;
    $.ajax({
        type: 'GET',
        url: "https://api.covid19api.com/total/country/" + country,
        contentType: "application/json",
        dataType: 'json',
        success: function (result) {
            for (item of result) {
                var date = item.Date.slice(0, item.Date.indexOf("T"));
                list.push([new Date(date), item.Confirmed, item.Deaths, item.Recovered, item.Active]);
            }
            drawChart();
        }
    });
});

google.charts.load('current', { 'packages': ['line'] });

function drawChart() {
    var data = new google.visualization.DataTable();
    data.addColumn('date', 'Day');
    data.addColumn('number', 'Confirmed');
    data.addColumn('number', 'Deaths');
    data.addColumn('number', 'Recovered');
    data.addColumn('number', 'Active');
    data.addRows(list);
    var options = {
        height: 500,
        axes: {
            x: {
                0: { side: 'top' }
            }
        }
    };
    var chart = new google.charts.Line(document.getElementById('chart'));

    chart.draw(data, google.charts.Line.convertOptions(options));
}