<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <h1 class="text-4xl text-slate-800 font-medium mb-14">Booking  #{{ booking.bookingId }} </h1>

            <div class="relative overflow-x-auto">
                <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                    <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                        <tr>
                            <th scope="col" class="px-6 py-3"></th>
                            <th scope="col" class="px-6 py-3">
                                Client Information
                            </th>
                            
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="odd:bg-white even:bg-gray-50 border-b">
                            <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Booked By
                            </th>
                            <td class="px-6 py-4">
                                {{booking.userName}}
                            </td>
                        </tr>
                        <tr class="odd:bg-white even:bg-gray-50 border-b">
                            <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Artist
                            </th>
                            <td class="px-6 py-4">
                                {{booking.artist}}
                            </td>
                        </tr>
                        <tr class="odd:bg-white even:bg-gray-50 border-b">
                            <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Date of Rehearsal
                            </th>
                            <td class="px-6 py-4">
                                {{booking.date}}
                            </td>
                        </tr>
                        <tr class="odd:bg-white even:bg-gray-50 border-b">
                            <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Phone Number
                            </th>
                            <td class="px-6 py-4">
                                {{booking.phoneNumber}}
                            </td>
                        </tr>
                        <tr class="odd:bg-white even:bg-gray-50 border-b">
                            <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Cost to Client
                            </th>
                            <td class="px-6 py-4">
                                R {{booking.price}}
                            </td>
                        </tr>
                        <tr class="odd:bg-white even:bg-gray-50 border-b">
                            <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Rehearsal Slots
                            </th>
                            <td class="px-6 flex justify-start items-center gap-3 py-4">
                                <div class="bg-blue-100 text-blue-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded dark:bg-gray-700 dark:text-blue-400 border border-blue-400" v-for="slot in slotNames">
                                    {{ slot }}
                                </div>
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
import { ref } from 'vue';
import { useRoute } from 'vue-router';
import authMiddleware from '~/middleware/auth'

export default{
    data() {
        return {
            booking: {},
            bookingSlots: [],
            slotNames: []
        }
    },
    setup(){
        const id = ref(useRoute().params.id)

        const setup = () => {
            definePageMeta({
                middleware: [authMiddleware]
            })
        }

        return {
            id,
            setup
        }
    },
    created(){
        this.getBooking()
    },
    methods: {
        async getBooking() {
            try{
                var response = await axios.get(`https://localhost:7179/api/Bookings/GetBooking/${this.id}`)
                //console.log(response.data)
                this.booking = response.data

                this.bookingSlots = this.booking.bookingSlots
                this.getSlots(this.bookingSlots)
            } catch(error) {
                console.log("Error getting booking: ", error.message)
            }
        },
         getSlots(slotArray) {
            slotArray.forEach(async (slot) => {
                //console.log(slot.slotId)

                try {
                    const response = await axios.get(`https://localhost:7179/api/Slot/GetSlot/${slot.slotId}`)
                    //console.log(response.data)
                    this.slotNames.push(response.data.time)

                } catch (error) {
                    console.log("Could not fetch this slot: ", error.message)
                }
            })

            console.log(this.slotNames)
        }
    }
}
</script>