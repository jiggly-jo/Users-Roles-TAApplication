var chart = new Highcharts.chart('container',{
    title: {
        text: 'Enrollments Over Time'
    },

    subtitle: {
        text: { text: 'Enrollments Over Time' },
    },

    yAxis: {
        title: {
            text: 'Students'
        }
    },

    xAxis: {
        title: { text: 'Dates' },
        type: 'datetime'
    },

    legend: {
        layout: 'vertical',
        align: 'right',
        verticalAlign: 'middle'
    },

    plotOptions: {
        series: {
            label: {
                connectorAllowed: false
            },
            pointStart: 0
        }
    },


    responsive: {
        rules: [{
            condition: {
                maxWidth: 500
            },
            chartOptions: {
                legend: {
                    layout: 'horizontal',
                    align: 'center',
                    verticalAlign: 'bottom'
                }
            }
        }]
    }
});

$('#myBtn').click(function () {
    var startdate = document.getElementById("inputDate").value;
    var enddate = document.getElementById("inputEndDate").value;
    var course = $("#selectCourse option:selected").text();
    var URL = "/Admin/GetEnrollmentData";
    var DATA = { startDate: startdate, endDate: enddate, course: course };

    $.post(URL, DATA)
        .done(function (result) {
            //2021-11-15
            let info = [];
            for (i = 0; i < result.length; i += 2) {
                var year = result[i].substring(0, 4);
                var month = result[i].substring(5, 7);
                var day = result[i].substring(8, 10);
                var intyear = parseInt(year);
                var intmonth = parseInt(month)-1;
                var intday = parseInt(day);
                info.push([Date.UTC(intyear, intmonth, intday), parseInt(result[i + 1])]);
            }
            chart.addSeries({
                name: course,
                data: info
            });
            Swal.fire(
                'Edit Sucessful!',
                '',
                'success'
            )
 
        })
        .fail(function (result) {
            Swal.fire(
                'Edit Failed!',
                '',
                'error'
            )
        })
        .always(function () {
            $("aspinner").hide();
        });


});

