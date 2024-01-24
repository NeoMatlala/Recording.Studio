<template>
    <div class="mt-10">
        <div v-for="booking in bookings">
            <div class="flex justify-between items-center">
                <div class="font-medium flex justify-start items-center gap-2">
                    <div class="relative w-6 h-6 overflow-hidden bg-gray-100 rounded-full dark:bg-gray-600">
                        <svg class="absolute w-8 h-8 text-gray-400 -left-1" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M10 9a3 3 0 100-6 3 3 0 000 6zm-7 9a7 7 0 1114 0H3z" clip-rule="evenodd"></path></svg>
                    </div>
                    <div class="text-sm text-gray-500 dark:text-gray-400">{{ booking.userName}}</div>
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
            bookings: []
        }
    },
    mounted(){
        this.getBookings()
    },
    methods: {
        async getBookings() {
            try{
                var response = await axios.get("https://localhost:7179/api/Bookings/GetAllBookings")
                console.log(response.data)
                console.log()

                for(var i = response.data.length - 1; i >= 5; i--) {
                    this.bookings.push(response.data[i])
                }

                console.log(this.bookings)

            } catch(error) {
                console.log("Error getting bookings: ", error.message)
            }
        }
    }
}

</script>