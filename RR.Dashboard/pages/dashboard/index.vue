<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <h1 class="text-4xl mb-16 text-slate-800 font-medium">Dashboard</h1>

            <div class="mt-10 flex justify-start items-center gap-8">
                <NuxtLink to="/bookings" class="block w-[250px] p-10 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                    <h5 class="mb-2 text-3xl font-bold tracking-tight text-gray-900">{{ bookingCount }}</h5>
                    <p class="font-normal text-gray-700">Bookings</p>
                </NuxtLink>
                <NuxtLink class="block w-[250px] p-10 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                    <h5 class="mb-2 text-3xl font-bold tracking-tight text-gray-900">6</h5>
                    <p class="font-normal text-gray-700">Employees</p>
                </NuxtLink>
                <NuxtLink to="/slots" class="block w-[250px] p-10 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                    <h5 class="mb-2 text-3xl font-bold tracking-tight text-gray-900">{{ slotCount }}</h5>
                    <p class="font-normal text-gray-700">Slots</p>
                </NuxtLink>
                <NuxtLink class="block w-[250px] p-10 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                    <h5 class="mb-2 text-3xl font-bold tracking-tight text-gray-900">R 64 000.25</h5>
                    <p class="font-normal text-gray-700">Total Revenue</p>
                </NuxtLink>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data() {
        return {
            slotCount: 0,
            bookingCount: 0
        }
    },
    created() {
        this.getSlotCount();
        this.getBookingCount();
    },
    methods: {
        async getSlotCount() {
            try {
                const response = await axios.get("https://localhost:7179/api/Slot/GetSlots")
                this.slotCount = response.data.length
            } catch (error) {
                console.log("Can not get slot count:", error.message)
            }
        },
        async getBookingCount() {
            try {
                const response = await axios.get("https://localhost:7179/api/Bookings/GetAllBookings")
                this.bookingCount = response.data.length
            } catch (error) {
                console.log("Can not get slot count:", error.message)
            }
        }
    }
}
</script>
