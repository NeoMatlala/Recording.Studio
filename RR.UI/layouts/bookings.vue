<template>
    <div>
        <nav class="bg-white max-w-7xl mx-auto border-gray-200">
            <div class="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto py-4">
                <NuxtLink to="/" class="text-black font-medium text-5xl">
                    R&R<span class="text-slate-300 text-4xl font-medium">Studios</span>
                </NuxtLink>
                <button data-collapse-toggle="navbar-default" type="button" class="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200" aria-controls="navbar-default" aria-expanded="false">
                    <span class="sr-only">Open main menu</span>
                    <svg class="w-5 h-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 17 14">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M1 1h15M1 7h15M1 13h15"/>
                    </svg>
                </button>
                <div class="hidden w-full md:block md:w-auto" id="navbar-default">
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
        </nav>
        <slot />
        <Footer />
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
            this.$router.replace('/login')
        }
    }
}
</script>