function CreateBarChart(departments, data, colors) {

    new Chart(document.getElementById("bar-chart"),
        {
            type: 'bar',
            data:
            {
                labels: departments,
                datasets:
                    [
                        {
                            label: "Popularity",
                            backgroundColor: "#f7550d",
                            data: data,
                            borderWidth: 1
                        }
                    ]
            },
            options:
            {
                legend: { display: false },
                devicePixelRatio: 4,
                responsive: true,
                maintainAspectRatio: false,
                title:
                {
                    display: true,
                    text: ''
                },

                scales:
                {
                    yAxes:
                        [{
                            scaleLabel:
                            {
                                display: true,
                                labelString: 'Popularity',
                                color: '#000000'
                            },
                            ticks: {
                                beginAtZero: true,
                                fontSize: 12
                            }
                        }],

                    xAxes:
                        [{
                            scaleLabel:
                            {
                                display: true,
                                labelString: 'Department',
                                color: '#000000'
                            }
                        }]
                }
            }
        });
}
function CreateRingChart(departments, data, colors) {
    new Chart(document.getElementById("ring-chart"),
        {
            type: 'doughnut',
            data:
            {
                labels: departments,
                datasets:
                    [
                        {
                            label: "Popularity",
                            backgroundColor: colors,
                            data: data,
                            hoverOffset: 4
                        }
                    ]
            },
            options:
            {
                plugins:{
                    legend: {
                        display: true,
                        position: "right",
                        align: "center"
                    }
                },
                devicePixelRatio: 4,
                responsive: true,
                maintainAspectRatio: false,
                title:
                {
                    display: true,
                    text: ''
                }
            }
        });
}