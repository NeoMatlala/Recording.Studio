<template>
    <div class="flex justify-center items-center">
        <div class="max-w-7xl w-full mx-auto">

            <div>
                <div class="flex mt-8 justify-between items-center">
                    <h1 class="text-4xl font-medium">Active rehearsal bookings</h1>
                    <NuxtLink to="/book-rehearsal" class="underline">Make new booking</NuxtLink>
                </div>
                
                <div class="mx-auto flex justify-start items-center gap-5 mt-10">
                    <!-- <div v-for="slot in slots" class="bg-slate-100 w-1/2 p-6 ">
                        <h1 class="text-3xl font-medium">{{slot.artist}}</h1>
                        <p class="my-4">R {{ slot.price }}</p>
                        <p class=" font-light">Date: {{ slot.date }}</p>
                        <div class="flex justify-end mt-10">
                            <NuxtLink :to="`manage-bookings/view/${slot.bookingId}`" class="hover:underline">View booking</NuxtLink>
                        </div>
                        
                        

                        TODO: display dlots and figure out UI for active bookings
                        <div class="px-6 flex justify-start items-center gap-3 py-4">
                            <div class="bg-blue-100 text-blue-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded dark:bg-gray-700 dark:text-blue-400 border border-blue-400" v-for="slot in slot.bookingSlots">
                                {{ slot }}
                            </div>
                        </div>
                    </div> -->

                    <div  v-for="slot in slots" class="max-w-sm bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700">
                        <a>
                            <img class="rounded-t-lg" src="../../assets/img/view-booking-img.jpg" alt="" />
                        </a>
                        <div class="p-5">
                            <h5 class="mb-2 text-2xl font-medium tracking-tight text-gray-900 dark:text-white">{{slot.artist}}</h5>
                            <p class="mb-3 font-normal text-gray-800 dark:text-gray-400">R {{ slot.price }}</p>
                            <p class="mb-3 font-normal text-gray-600 dark:text-gray-400">Date: {{ slot.date }}</p>
                            <div class="flex justify-end mt-10">
                            <NuxtLink :to="`manage-bookings/view/${slot.bookingId}`" class="underline">View booking</NuxtLink>
                        </div>
                        </div>
                    </div>

                </div>
            </div>

            <div v-if="showBookingMenu">
                <h1 class="text-7xl text-center font-medium mb-16">Manage bookings</h1>
                <div class="max-w-2xl mx-auto flex justify-between items-center gap-5">
                    <NuxtLink to="/book-rehearsal" class="bg-slate-200 hover:bg-slate-300 w-1/2 p-6 h-60 ">
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
    </div>
</template>

<script>
//import { definePageMeta } from 'nuxt'
import axios from 'axios';
import authMiddleware from '~/middleware/auth'

export default {
    data() {
        return {
            slots: [],
            bookingSlots: [],
            slotNames: [],
            showBookingMenu: true
        }
    },
    setup() {
        const setup = () => {
        definePageMeta({
            //layout: 'bookings',
            middleware: [
            authMiddleware
            ]
        })
        }

        return {
        setup
        }
    },
    created() {
        this.fetchActiveBookings()
    },
    methods: {
        async fetchActiveBookings() {
            const userId = localStorage.getItem('varchar')

            try {
                const response = await axios.get(`https://localhost:7179/api/Bookings/GetBookingsForId/${userId}`)
                //console.log(response.data)

                this.slots = response.data

                if(this.slots.length > 0) {
                    this.showBookingMenu = false
                }
                
                //console.log(this.slots)

            } catch (error) {
                console.log("Could not fetch user's slots: ", error.message)

                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    console.log("Server response data:", error.response.data);
                    // this.errorDisplay = true
                    // this.errorMessage = error.response.data.message
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
}
</script>
