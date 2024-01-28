<template>
    <div class="max-w-7xl mx-auto px-4 md:px-0">
        <div class="flex flex-col mt-28 items-center bg-white border border-gray-200 rounded-lg gap-x-10 md:flex-row">
            <div class="w-full md:w-1/2">
                <img class="object-cover w-full rounded-t-lg h-44 md:h-96 md:rounded-none md:rounded-s-lg" src="../../../assets/img/view-booking-img.jpg" alt="">
            </div>
            <div class="relative overflow-x-auto w-full mt-5 md:mt-0 md:w-1/2">
                <h5 class="md:px-5 px-2 mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">Booking info</h5>
                <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                    <tbody>
                        <tr class="border-b">
                            <th scope="row" class="px-3 md:px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Artist
                            </th>
                            <td class="px-3 md:px-6 py-4">
                                {{booking.artist}}
                            </td>
                        </tr>
                        <tr class="border-b">
                            <th scope="row" class="px-3 md:px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Date of Rehearsal
                            </th>
                            <td class="px-3 md:px-6 py-4">
                                {{booking.date}}
                            </td>
                        </tr>
                        <tr class="border-b">
                            <th scope="row" class="px-3 md:px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Phone Number
                            </th>
                            <td class="px-3 md:px-6 py-4">
                                {{booking.phoneNumber}}
                            </td>
                        </tr>
                        <tr class="border-b">
                            <th scope="row" class="px-3 md:px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Costs
                            </th>
                            <td class="px-3 md:px-6 py-4">
                                R {{booking.price}}
                            </td>
                        </tr>
                        <tr class="border-b">
                            <th scope="row" class="px-3 md:px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                Rehearsal Slots
                            </th>
                            <td class="px-3 md:px-6 flex flex-col md:flex-row justify-start items-center gap-3 py-4">
                                <div class="bg-blue-100 text-blue-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded dark:bg-gray-700 dark:text-blue-400 border border-blue-400" v-for="slot in slotNames">
                                    {{ slot }}
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="flex justify-end items-center gap-x-1 mt-5">
                    <NuxtLink :to="`/manage-bookings/update/${booking.bookingId}`" class="text-blue-700  hover:text-white border border-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-md text-xs px-5 py-2.5 text-center me-2 mb-2 dark:border-blue-500 dark:text-blue-500 dark:hover:text-white dark:hover:bg-blue-500 dark:focus:ring-blue-800">Update</NuxtLink>
                    <button id="button" class="text-red-700 hover:text-white border border-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-md text-xs px-5 py-2.5 text-center me-2 mb-2 dark:border-red-500 dark:text-red-500 dark:hover:text-white dark:hover:bg-red-600 dark:focus:ring-red-900">Delete</button>
                </div>
            </div>
        </div>

        <!-- delete modal -->
        <div id="popup-modal" tabindex="-1" class="hidden overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full">
            <div class="relative p-4 w-full max-w-md max-h-full">
                <div class="relative bg-white rounded-lg shadow">
                    <div class="p-4 md:p-5 text-center">
                        <svg class="mx-auto mb-4 text-gray-400 w-12 h-12" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 11V6m0 8h.01M19 10a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"/>
                        </svg>
                        <h3 class="mb-5 text-lg font-normal text-gray-5000">Are you sure you want to delete this rehearsal booking ?</h3>
                        <button type="submit" @click="deleteBooking" class="text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm inline-flex items-center px-5 py-2.5 text-center me-2">
                            Yes, I'm sure
                        </button>
                        <button id="closeButton" type="button" class="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">No, cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import { ref } from 'vue';
import { useRoute } from 'vue-router';
import { onMounted } from 'vue'
import { Modal } from 'flowbite'

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

        onMounted(() => {
            const $buttonElement = document.querySelector('#button');
            const $modalElement = document.querySelector('#popup-modal');
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }
            if ($modalElement) {
                const modal = new Modal($modalElement, modalOptions);
                $buttonElement.addEventListener('click', () => modal.toggle());
                $closeButton.addEventListener('click', () => modal.hide());
            }
        })

        return {
            id
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
        },
        async deleteBooking() {
            const $modalElement = document.querySelector('#popup-modal');
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }

            try {
                if ($modalElement) {
                    const modal = new Modal($modalElement, modalOptions);
                    $closeButton.addEventListener('click', () => modal.hide());
                }

                const response = await axios.delete(`https://localhost:7179/api/Bookings/DeleteBooking/${this.id}`)
                console.log(response.data)
                this.$router.replace("/manage-bookings")
            } catch (error) {
                console.log("Error deleting booking:", error.message)
            }
        }
    }
}
</script>