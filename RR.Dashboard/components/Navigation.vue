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
            <li class="hover:bg-gray-100 p-2 px-8 rounded-lg relative" 
                :class="{ 'text-black bg-blue-600': $route.path.startsWith('/slots'), 'bg-slate-200': $route.path.startsWith('/slots') }">
                <NuxtLink to="/slots">
                    <span v-if="$route.path.startsWith('/slots')" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                    Slots
                </NuxtLink>
            </li>
            <li class="hover:bg-gray-100 text-slate-400 p-2 px-8 rounded-lg" :class="{ 'text-white bg-blue-600': $route.path.startsWith('/employees') }">
                <NuxtLink>Employees</NuxtLink>
            </li>
            <!-- <li class="hover:bg-gray-100 p-2 text-slate-400 px-8 rounded-lg relative" 
                :class="{ 'text-black bg-blue-600': $route.path.startsWith('/users'), 'bg-slate-200': $route.path.startsWith('/users') }">
                <NuxtLink to="/users">
                    <span v-if="$route.path.startsWith('/users')" class="absolute rounded-l-lg inset-y-0 left-0 w-2 bg-blue-600"></span>
                    Users
                </NuxtLink>
            </li> -->
            <li class="hover:bg-gray-100 text-slate-400 p-2 px-8 rounded-lg" :class="{ 'text-white bg-blue-600': $route.path.startsWith('/payments') }">
                <NuxtLink>Payments</NuxtLink>
            </li>
        </ul>
    </div>
</template>