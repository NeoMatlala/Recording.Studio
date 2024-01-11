<template>
    <nav class="bg-white mb-6 max-w-7xl mx-auto border-gray-200">
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
                <ul class="font-medium flex flex-col p-4 md:p-0 mt-4 border border-gray-100 rounded-lg bg-gray-50 md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 md:border-0 md:bg-white">
                    <li>
                        <a class="cursor-pointer block py-2 px-3 text-gray-900 md:p-0 md:hover:underline" aria-current="page">Services</a>
                    </li>
                    <li>
                        <a class="cursor-pointer block py-2 px-3 text-gray-900 md:hover:underline md:border-0 md:p-0">Studios</a>
                    </li>
                    <li>
                        <a class="cursor-pointer block py-2 px-3 text-gray-900 md:hover:underline md:border-0 md:p-0">Team</a>
                    </li>
                    <li>
                        <a class="cursor-pointer block py-2 px-3 text-gray-900 md:hover:underline md:border-0 md:p-0">Contact Us</a>
                    </li>
                </ul>
            </div>
            <NuxtLink to="/login" type="button" class="text-black bg-yellow-400 hover:bg-yellow-500 focus:ring-2 focus:ring-yellow-300 font-medium rounded-lg text-base px-5 py-2.5">
                Book rehearsal space
            </NuxtLink>
        </div>
    </nav>
</template>