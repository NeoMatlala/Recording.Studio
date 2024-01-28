<template>
    <div class="mt-10">
        <div v-for="booking in bookingWithImage">
            <div class="flex justify-between items-center">
                <div class="flex justify-start items-center gap-4">
                    <div class="relative w-8 h-8 overflow-hidden bg-gray-100 rounded-full dark:bg-gray-600">
                        <img class="w-full h-full rounded-full" :src="booking.imageUrl" alt="">
                    </div>
                    <div class="font-medium dark:text-white">
                        <div>{{ booking.artist }}</div>
                        <div class="text-sm text-gray-500 dark:text-gray-400">{{ booking.userName}}</div>
                    </div>
                </div>
                
                <div class="w-1/4 flex justify-end">
                    <h3 class="font-medium text-lg">R {{ booking.price}}</h3>
                </div>
            </div>
            <hr class="my-5 border-gray-200 sm:mx-auto" />
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    data() { 
        return{
            bookings: [],
            bookingWithImage: []
        }
    },
    mounted(){
        this.getBookings()
    },
    methods: {
        async getBookings() {
            try{
                var response = await axios.get("https://localhost:7179/api/Bookings/GetAllBookings")

                for(var i = Math.max(0, response.data.length - 5); i < response.data.length; i++) {
                    this.bookings.push(response.data[i])
                }

                this.bookingWithImage = this.bookings.map(booking => {
                    var randomNumber = Math.floor(Math.random() * (999 - 100 + 1)) + 100
                    var imageUrl = `https://ozgrozer.github.io/100k-faces/0/0/000${randomNumber}.jpg`

                    return {...booking, imageUrl: imageUrl}
                })

            } catch(error) {
                console.log("Error getting bookings: ", error.message)
            }
        }
    }
}

</script>