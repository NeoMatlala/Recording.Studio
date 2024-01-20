<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <h1 class="text-4xl text-slate-800 font-medium mb-14">Bookings</h1>

            <div class="relative overflow-x-auto mb-10">
                <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                    <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                        <tr>
                            <th scope="col" class="px-6 py-3">
                                Artist/Band
                            </th>
                            <th scope="col" class="px-6 py-3">
                                Date
                            </th>
                            <th scope="col" class="px-6 py-3">
                                Cost To Client
                            </th>
                            <th scope="col" class="px-6 py-3"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="odd:bg-white even:bg-gray-50 border-b" v-for="booking in bookings" :key="booking.bookingId">
                            <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                {{booking.artist}}
                            </th>
                            <td class="px-6 py-4">
                                {{booking.date}}
                            </td>
                            <td class="px-6 py-4">
                                R {{booking.price}}
                            </td>
                            <td class="px-6 py-4 space-x-5">
                                <NuxtLink :to="`bookings/view/${booking.bookingId}`" class="font-medium text-blue-600 hover:underline">View Booking</NuxtLink>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    data() {
        return {
            bookings: []
        }
        
    },
    setup(){
        const config = useRuntimeConfig()
        return {
            baseApi: config.public.apiBase
        }
    },
    created(){
        this.getBookings()
    },
    methods: {
        async getBookings() {
            try{
                //var response = await axios.get(`${this.baseApi}/api/Employee`);
                var response = await axios.get("https://localhost:7179/api/Bookings/GetAllBookings")
                //console.log(response.data)
                this.bookings = response.data
            } catch(error) {
                console.log("Error getting bookings: ", error.message)
            }
        }
    }
}
</script>