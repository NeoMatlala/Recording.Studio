<template>
    <div class="w-full bg-slate-100 flex justify-start items-start h-screen">
        <Navigation class="w-1/6" />
        <div class="w-5/6">
            <div class="bg-white w-full h-16">
                <div class="bg-white h-full relative flex items-center gap-2 justify-end max-w-[95%] mx-auto">
                    <div class="h-full hover:scale-105 cursor-pointer flex items-center gap-2 justify-end" @click="dropdownToggle" >
                        <img class="w-10 h-10 rounded-full" src="../assets/img/studio.jpg" alt="Rounded avatar">
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
            <slot class="mt-5 max-w-[95%] mx-auto"/>
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