<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <div class="flex justify-between items-center mb-10">
                <h1 class="text-3xl text-slate-800 font-medium">Rehearsal Slots</h1>
                <NuxtLink to="/slots/add" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Add Slots</NuxtLink>
            </div>

            <div class="block p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                <div class="relative overflow-x-auto">
                    <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                        <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                            <tr>
                                <th scope="col" class="px-6 py-3">
                                    Slot Name
                                </th>
                                <th scope="col" class="px-6 py-3">
                                    Time
                                </th>
                                <th scope="col" class="px-6 py-3">
                                    Slot Rate
                                </th>
                                <th scope="col" class="px-6 py-3"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="odd:bg-white even:bg-gray-50 border-b" v-for="slot in slots" :key="slot.slotId">
                                <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                    {{slot.name}}
                                </th>
                                <td class="px-6 py-4">
                                    {{slot.time}}
                                </td>
                                <td class="px-6 py-4">
                                    {{slot.price}}
                                </td>
                                <td class="px-6 py-4 space-x-5">
                                    <NuxtLink :to="`/slots/update/${slot.slotId}`" class="font-medium text-blue-600 hover:underline">Edit</NuxtLink>
                                    <NuxtLink :to="`/slots/delete/${slot.slotId}`" class="font-medium text-red-600 hover:underline">Delete</NuxtLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import authMiddleware from '~/middleware/auth'

export default{
    data() {
        return {
            slots: []
        }
        
    },
    setup(){
        const config = useRuntimeConfig()

        const setup = () => {
            definePageMeta({
                middleware: [authMiddleware],
            })
        }

        return {
            baseApi: config.public.apiBase,
            setup
        }
    },
    created(){
        this.getSlots()
    },
    methods: {
        async getSlots() {
            try{
                //var response = await axios.get(`${this.baseApi}/api/Employee`);
                var response = await axios.get("https://localhost:7179/api/Slot/get-slots")
                //console.log(response.data)
                this.slots = response.data
            } catch(error) {
                console.log("Error getting slots: ", error.message)
            }
        }
    }
}
</script>