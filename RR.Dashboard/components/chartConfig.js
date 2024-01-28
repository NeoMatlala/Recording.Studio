export const data = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'December'],
    datasets: [
      {
        backgroundColor: '#f87979',
        data: [40, 39, 10, 40, 39, 80, 40, 10, 40, 39, 80, 40],
        borderColor: '#3f83f8',
        pointBackgroundColor: '#3f83f8',
        tension: 0.4
      }
    ]
  }
  
  export const options = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: {
        legend: {
            display: false
        }
    }
  }
  