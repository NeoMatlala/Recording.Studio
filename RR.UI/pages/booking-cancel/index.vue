<template>
    <div class="flex flex-col items-center justify-center">
        <h1 class="mb-5 text-lg font-normal text-gray-5000">Booking process failed</h1>
        <div class="flex items-center justify-center gap-x-5">
            <button id="activeBookingsButton" type="submit" class="text-black bg-red-300 hover:bg-red-400 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm inline-flex items-center px-5 py-2.5 text-center me-2 mb-5 md:mb-0">
                Back to booking
            </button>
            <NuxtLink to="/" type="button" class="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Take me to homepage</NuxtLink>
        </div>
    </div>
</template>