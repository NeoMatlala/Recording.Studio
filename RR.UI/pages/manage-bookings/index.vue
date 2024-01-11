<template>
    <div class="flex justify-center items-center">
        <div class="max-w-7xl mx-auto w-2/3">
            <h1 class="text-center text-7xl mb-16 font-medium">Manage bookings</h1>

            <div class="max-w-2xl mb-60 mx-auto flex justify-between items-center gap-5">
                <NuxtLink class="bg-slate-200 hover:bg-slate-300 w-1/2 p-6 h-60 ">
                    <h1 class="text-3xl font-medium">Book Rehearsal space</h1>
                    <p class="mt-4 font-light text-slate-500">
                        Perfect your performance in our state-of-the-art rehearsal spaces designed to amplify your musical potential.
                    </p>
                </NuxtLink>
                <NuxtLink class="bg-slate-200 hover:bg-slate-300 w-1/2 p-6 h-60 ">
                    <h1 class="text-3xl font-medium">Book Recording Equipment</h1>
                    <p class="mt-4 font-light text-slate-500">
                        Elevate your music journey—book recording sessions and achieve sonic perfection through our expert mixing and mastering services.
                    </p>
                </NuxtLink>
            </div>
        </div>
    </div>
</template>

<script>

import axios from 'axios';

export default{
    data() {
        return {
           weatherData: [] 
        }
    },
    async mounted() {
        const authToken = localStorage.getItem('token');

        try {
            var response = await axios.get("https://localhost:7179/WeatherForecast", {
                headers: {
                    Authorization: `Bearer ${authToken}`
                }
            })
            this.weatherData = response.data;
        } catch(error) {
            console.log("Error creating employee: ", error.message);
            if (error.response) {
                // The request was made and the server responded with a status code
                // that falls out of the range of 2xx
                console.log("Server response data:", error.response.data);
                console.log("Status code:", error.response.status);
            } else if (error.request) {
                // The request was made but no response was received
                console.log("No response received from the server");
            } else {
                // Something happened in setting up the request that triggered an Error
                console.log("Error:", error.message);
            }
        }
    }
}
</script>