<template>
    <nav class="bg-white mb-6 max-w-7xl mx-auto">
        <div class="max-w-screen-xl flex flex-wrap bg-white border-b border-gray-200 fixed top-0 w-full items-center justify-between mx-auto py-4 px-4 md:px-0">
            <NuxtLink to="/" class="text-black font-medium text-5xl">
                R&R<span class="text-slate-300 text-4xl font-medium">Studios</span>
            </NuxtLink>
            <button data-collapse-toggle="navbar-default" @click="toggleMobile" type="button" class="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200" aria-controls="navbar-default" aria-expanded="false">
                <span class="sr-only">Open main menu</span>
                <svg class="w-5 h-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 17 14">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M1 1h15M1 7h15M1 13h15"/>
                </svg>
            </button>
            <div v-if="$route.path !== '/manage-bookings' && $route.path !== '/book-rehearsal'" class="hidden w-full md:block md:w-auto" id="navbar-default">
                <ul class="font-medium flex flex-col p-4 md:p-0 mt-4 border border-gray-100 rounded-lg bg-gray-50 md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 md:border-0 md:bg-white">
                    <li :class="{'text-yellow-600 underline underline-offset-4 decoration-yellow-500': $route.path.startsWith('/services')}" class="cursor-pointer block py-2 px-3 text-gray-900 md:p-0 md:hover:underline" >
                        <NuxtLink to="/services"  aria-current="page">Services</NuxtLink>
                    </li>
                    <li :class="{'text-yellow-600 underline underline-offset-4 decoration-yellow-500': $route.path.startsWith('/studios')}" class="cursor-pointer block py-2 px-3 text-gray-900 md:hover:underline md:border-0 md:p-0">
                        <NuxtLink to="/studios">Studios</NuxtLink>
                    </li>
                    <li :class="{'text-yellow-600 underline underline-offset-4 decoration-yellow-500': $route.path.startsWith('/the-team')}" class="cursor-pointer block py-2 px-3 text-gray-900 md:hover:underline md:border-0 md:p-0">
                        <NuxtLink to="/the-team">Team</NuxtLink>
                    </li>
                    <li :class="{'text-yellow-600 underline underline-offset-4 decoration-yellow-500': $route.path.startsWith('/contact-us')}" class="cursor-pointer block py-2 px-3 text-gray-900 md:hover:underline md:border-0 md:p-0">
                        <NuxtLink to="/contact-us">Contact</NuxtLink>
                    </li>
                </ul>
            </div>
            <NuxtLink v-if="$route.path !== '/manage-bookings' && $route.path !== '/book-rehearsal'" to="/login" type="button" class="text-black hidden md:block bg-yellow-400 hover:bg-yellow-500 focus:ring-2 focus:ring-yellow-300 font-medium rounded-lg text-base px-5 py-2.5">
                Book rehearsal space
            </NuxtLink>

            <div v-if="$route.path == '/manage-bookings' || $route.path === '/book-rehearsal'" class="hidden w-full md:block md:w-auto" id="navbar-default">
                <button id="dropdownDefaultButton" @click="dropdownToggle" class="text-black hover:bg-slate-200 focus:ring-2 focus:outline-none focus:ring-yellow-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center inline-flex items-center justify-center gap-5" type="button">
                    email@user.com 
                    <svg class="w-2.5 h-2.5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 10 6">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m1 1 4 4 4-4"/>
                    </svg>
                </button>

                <!-- Dropdown menu -->
                <div v-if="showDropdown" id="dropdown" class="z-10 absolute bg-white divide-y divide-gray-100 rounded-lg shadow w-44">
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

        <div v-if="showMobileMenu" class="bg-white w-full z-50 h-screen">
            <ul class="font-medium h-full flex flex-col items-center justify-center text-3xl gap-y-10 p-4 md:p-0 mt-4 border border-gray-100 rounded-lg bg-gray-50 md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 md:border-0 md:bg-white">
                <li :class="{'text-yellow-600 underline underline-offset-4 decoration-yellow-500': $route.path === '/'}" class="cursor-pointer block py-2 px-3 text-gray-900 md:p-0 md:hover:underline" >
                    <NuxtLink to="/" @click="toggleMobile" aria-current="page">Home</NuxtLink>
                </li>
                <li :class="{'text-yellow-600 underline underline-offset-4 decoration-yellow-500': $route.path.startsWith('/services')}" class="cursor-pointer block py-2 px-3 text-gray-900 md:p-0 md:hover:underline" >
                    <NuxtLink to="/services" @click="toggleMobile" aria-current="page">Services</NuxtLink>
                </li>
                <li :class="{'text-yellow-600 underline underline-offset-4 decoration-yellow-500': $route.path.startsWith('/studios')}" class="cursor-pointer block py-2 px-3 text-gray-900 md:hover:underline md:border-0 md:p-0">
                    <NuxtLink to="/studios" @click="toggleMobile">Studios</NuxtLink>
                </li>
                <li :class="{'text-yellow-600 underline underline-offset-4 decoration-yellow-500': $route.path.startsWith('/the-team')}" class="cursor-pointer block py-2 px-3 text-gray-900 md:hover:underline md:border-0 md:p-0">
                    <NuxtLink to="/the-team" @click="toggleMobile">Team</NuxtLink>
                </li>
                <li :class="{'text-yellow-600 underline underline-offset-4 decoration-yellow-500': $route.path.startsWith('/contact-us')}" class="cursor-pointer block py-2 px-3 text-gray-900 md:hover:underline md:border-0 md:p-0">
                    <NuxtLink to="/contact-us" @click="toggleMobile">Contact</NuxtLink>
                </li>
            </ul>
        </div>
    </nav>
</template>

<script>
export default {
    data() {
        return {
            showDropdown: false,
            showMobileMenu: false
        }
    },
    methods : {
        dropdownToggle() {
            this.showDropdown = !this.showDropdown;
        },
        logout() {
            localStorage.removeItem('token')
            localStorage.removeItem('varchar')
            this.$router.replace('/login')
        },
        toggleMobile() {
            this.showMobileMenu = !this.showMobileMenu
        }
    }
}
</script>