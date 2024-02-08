<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="font-medium text-3xl">Create Rehearsal Slot</h1>

        <form class="mt-16" @submit.prevent="createSlot">
            <div class="grid gap-10 mb-6 md:grid-cols-3">
                <div>
                    <label for="first_name" class="block mb-2 text-sm font-medium text-gray-900">Slot name</label>
                    <input type="text" id="first_name" v-model="slot.name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="1" required>
                    <small class="text-xs hidden text-red-600">Slot Name is required</small>
                </div>
                <div>
                    <label for="last_name" class="block mb-2 text-sm font-medium text-gray-900">Time</label>
                    <input type="text" id="last_name" v-model="slot.time" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="11:00 - 13:00" required>
                    <small class="text-xs hidden text-red-600">Slot Time is required</small>
                </div>
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Slot Rate </label>
                    <input type="text" id="company" v-model="slot.price" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="200" required>
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Create Employee</button>
                <NuxtLink to="/slots" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios';
import authMiddleware from '~/middleware/auth'

export default{
    data() {
        return {
            slot: {
                name: '',
                time: '',
                price: ''
            }
        }
    },
    setup() {
        const setup = () => {
            definePageMeta({
                middleware: [authMiddleware],
            })
        }

        return {
            setup
        }
    },
    methods: {
        async createSlot() {
            try {
                const response = await axios.post(`https://localhost:7179/api/Slot/create-slot`, this.slot)
                console.log(response.data)
                this.$router.replace('/slots');
            } catch (error) {
                console.log("Could not add this slot: ", error.message)
            }
        }
    }
}

</script>