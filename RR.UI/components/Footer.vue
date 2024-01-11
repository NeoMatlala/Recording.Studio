<template>
    <footer>
        <div class="w-full max-w-screen-xl mx-auto md:py-8">
            <hr class="my-6 border-gray-200 sm:mx-auto lg:my-8" />
            <div class="sm:flex sm:items-center sm:justify-between">
                <NuxtLink to="/" class="text-black font-medium text-5xl">
                    R&R<span class="text-slate-300 text-4xl font-medium">Studios</span>
                </NuxtLink>
                <ul class="flex flex-wrap items-center mb-6 text-sm font-medium text-gray-500 sm:mb-0">
                    <li>
                        <a class="cursor-pointer hover:underline me-4 md:me-6">Services</a>
                    </li>
                    <li>
                        <a class="cursor-pointer hover:underline me-4 md:me-6">Studios</a>
                    </li>
                    <li>
                        <a class="cursor-pointer hover:underline me-4 md:me-6">Team</a>
                    </li>
                    <li>
                        <a class="cursor-pointer hover:underline">Contact Us</a>
                    </li>
                </ul>
            </div>
            
            <span class="block font-light mt-5 text-sm text-gray-500 sm:text-center">© 2023 <a href="/" class="hover:underline">R&RStudios™</a>. All Rights Reserved.</span>
        </div>
    </footer>
</template>