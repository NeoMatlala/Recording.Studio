<template>
    <div class="max-w-7xl mx-auto px-4 md:px-0">
        <div class="mt-28 mb-10">
            <NuxtLink @click="previousPage" class="mb-10 text-sm hover:text-base cursor-pointer underline underline-offset-1">Back</NuxtLink>
            <h1 class="text-4xl md:text-5xl mt-10 font-medium">Update booking</h1>
        </div>

        <div class="flex flex-col md:flex-row justify-between gap-5 items-center">
            <div class="w-full md:w-1/3">
                <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Band or Artist name</label>
                <input type="text" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" v-model="booking.artist" placeholder="Band Of Neo" required>
            </div>
            <div class="w-full md:w-1/3">
                <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Contact number</label>
                <input type="text" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" v-model="booking.phoneNumber" placeholder="0721235698" required>
            </div>
            <div class="w-full md:w-1/3">
                <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Rehearsal date</label>
                <!-- <input type="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="select date" required> -->
                <VueDatePicker v-model="booking.date" :enable-time-picker="false"></VueDatePicker>
            </div>
        </div>

        <div class="flex flex-col md:flex-row justify-between items-start gap-10 mt-16">
            <div class="w-full md:w-2/3">
                <h1 class="font-medium text-4xl mb-2">02 Jan</h1>
                <h6 class="font-light text-4xl mb-10">Tuesday</h6>

                <div class="grid grid-cols-1 md:grid-cols-3  gap-4">
                    <div v-for="slot in slots"
                     :key="slot.id"
                     @click="toggleSlot(slot, slotSelected)"
                     class="bg-slate-100 text-slate-500 rounded-md cursor-pointer p-6"
                     :class="{'bg-slate-400 text-black': slot.selected, 'bg-slate-100 text-black': !slot.selected}"
                    >
                        <p class="text-center">
                            {{slot.time}}
                        </p>
                    </div>
                </div>

                <div class="flex items-start mt-10">
                    <div class="flex items-center h-5">
                    <input id="remember" type="checkbox" value="" class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:focus:ring-offset-gray-800" required>
                    </div>
                    <label for="remember" class="ms-2 text-sm font-light text-gray-900 dark:text-gray-300">
                        I agree to  R&R studio' <span class="hover:underline">Terms of Service</span> and <span class="hover:underline">Privacy Policy</span>.
                    </label>
                </div>
            </div>

            <!-- price  -->
            <div class="p-5 border border-slate-200 rounded-md w-full md:w-1/3" >
                <h1 class="font-medium text-3xl">R {{total}}</h1>
                <p class="mt-5 mb-16 font-light text-slate-500">
                    Our slots are two(2) hour slots
                </p>

                <button type="submit" class="text-black bg-yellow-300 hover:bg-yellow-400 focus:ring-2 focus:outline-none focus:ring-yellow-400 font-medium rounded-lg text-base w-full  px-5 py-2.5 mt-5 text-center" @click="updateRehearsal">Update Booking</button>

                <hr class="my-6 border-gray-200 sm:mx-auto lg:my-8" />

                <!-- <div class="flex mb-8 justify-between items-center">
                    <p>R450 x 3 slots</p>
                    <p>{{total}}</p>
                </div> -->
            </div>

        </div>
    </div>
</template>

<script>
import axios from 'axios';
import { ref } from 'vue';
import { useRoute } from 'vue-router';
import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css'

export default{
    data() {
        return {
            booking: {},
            slots: [],
            total: 0,
            selectedSlotIds: [],
            responseBookingSlots: [],
            updatedBooking: {
                userId: '',
                artist: '',
                date: '',
                phoneNumber: '',
                price: '',
                slotIds: []
            }
        }
    },
    components: { 
        VueDatePicker 
    },
    setup() {
        const id = ref(useRoute().params.id)
        const date = ref(new Date());

        const format = (date) => {
            const day = date.getDate();
            const month = (date.getMonth() + 1).toString().padStart(2, '0');
            const year = date.getFullYear();

            return `${year}-${month}-${day}`;
        }

        return {
            id,
            date,
            format
        }
    },
    mounted() {
        Promise.all([this.fetchSlots(), this.getBooking()]).then(() => {
            //const preSelectedSlotIds = [5, 6];
            //this.selectedSlotIds = preSelectedSlotIds
            this.selectedSlotIds = this.responseBookingSlots;

            // Set slot.selected based on pre-selected slotIds
            this.slots.forEach((slot) => {
                slot.selected = this.selectedSlotIds.includes(slot.slotId);
            });

            this.calculateTotalAndBooking();
        });
    },
    methods: {
        async getBooking() {
            try{
                var response = await axios.get(`https://localhost:7179/api/Bookings/get-booking/${this.id}`)
                //console.log(response.data)
                this.booking = response.data

                this.booking.bookingSlots.forEach(slot =>{
                    this.responseBookingSlots.push(slot.slotId)
                })
                
            } catch(error) {
                console.log("Error getting booking: ", error.message)
            }
        },
        async fetchSlots() {
            try {
                const response = await axios.get("https://localhost:7179/api/Slot/get-slots")
                //console.log(response.data)
                this.slots = response.data

            } catch (error) {
                console.log("Could not fetch slots: ", error.message)
            }
            
        },
        toggleSlot(slot) {
            const price = parseInt(slot.price, 10);

            if (slot.selected) {
                this.total -= price;
                this.booking.slotIds = this.booking.slotIds.filter(
                (slotId) => slotId !== slot.slotId
                );
                this.selectedSlotIds = this.selectedSlotIds.filter(
                (selectedSlotId) => selectedSlotId !== slot.slotId
                );
            } else {
                this.showPrice = true;
                this.total += price;
                this.booking.slotIds.push(slot.slotId);
                this.selectedSlotIds.push(slot.slotId);
            }

            slot.selected = !slot.selected;
            //console.log(this.selectedSlotIds)
        },
        calculateTotalAndBooking() {
            this.total = this.slots.reduce((acc, slot) => {
            if (this.selectedSlotIds.includes(slot.slotId)) {
                return acc + parseInt(slot.price, 10);
                }
                return acc;
            }, 0);

            this.booking.slotIds = [...this.selectedSlotIds];
        },
        async updateRehearsal(){
            const correctDateFormat = this.format(this.date);

            //console.log(this.total)

            this.booking.date = correctDateFormat
            //this.booking.userId = localStorage.getItem('varchar')
            // this.booking.price = this.total

            this.updatedBooking.artist = this.booking.artist
            this.updatedBooking.date = this.booking.date
            this.updatedBooking.phoneNumber = this.booking.phoneNumber
            this.updatedBooking.price = this.total
            this.updatedBooking.userId = this.booking.userId
            this.updatedBooking.slotIds = this.selectedSlotIds

            //console.log(this.updatedBooking)

            try{
                const response = await axios.post(`https://localhost:7179/api/Bookings/update-booking/${this.booking.bookingId}`, this.updatedBooking)
                console.log(response.data)
                this.$router.replace(`/manage-bookings/view/${this.booking.bookingId}`)
            } catch (error) {
                console.log("Error creating employee: ", error.message);

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

            

            //console.log(this.booking)
        },
        previousPage(){
            this.$router.go(-1)
        }
    }
}
</script>