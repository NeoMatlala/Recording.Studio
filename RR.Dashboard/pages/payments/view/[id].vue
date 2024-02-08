<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <h1 class="text-3xl text-slate-800 font-medium mb-10">Payment #{{ payment.paymentId }}</h1>

            <div class="block p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                <div class="relative overflow-x-auto">
                    <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                        <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                            <tr>
                                <th scope="col" class="px-6 py-3"></th>
                                <th scope="col" class="px-6 py-3">
                                    Payment Information
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="odd:bg-white even:bg-gray-50 border-b">
                                <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                    Paid By
                                </th>
                                <td class="px-6 py-4">
                                    {{payment.userName}}
                                </td>
                            </tr>
                            <tr class="odd:bg-white even:bg-gray-50 border-b">
                                <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                    Payment Date
                                </th>
                                <td class="px-6 py-4">
                                    {{payment.date}}
                                </td>
                            </tr>
                            <tr class="odd:bg-white even:bg-gray-50 border-b">
                                <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                    Amount
                                </th>
                                <td class="px-6 py-4 flex items-center justify-start gap-x-3">
                                    R {{payment.amount}}
                                    <span class="bg-green-100 text-green-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded">Completed</span>
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
    </div>
</template>

<script>
import axios from 'axios';
import { ref } from 'vue';
import { useRoute } from 'vue-router';

export default{
    data() {
        return {
            payment: {},
            bookingSlots: [],
            slotNames: []
        }
    },
    setup(){
        const id = ref(useRoute().params.id)

        return {
            id,
        }
    },
    mounted(){
        this.getPayment()
    },
    methods: {
        async getPayment() {
            try {
                var response = await axios.get(`https://localhost:7179/api/Payment/get-payment/${this.id}`)
                this.payment = response.data

                this.bookingSlots = this.payment.paymentSlots
                this.getSlots(this.bookingSlots)
                
            } catch (error) {
                console.log("Error getting payment: ", error.message)
            }
        },
        getSlots(slotArray) {
            slotArray.forEach(async (slot) => {
                //console.log(slot.slotId)

                try {
                    const response = await axios.get(`https://localhost:7179/api/Slot/get-slot/${slot.slotId}`)
                    //console.log(response.data)
                    this.slotNames.push(response.data.time)

                } catch (error) {
                    console.log("Could not fetch this slot: ", error.message)
                }
            })
        }
    }
}
</script>