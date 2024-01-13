<template>
    <div class="w-full">
        <!-- <div class="w-1/6 p-3 bg-white h-full border-r-[1px] border-slate-100">
            <div class="text-black text-center font-medium text-3xl">
                R&R<span class="text-slate-300 text-2xl  font-medium">Studios</span>
            </div>

            <ul class="mt-10 px-5 space-y-5">
                <li class="hover:bg-blue-600 hover:text-white p-2 px-4 rounded-lg" :class="{ 'text-white bg-blue-600': $route.path === '/dashboard' }">
                    <NuxtLink>Home</NuxtLink>
                </li>
                <li class="hover:bg-blue-600 hover:text-white p-2 px-4 rounded-lg" :class="{ 'bg-white text-blue-700': $route.path.startsWith('/bookings') }">
                    <NuxtLink>Bookings</NuxtLink>
                </li>
                <li class="hover:bg-blue-600 hover:text-white p-2 px-4 rounded-lg" :class="{ 'bg-white text-blue-700': $route.path.startsWith('/employees') }">
                    <NuxtLink>Employees</NuxtLink>
                </li>
                <li class="hover:bg-blue-600 hover:text-white p-2 px-4 rounded-lg" :class="{ 'bg-white text-blue-700': $route.path.startsWith('/slots') }">
                    <NuxtLink>Slots</NuxtLink>
                </li>
                <li class="hover:bg-blue-600 hover:text-white p-2 px-4 rounded-lg" :class="{ 'bg-white text-blue-700': $route.path.startsWith('/payments') }">
                    <NuxtLink>Payments</NuxtLink>
                </li>
            </ul>
        </div> -->

        <div>
            <div class="bg-white w-full h-16">
                <div class="bg-white h-full relative flex items-center gap-2 justify-end max-w-[95%] mx-auto">
                    <div class="h-full hover:scale-105 cursor-pointer flex items-center gap-2 justify-end" @click="dropdownToggle" >
                        <img class="w-10 h-10 rounded-full" src="../../assets/img/studio.jpg" alt="Rounded avatar">
                        <svg class="w-2.5 h-2.5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 10 6">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m1 1 4 4 4-4"/>
                        </svg>
                    </div>
                    
                    <!-- Dropdown menu -->
                    <div v-if="showDropdown" id="dropdown" class="z-10 absolute top-16 bg-white divide-y divide-gray-100 rounded-lg shadow w-44">
                        <ul class="py-2 text-sm text-gray-700">
                            <li>
                                <a class="block px-4 py-2 hover:bg-gray-100 text-slate-300">Dashboard</a>
                            </li>
                            <li>
                                <a class="block px-4 py-2 hover:bg-gray-100 text-slate-300">Settings</a>
                            </li>
                            <li>
                                <a class="block px-4 py-2 hover:bg-gray-100 text-slate-300">Earnings</a>
                            </li>
                            <li>
                                <a class="cursor-pointer block px-4 py-2 hover:bg-gray-100" @click="logout">Sign out</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="mt-5 max-w-[95%] mx-auto">
                <h1 class="text-4xl mb-16 text-slate-800 font-medium">Dashboard</h1>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            showDropdown: false
        }
    },
    methods : {
        dropdownToggle() {
            this.showDropdown = !this.showDropdown;
        },
        logout() {
            localStorage.removeItem('token')
            this.$router.replace('/')
        }
    }
}
</script>