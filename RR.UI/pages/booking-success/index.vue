<template>
    <div class="flex flex-col items-center justify-center">
        <h1 class="mb-5 text-lg font-normal text-gray-5000">You have successfully booked your rehearsal space</h1>
        <div class="flex items-center justify-center gap-x-5">
            <NuxtLink to="/manage-bookings" type="submit" class="text-black bg-yellow-300 hover:bg-yellow-400 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm inline-flex items-center px-5 py-2.5 text-center me-2 mb-5 md:mb-0">
                See active bookings
            </NuxtLink>
            <NuxtLink to="/" type="button" class="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Take me to homepage</NuxtLink>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    async mounted() {
        const bookingObject = localStorage.getItem('bookingObject')

        const parsedBooking = bookingObject ? JSON.parse(bookingObject) : null

        //console.log(parsedBooking)

        try {
            const response = await axios.post("https://localhost:7179/api/Bookings/CreateBooking", parsedBooking)
            console.log(response.data)
        } catch (error) {
            if (error.response) {
                // The request was made and the server responded with a status code
                // that falls out of the range of 2xx
                console.error("Request failed with status code:", error.response.status);
                console.error("Response data:", error.response.data);
                console.error("Headers:", error.response.headers);
            } else if (error.request) {
                // The request was made but no response was received
                console.error("No response received. Request made but no response.");
                console.error("Request details:", error.request);
            } else {
                // Something happened in setting up the request that triggered an Error
                console.error("Error setting up the request:", error.message);
            }
            console.error("Full error object:", error);
        }
        
    }
}
</script>