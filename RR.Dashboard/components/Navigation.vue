<template>
    <div class="p-3 bg-white h-full border-r-[1px] border-slate-100">
        <div class="text-black text-center font-medium text-3xl">
            R&R<span class="text-slate-300 text-2xl  font-medium">Studios</span>
        </div>

        <ul class="mt-10 px-5 space-y-5">
            <li class="hover:bg-gray-100 hover:text-black p-2 px-4 rounded-lg" :class="{ 'text-white bg-blue-600': $route.path === '/dashboard' }">
                <NuxtLink to="/dashboard">Home</NuxtLink>
            </li>
            <li class="hover:bg-gray-100 hover:text-black p-2 px-4 rounded-lg" :class="{ 'text-white bg-blue-600': $route.path.startsWith('/bookings') }">
                <NuxtLink>Bookings</NuxtLink>
            </li>
            <li class="hover:bg-gray-100 hover:text-black p-2 px-4 rounded-lg" :class="{ 'text-white bg-blue-600': $route.path.startsWith('/employees') }">
                <NuxtLink>Employees</NuxtLink>
            </li>
            <li class="hover:bg-gray-100 hover:text-black p-2 px-4 rounded-lg" :class="{ 'text-white bg-blue-600': $route.path.startsWith('/slots') }">
                <NuxtLink to="/slots">Slots</NuxtLink>
            </li>
            <li class="hover:bg-gray-100 hover:text-black p-2 px-4 rounded-lg" :class="{ 'text-white bg-blue-600': $route.path.startsWith('/payments') }">
                <NuxtLink>Payments</NuxtLink>
            </li>
        </ul>
    </div>
</template>