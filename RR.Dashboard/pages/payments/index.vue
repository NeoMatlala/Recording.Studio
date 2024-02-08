<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <h1 class="text-3xl text-slate-800 font-medium mb-10">Payments</h1>

            <div class="block p-3 bg-white border shadow-sm border-slate-300 rounded-lg mb-10">
                <div class="relative overflow-x-auto ">
                    <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                        <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                            <tr>
                                <th scope="col" class="px-6 py-3">
                                    Amount
                                </th>
                                <th scope="col" class="px-6 py-3">
                                    Customer
                                </th>
                                <th scope="col" class="px-6 py-3">
                                    Date
                                </th>
                                <th scope="col" class="px-6 py-3">
                                    Status
                                </th>
                                <th scope="col" class="px-6 py-3"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700" v-for="payment in payments">
                                <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white space-x-5">
                                   <span>R {{ payment.amount }}</span> 
                                </th>
                                <td class="px-6 py-4">
                                    {{ payment.userName }}
                                </td>
                                <td class="px-6 py-4">
                                    {{ payment.date }}
                                </td>
                                <td class="px-6 py-4">
                                    <span class="bg-green-100 text-green-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded">Completed</span>
                                </td>
                                <td class="px-6 py-4">
                                    <NuxtLink :to="`payments/view/${payment.paymentId}`" class="font-medium text-blue-600 hover:underline">View Payment</NuxtLink>
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
import axios from 'axios'

export default{
    data() {
        return{
            payments: []
        }
    },
    mounted() {
        this.getPayments();
    },
    methods: {
        async getPayments(){
            try {
                const response = await axios.get("https://localhost:7179/api/Payment/get-payments")
                this.payments = response.data.reverse()
            } catch (error) {
                console.log("Can not get payments:", error.message)
            }
        }
    }
}
</script>