<template>
  <apexchart
    width="100%"
    height="350"
    type="line"
    :options="chartOptions"
    :series="series"
  ></apexchart>
</template>

<script>


export default{
    setup() {
        const chartOptions = {
            chart: {
              height: 350,
              type: 'line',
              zoom: {
                enabled: false
              }
            },
            dataLabels: {
              enabled: false
            },
            stroke: {
              curve: 'straight'
            },
            grid: {
              row: {
                colors: ['#fcfcfc', 'transparent'], // takes an array which will be repeated on columns
                opacity: 0.5
              },
            },
            xaxis: {
              categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            }
        };

        const series = [
            {
                name: "Bookings",
                data: [24,10,41,3,15,12,12,32,10,20,9,12],
            },
        ];

        return {
            chartOptions,
            series
        }
    }
}

</script>
