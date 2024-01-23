<template>
    <div class="max-w-7xl mx-auto">
        <h1 class="text-5xl mt-16 mb-10 font-medium">Select available slot</h1>

        <div class="flex justify-between gap-x-5 items-center">
            <div class="w-1/3 min-h-24">
                <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Band or Artist name</label>
                <input type="text" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" v-model="booking.artist" placeholder="Band Of Neo" required>
                <small v-if="showBandValidationError" class="text-red-500">Band or artist name is required</small>
            </div>
            <div class="w-1/3 min-h-24">
                <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Contact number</label>
                <input type="text" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" v-model="booking.phoneNumber" placeholder="0721235698" required>
                <small v-if="showContactNumberValidationError" class="text-red-500">Contact number is required</small>
            </div>
            <div class="w-1/3 min-h-24">
                <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Rehearsal date</label>
                <!-- <input type="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="select date" required> -->
                <VueDatePicker v-model="date" :enable-time-picker="false"></VueDatePicker>
                <small v-if="showDateValidationError" class="text-red-500">Rehearsal date is required</small>
            </div>
        </div>

        <div class="flex justify-between items-start gap-10 mt-10">
            
            <!-- slots  -->
            <div class="w-2/3" v-if="date">
                <h1 class="font-medium text-4xl mb-2">{{ formattedDateObj.day }} {{ formattedDateObj.selectedMonthName }}</h1>
                <h6 class="font-light text-4xl mb-10">{{ formattedDateObj.dayOfWeek }}</h6>

                <p v-if="slotsValidationError" class="text-red-500 mb-3">Selecting a slot is required</p>
                <div class="grid grid-cols-3  gap-4">
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

                <div>
                    <div class="flex items-start mt-10 mb-">
                        <div class="flex items-center h-5">
                            <input id="remember" type="checkbox" value="" class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:focus:ring-offset-gray-800" v-model="acceptTsCs" required>
                        </div>
                        <label for="remember" class="ms-2 text-sm font-light text-gray-900 dark:text-gray-300">
                            I agree to  R&R studio' <span class="hover:underline">Terms of Service</span> and <span class="hover:underline">Privacy Policy</span>.
                        </label>
                    </div>
                    <small v-if="checkValidationError" class="text-red-500">Selecting T's and C's is required</small>
                </div>
                
            </div>

            <!-- price  -->
            <div v-if="showPrice" class="p-5 border border-slate-200 rounded-md w-1/3" >
                <h1 class="font-medium text-3xl">R {{total}}</h1>
                <p class="mt-5 mb-16 font-light text-slate-500">
                    Our slots are two(2) hour slots
                </p>

                <button id="button" type="submit" class="text-black bg-yellow-300 hover:bg-yellow-400 focus:ring-2 focus:outline-none focus:ring-yellow-400 font-medium rounded-lg text-base w-full  px-5 py-2.5 mt-5 text-center" @click="bookRehearsal">Book</button>

                <hr class="my-6 border-gray-200 sm:mx-auto lg:my-8" />

                <!-- <div class="flex mb-8 justify-between items-center">
                    <p>R450 x 3 slots</p>
                    <p>{{total}}</p>
                </div> -->
            </div>
        </div>

        <!-- success modal -->
        <div id="popup-modal" data-modal-backdrop="static" tabindex="-1" class="hidden overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full">
            <div class="relative p-4 w-full max-w-md max-h-full">
                <div class="relative bg-white rounded-lg shadow">
                    <div class="p-4 md:p-5 text-center">
                        <svg class="mx-auto mb-4 text-gray-400 w-12 h-12" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 11V6m0 8h.01M19 10a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"/>
                        </svg>
                        <h3 class="mb-5 text-lg font-normal text-gray-5000">Rehearsal space successfully booked!</h3>
                        <button id="activeBookingsButton" type="submit" class="text-black bg-yellow-300 hover:bg-yellow-400 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm inline-flex items-center px-5 py-2.5 text-center me-2">
                            See active bookings
                        </button>
                        <button id="closeButton" type="button" class="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Take me to homepage</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
// TODO: bring back middleware
// definePageMeta({
//   middleware: [
//     'auth'
//   ]
// })

import { ref } from 'vue';
import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css'
import { onMounted, nextTick } from 'vue'
import { Modal } from 'flowbite'

