<template>
    <div class="max-w-7xl mx-auto">
        <h1 class="text-5xl mt-16 mb-10 font-medium">Select available slot</h1>

        <div class="flex justify-between gap-5 items-center">
            <div class="w-1/3">
                <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Rehearsal date</label>
                <input type="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="select date" required>
            </div>
            <div class="w-1/3">
                <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Band or Artist name</label>
                <input type="text" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Band Of Neo" required>
            </div>
            <div class="w-1/3">
                <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Contact number</label>
                <input type="text" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="0721235698" required>
            </div>
        </div>

        <div class="flex justify-between items-start gap-10 mt-16">
            <!-- slots -->
            <div class="w-2/3">
                <h1 class="font-medium text-4xl mb-2">02 Jan</h1>
                <h6 class="font-light text-4xl mb-10">Tuesday</h6>

                <div class="grid grid-cols-3  gap-4">
                    <div class="bg-slate-100 hover:bg-slate-200 text-slate-500 rounded-md cursor-pointer hover:text-black p-6">
                        <p class="text-center">
                            09:00 - 11:00
                        </p>
                    </div>
                    <div class="bg-slate-100 text-slate-500 rounded-md hover:text-black cursor-pointer hover:bg-slate-200 p-6">
                        <p class="text-center">
                            09:00 - 11:00
                        </p>
                    </div>
                    <div class="bg-slate-100 text-slate-500 rounded-md hover:text-black cursor-pointer hover:bg-slate-200 p-6">
                        <p class="text-center">
                            09:00 - 11:00
                        </p>
                    </div>
                    <div class="bg-slate-100 text-slate-500 rounded-md hover:text-black cursor-pointer hover:bg-slate-200 p-6">
                        <p class="text-center">
                            09:00 - 11:00
                        </p>
                    </div>
                    <div class="bg-slate-100 text-slate-500 rounded-md hover:text-black cursor-pointer hover:bg-slate-200 p-6">
                        <p class="text-center">
                            09:00 - 11:00
                        </p>
                    </div>
                </div>

                <div class="flex items-start mt-10">
                    <div class="flex items-center h-5">
                    <input id="remember" type="checkbox" value="" class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-blue-300 dark:bg-gray-700 dark:border-gray-600 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:focus:ring-offset-gray-800" required>
                    </div>
                    <label for="remember" class="ms-2 text-sm font-light text-gray-900 dark:text-gray-300">
                        I agree to  R&R studio' <span class="hover:underline">Terms of Service</span> and <span class="hover:underline">Privacy Policy</span>.
                    </label>
                </div>
            </div>

            <!-- price -->
            <div class="p-5 border border-slate-200 rounded-md w-1/3">
                <h1 class="font-medium text-3xl">R450 <span class="text-2xl font-normal">/slot</span></h1>
                <p class="mt-5 mb-16 font-light text-slate-500">
                    Our slots are two(2) hour slots
                </p>

                <button type="submit" class="text-black bg-yellow-300 hover:bg-yellow-400 focus:ring-2 focus:outline-none focus:ring-yellow-400 font-medium rounded-lg text-base w-full  px-5 py-2.5 mt-5 text-center">Book</button>

                <hr class="my-6 border-gray-200 sm:mx-auto lg:my-8" />

                <div class="flex mb-8 justify-between items-center">
                    <p>R450 x 3 slots</p>
                    <p>R1350</p>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
definePageMeta({
  middleware: [
    'auth'
  ]
})
</script>
