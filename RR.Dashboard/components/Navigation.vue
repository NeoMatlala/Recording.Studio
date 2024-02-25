<template>
    <div class="p-3 bg-white h-full border-r-[1px] border-slate-100">
        <div class="text-black text-center font-medium text-3xl">
            R&R<span class="text-slate-300 text-2xl  font-medium">Studios</span>
        </div>

        <ul class="mt-10 px-5 space-y-5">
            <li class="hover:bg-gray-100 p-2 px-8 rounded-lg relative" 
                :class="{ 'text-black bg-blue-600': $route.path === '/dashboard', 'bg-slate-200': $route.path === '/dashboard' }">
                <NuxtLink to="/dashboard">
                    <span v-if="$route.path === '/dashboard'" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                    Home
                </NuxtLink>
            </li>
            <li class="hover:bg-gray-100 p-2 px-8 rounded-lg relative" 
                :class="{ 'text-black bg-blue-600': $route.path.startsWith('/bookings'), 'bg-slate-200': $route.path.startsWith('/bookings') }">
                <NuxtLink to="/bookings">
                    <span v-if="$route.path.startsWith('/bookings')" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                    Bookings
                </NuxtLink>
            </li>
            <li>
                <button type="button" class="flex items-center w-full p-2 text-base text-gray-900 transition duration-75 rounded-lg group hover:bg-gray-100" @click="openDropdown">
                    <span class="flex-1 pl-6 text-left rtl:text-right whitespace-nowrap">Blogs</span>
                    <svg class="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 10 6">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m1 1 4 4 4-4"/>
                    </svg>
                </button>
                <ul class="py-2 pl-6 space-y-2" v-if="showDropdown">
                    <li class="hover:bg-gray-100 p-2 px-8 rounded-lg relative" 
                        :class="{ 'text-black bg-blue-600': $route.path.startsWith('/blogs'), 'bg-slate-200': $route.path.startsWith('/blogs') }">
                        <NuxtLink to="/blogs">
                            <span v-if="$route.path.startsWith('/blogs')" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                            Blogs
                        </NuxtLink>
                    </li>
                    <li class="hover:bg-gray-100 p-2 px-8 rounded-lg relative" 
                        :class="{ 'text-black bg-blue-600': $route.path.startsWith('/tags'), 'bg-slate-200': $route.path.startsWith('/tags') }">
                        <NuxtLink to="/tags">
                            <span v-if="$route.path.startsWith('/tags')" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                            Tags
                        </NuxtLink>
                    </li>
                </ul>
            </li>
            <li class="hover:bg-gray-100 p-2 px-8 rounded-lg relative" 
                :class="{ 'text-black bg-blue-600': $route.path.startsWith('/slots'), 'bg-slate-200': $route.path.startsWith('/slots') }">
                <NuxtLink to="/slots">
                    <span v-if="$route.path.startsWith('/slots')" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                    Slots
                </NuxtLink>
            </li>
            <li class="hover:bg-gray-100 p-2 px-8 rounded-lg relative" 
                :class="{ 'text-black bg-blue-600': $route.path.startsWith('/users'), 'bg-slate-200': $route.path.startsWith('/users') }">
                <NuxtLink to="/users">
                    <span v-if="$route.path.startsWith('/users')" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                    Users
                </NuxtLink>
            </li>
            <li class="hover:bg-gray-100 p-2 px-8 rounded-lg relative" 
                :class="{ 'text-black bg-blue-600': $route.path.startsWith('/team'), 'bg-slate-200': $route.path.startsWith('/team') }">
                <NuxtLink to="/team">
                    <span v-if="$route.path.startsWith('/team')" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                    Team
                </NuxtLink>
            </li>
            <li class="hover:bg-gray-100 p-2 px-8 rounded-lg relative" 
                :class="{ 'text-black bg-blue-600': $route.path.startsWith('/payments'), 'bg-slate-200': $route.path.startsWith('/payments') }">
                <NuxtLink to="/payments">
                    <span v-if="$route.path.startsWith('/payments')" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                    Payments
                </NuxtLink>
            </li>
        </ul>
    </div>
</template>

<script>

export default{
    data(){
        return {
            showDropdown: false
        }
    },
    methods: {
        openDropdown() {
            this.showDropdown = !this.showDropdown;
        }
    }
}
</script>