export default {
    async asyncData({ app }) {
        const userID = app.$root.$myVariable;

        return { userID };
    },
    components: { VueDatePicker },
    data() {
        return{
            slots: [],
            booking: {
                userId: '',
                artist: '',
                date: '',
                phoneNumber: '',
                price: '',
                slotIds: []
            },
            acceptTsCs: false,
            total: 0,
            showPrice: false,
            selectedSlotIds: [],
            showBandValidationError: false,
            showContactNumberValidationError: false,
            showDateValidationError: false,
            slotsValidationError: false,
            checkValidationError: false
        }
        
    },
    setup() {
        const date = ref();

        const format = (date) => {
            const day = date.getDate();
            const month = (date.getMonth() + 1).toString().padStart(2, '0');
            const year = date.getFullYear();

            const convertedMonth = (date.getMonth() < 10 ? date.getMonth() : date.getMonth()).toString();

            const monthNames = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

            const selectedMonthName = monthNames[convertedMonth]

            const formattedDate = `${year}-${month}-${day}`

            // Get the day of the week
            const dayOfWeek = new Date(formattedDate).toLocaleDateString('en-US', { weekday: 'long' });

            return {
                formattedDate,
                day,
                selectedMonthName,
                dayOfWeek
            };
        }

        const useUserId = useStateUserId()

        onMounted(async () => {
            await nextTick();
            const $buttonElement = document.querySelector('#button');
            const $modalElement = document.querySelector('#popup-modal');
            const $closeButton = document.querySelector('#closeButton');
            const $activeBookingsButton = document.querySelector('#activeBookingsButton');
            const modalOptions = {
                backdrop: 'static',
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }
            if ($modalElement) {
                const modal = new Modal($modalElement, modalOptions);
                 $buttonElement.addEventListener('click', () => modal.toggle());
                 $closeButton.addEventListener('click', () => modal.hide());
                 $activeBookingsButton.addEventListener('click', () => modal.hide());
            }
        })

        return {
            date,
            format,
            formattedDateObj: computed(() => format(date.value)),
            useUserId
        }
    },
    created() {
        this.fetchSlots()
    },
    mounted(){
        this.fetchSlots().then(() => {
            const preSelectedSlotIds = [];
            this.selectedSlotIds = preSelectedSlotIds;

            // Set slot.selected based on pre-selected slotIds
            this.slots.forEach((slot) => {
            slot.selected = this.selectedSlotIds.includes(slot.slotId);
            });

            this.calculateTotalAndBooking();
        })
        
    },
    methods: {
        async fetchSlots() {
            try {
                const response = await axios.get("https://localhost:7179/api/Slot/GetSlots")
                this.slots = response.data

            } catch (error) {
                console.log("Could not fetch slots: ", error.message)
            }
        },
        async bookRehearsal(){
            var isValid = false
            this.showBandValidationError = false
            this.showContactNumberValidationError = false
            this.showDateValidationError = false
            this.checkValidationError = false

            // validation
            if(!this.booking.artist) {
                this.showBandValidationError = true
                isValid = true
            }

            if(!this.booking.phoneNumber) {
                this.showContactNumberValidationError = true
                isValid = true
            }

            if(!this.date) {
                this.showDateValidationError = true
                isValid = true
            }

            if(this.selectedSlotIds.length == 0) {
                this.slotsValidationError = true
                isValid = true
            }

            if(!this.acceptTsCs){
                this.checkValidationError = true
                isValid = true
            }

            if (isValid) {
                return; 
            } else {
                //const correctDateFormat = this.format(this.date);
                const correctDateFormat = this.format(this.date);

                console.log(this.total)

                this.booking.date = correctDateFormat.formattedDate
                this.booking.userId = localStorage.getItem('varchar')
                this.booking.price = this.total

                const $modalElement = document.querySelector('#popup-modal');
                const $closeButton = document.querySelector('#closeButton');
                const $activeBookingsButton = document.querySelector('#activeBookingsButton');
                const modalOptions = {
                    backdrop: 'static',
                    backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
                }

                //console.log(this.booking)

                try{
                    const response = await axios.post("https://localhost:7179/api/Bookings/CreateBooking", this.booking)
                    console.log(response.data)

                    const $modalElement = document.querySelector('#popup-modal');
                    if ($modalElement) {
                        const modal = new Modal($modalElement, modalOptions);
                        modal.toggle();
                        $closeButton.addEventListener('click', () => {
                            modal.hide()
                            this.$router.replace('/')
                        });
                        $activeBookingsButton.addEventListener('click', () => {
                            modal.hide()
                            this.$router.replace('/manage-bookings')
                        });
                    }
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
            console.log(this.selectedSlotIds)
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
    },
}


</script>
