<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <h1 class="text-2xl mb-10 text-slate-800 font-medium">Dashboard</h1>

            <div class="flex justify-start items-center gap-8 mb-10">
                <div class="block w-1/4 gap-x-5 p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                    <div class="flex">
                        <div class="w-1/4 h-12 rounded-md bg-gray-800 flex justify-center items-center">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="#fff" class="w-full h-10">
                                <path d="M12 7.5a2.25 2.25 0 1 0 0 4.5 2.25 2.25 0 0 0 0-4.5Z" />
                                <path fill-rule="evenodd" d="M1.5 4.875C1.5 3.839 2.34 3 3.375 3h17.25c1.035 0 1.875.84 1.875 1.875v9.75c0 1.036-.84 1.875-1.875 1.875H3.375A1.875 1.875 0 0 1 1.5 14.625v-9.75ZM8.25 9.75a3.75 3.75 0 1 1 7.5 0 3.75 3.75 0 0 1-7.5 0ZM18.75 9a.75.75 0 0 0-.75.75v.008c0 .414.336.75.75.75h.008a.75.75 0 0 0 .75-.75V9.75a.75.75 0 0 0-.75-.75h-.008ZM4.5 9.75A.75.75 0 0 1 5.25 9h.008a.75.75 0 0 1 .75.75v.008a.75.75 0 0 1-.75.75H5.25a.75.75 0 0 1-.75-.75V9.75Z" clip-rule="evenodd" />
                                <path d="M2.25 18a.75.75 0 0 0 0 1.5c5.4 0 10.63.722 15.6 2.075 1.19.324 2.4-.558 2.4-1.82V18.75a.75.75 0 0 0-.75-.75H2.25Z" />
                            </svg>

                        </div>
                        <div class="w-2/3 flex flex-col gap-1 items-end">
                            <p class="font-normal text-base text-gray-800">Total Revenue</p>
                            <h5 class="mb-2 text-2xl font-bold tracking-tight text-gray-900">R 1265.25</h5>
                        </div>
                    </div>
                    
                    <hr class="my-3 border-gray-200 sm:mx-auto" />
                    <NuxtLink to="/slots" class="text-sm hover:underline hover:underline-offset-1 flex justify-start items-center gap-x-2">
                        View all 
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-3 h-3">
                            <path fill-rule="evenodd" d="M12.97 3.97a.75.75 0 0 1 1.06 0l7.5 7.5a.75.75 0 0 1 0 1.06l-7.5 7.5a.75.75 0 1 1-1.06-1.06l6.22-6.22H3a.75.75 0 0 1 0-1.5h16.19l-6.22-6.22a.75.75 0 0 1 0-1.06Z" clip-rule="evenodd" />
                        </svg>
                    </NuxtLink>
                </div>
                <div class="block w-1/4 gap-x-5 p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                    <div class="flex">
                        <div class="w-1/4 h-12 rounded-md bg-gray-800 flex justify-center items-center">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="#fff" class="w-full h-10">
                                <path d="M12.75 12.75a.75.75 0 1 1-1.5 0 .75.75 0 0 1 1.5 0ZM7.5 15.75a.75.75 0 1 0 0-1.5.75.75 0 0 0 0 1.5ZM8.25 17.25a.75.75 0 1 1-1.5 0 .75.75 0 0 1 1.5 0ZM9.75 15.75a.75.75 0 1 0 0-1.5.75.75 0 0 0 0 1.5ZM10.5 17.25a.75.75 0 1 1-1.5 0 .75.75 0 0 1 1.5 0ZM12 15.75a.75.75 0 1 0 0-1.5.75.75 0 0 0 0 1.5ZM12.75 17.25a.75.75 0 1 1-1.5 0 .75.75 0 0 1 1.5 0ZM14.25 15.75a.75.75 0 1 0 0-1.5.75.75 0 0 0 0 1.5ZM15 17.25a.75.75 0 1 1-1.5 0 .75.75 0 0 1 1.5 0ZM16.5 15.75a.75.75 0 1 0 0-1.5.75.75 0 0 0 0 1.5ZM15 12.75a.75.75 0 1 1-1.5 0 .75.75 0 0 1 1.5 0ZM16.5 13.5a.75.75 0 1 0 0-1.5.75.75 0 0 0 0 1.5Z" />
                                <path fill-rule="evenodd" d="M6.75 2.25A.75.75 0 0 1 7.5 3v1.5h9V3A.75.75 0 0 1 18 3v1.5h.75a3 3 0 0 1 3 3v11.25a3 3 0 0 1-3 3H5.25a3 3 0 0 1-3-3V7.5a3 3 0 0 1 3-3H6V3a.75.75 0 0 1 .75-.75Zm13.5 9a1.5 1.5 0 0 0-1.5-1.5H5.25a1.5 1.5 0 0 0-1.5 1.5v7.5a1.5 1.5 0 0 0 1.5 1.5h13.5a1.5 1.5 0 0 0 1.5-1.5v-7.5Z" clip-rule="evenodd" />
                            </svg>
                        </div>
                        <div class="w-2/3 flex flex-col gap-1 items-end">
                            <p class="font-normal text-base text-gray-800">Bookings</p>
                            <h5 class="mb-2 text-3xl font-bold tracking-tight text-gray-900">{{ bookingCount }}</h5>
                        </div>
                    </div>
                    
                    <hr class="my-3 border-gray-200 sm:mx-auto" />
                    <NuxtLink to="/bookings" class="text-sm hover:underline hover:underline-offset-1 flex justify-start items-center gap-x-2">
                        View all 
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-3 h-3">
                            <path fill-rule="evenodd" d="M12.97 3.97a.75.75 0 0 1 1.06 0l7.5 7.5a.75.75 0 0 1 0 1.06l-7.5 7.5a.75.75 0 1 1-1.06-1.06l6.22-6.22H3a.75.75 0 0 1 0-1.5h16.19l-6.22-6.22a.75.75 0 0 1 0-1.06Z" clip-rule="evenodd" />
                        </svg>
                    </NuxtLink>
                </div>
                <div class="block w-1/4 gap-x-5 p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                    <div class="flex">
                        <div class="w-1/4 h-12 rounded-md bg-gray-800 flex justify-center items-center">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="#fff" class="w-full h-10">
                                <path d="M4.5 6.375a4.125 4.125 0 1 1 8.25 0 4.125 4.125 0 0 1-8.25 0ZM14.25 8.625a3.375 3.375 0 1 1 6.75 0 3.375 3.375 0 0 1-6.75 0ZM1.5 19.125a7.125 7.125 0 0 1 14.25 0v.003l-.001.119a.75.75 0 0 1-.363.63 13.067 13.067 0 0 1-6.761 1.873c-2.472 0-4.786-.684-6.76-1.873a.75.75 0 0 1-.364-.63l-.001-.122ZM17.25 19.128l-.001.144a2.25 2.25 0 0 1-.233.96 10.088 10.088 0 0 0 5.06-1.01.75.75 0 0 0 .42-.643 4.875 4.875 0 0 0-6.957-4.611 8.586 8.586 0 0 1 1.71 5.157v.003Z" />
                            </svg>
                        </div>
                        <div class="w-2/3 flex flex-col gap-1 items-end">
                            <p class="font-normal text-base text-gray-800">Employees</p>
                            <h5 class="mb-2 text-3xl font-bold tracking-tight text-gray-900">0</h5>
                        </div>
                    </div>
                    
                    <hr class="my-3 border-gray-200 sm:mx-auto" />
                    <NuxtLink to="" class="text-sm hover:underline hover:underline-offset-1 flex justify-start items-center gap-x-2">
                        View all 
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-3 h-3">
                            <path fill-rule="evenodd" d="M12.97 3.97a.75.75 0 0 1 1.06 0l7.5 7.5a.75.75 0 0 1 0 1.06l-7.5 7.5a.75.75 0 1 1-1.06-1.06l6.22-6.22H3a.75.75 0 0 1 0-1.5h16.19l-6.22-6.22a.75.75 0 0 1 0-1.06Z" clip-rule="evenodd" />
                        </svg>
                    </NuxtLink>
                </div>
                <div class="block w-1/4 gap-x-5 p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                    <div class="flex">
                        <div class="w-1/4 h-12 rounded-md bg-gray-800 flex justify-center items-center">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="#fff" class="w-full h-10">
                                <path fill-rule="evenodd" d="M19.952 1.651a.75.75 0 0 1 .298.599V16.303a3 3 0 0 1-2.176 2.884l-1.32.377a2.553 2.553 0 1 1-1.403-4.909l2.311-.66a1.5 1.5 0 0 0 1.088-1.442V6.994l-9 2.572v9.737a3 3 0 0 1-2.176 2.884l-1.32.377a2.553 2.553 0 1 1-1.402-4.909l2.31-.66a1.5 1.5 0 0 0 1.088-1.442V5.25a.75.75 0 0 1 .544-.721l10.5-3a.75.75 0 0 1 .658.122Z" clip-rule="evenodd" />
                            </svg>
                        </div>
                        <div class="w-2/3 flex flex-col gap-1 items-end">
                            <p class="font-normal text-base text-gray-800">Slots</p>
                            <h5 class="mb-2 text-3xl font-bold tracking-tight text-gray-900">{{ slotCount }}</h5>
                        </div>
                    </div>
                    
                    <hr class="my-3 border-gray-200 sm:mx-auto" />
                    <NuxtLink to="/slots" class="text-sm hover:underline hover:underline-offset-1 flex justify-start items-center gap-x-2">
                        View all 
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-3 h-3">
                            <path fill-rule="evenodd" d="M12.97 3.97a.75.75 0 0 1 1.06 0l7.5 7.5a.75.75 0 0 1 0 1.06l-7.5 7.5a.75.75 0 1 1-1.06-1.06l6.22-6.22H3a.75.75 0 0 1 0-1.5h16.19l-6.22-6.22a.75.75 0 0 1 0-1.06Z" clip-rule="evenodd" />
                        </svg>
                    </NuxtLink>
                </div>
            </div>

            <div class="flex justify-start items-stretch gap-8">
                <!-- latest customers -->
                <div class="flex flex-col w-1/3 gap-x-5 p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                    <div class="flex justify-between items-center">
                        <h3 class="font-medium text-lg">Latest customers</h3>

                        <NuxtLink to="" class="text-sm hover:underline hover:underline-offset-1 flex justify-start items-center gap-x-2">
                            View all 
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-3 h-3">
                                <path fill-rule="evenodd" d="M12.97 3.97a.75.75 0 0 1 1.06 0l7.5 7.5a.75.75 0 0 1 0 1.06l-7.5 7.5a.75.75 0 1 1-1.06-1.06l6.22-6.22H3a.75.75 0 0 1 0-1.5h16.19l-6.22-6.22a.75.75 0 0 1 0-1.06Z" clip-rule="evenodd" />
                            </svg>
                        </NuxtLink>
                    </div>

                    <div class="mt-10">
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <img class="w-8 h-8 rounded-full" src="https://flowbite.com/application-ui/demo/images/users/michael-gough.png" alt="">
                                <p class="text-slate-500">email@flowbite.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R400</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <div class="relative w-6 h-6 overflow-hidden bg-gray-100 rounded-full dark:bg-gray-600">
                                    <svg class="absolute w-8 h-8 text-gray-400 -left-1" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M10 9a3 3 0 100-6 3 3 0 000 6zm-7 9a7 7 0 1114 0H3z" clip-rule="evenodd"></path></svg>
                                </div>
                                <p class="text-slate-500">email@flowbite.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R400</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <img class="w-8 h-8 rounded-full" src="https://flowbite.com/application-ui/demo/images/users/thomas-lean.png" alt="">
                                <p class="text-slate-500">email@flowbite.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R400</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <img class="w-8 h-8 rounded-full" src="https://flowbite.com/application-ui/demo/images/users/neil-sims.png" alt="">
                                <p class="text-slate-500">email@flowbite.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R400</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <img class="w-8 h-8 rounded-full" src="https://flowbite.com/application-ui/demo/images/users/lana-byrd.png" alt="">
                                <p class="text-slate-500">user@gmail.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R400</h3>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- latest bookings -->
                <div class="flex flex-col w-1/3 gap-x-5 p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                    <div class="flex justify-between items-center">
                        <h3 class="font-medium text-lg">Latest bookings</h3>

                        <NuxtLink to="" class="text-sm hover:underline hover:underline-offset-1 flex justify-start items-center gap-x-2">
                            View all 
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-3 h-3">
                                <path fill-rule="evenodd" d="M12.97 3.97a.75.75 0 0 1 1.06 0l7.5 7.5a.75.75 0 0 1 0 1.06l-7.5 7.5a.75.75 0 1 1-1.06-1.06l6.22-6.22H3a.75.75 0 0 1 0-1.5h16.19l-6.22-6.22a.75.75 0 0 1 0-1.06Z" clip-rule="evenodd" />
                            </svg>
                        </NuxtLink>
                    </div>

                    <div class="mt-10">
                        <div class="flex justify-between items-center">
                            <div class="font-medium dark:text-white">
                                <div>Zaza</div>
                                <div class="text-sm text-gray-500 dark:text-gray-400">user@email.com</div>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R400</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="font-medium dark:text-white">
                                <div>Band Of God</div>
                                <div class="text-sm text-gray-500 dark:text-gray-400">user@email.com</div>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R250</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="font-medium dark:text-white">
                                <div>The Mshengu Project</div>
                                <div class="text-sm text-gray-500 dark:text-gray-400">user@email.com</div>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R450</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="font-medium dark:text-white">
                                <div>Musa Sukwene</div>
                                <div class="text-sm text-gray-500 dark:text-gray-400">user@email.com</div>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R400</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="font-medium dark:text-white">
                                <div>Takie Ndou</div>
                                <div class="text-sm text-gray-500 dark:text-gray-400">user@email.com</div>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">R650</h3>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- latest customers -->
                <div class="flex flex-col w-1/3 gap-x-5 p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                    <div class="flex justify-between items-center">
                        <h3 class="font-medium text-lg">Most bookings</h3>

                        <NuxtLink to="" class="text-sm hover:underline hover:underline-offset-1 flex justify-start items-center gap-x-2">
                            View all 
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-3 h-3">
                                <path fill-rule="evenodd" d="M12.97 3.97a.75.75 0 0 1 1.06 0l7.5 7.5a.75.75 0 0 1 0 1.06l-7.5 7.5a.75.75 0 1 1-1.06-1.06l6.22-6.22H3a.75.75 0 0 1 0-1.5h16.19l-6.22-6.22a.75.75 0 0 1 0-1.06Z" clip-rule="evenodd" />
                            </svg>
                        </NuxtLink>
                    </div>

                    <div class="mt-10">
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <img class="w-8 h-8 rounded-full" src="https://flowbite.com/application-ui/demo/images/users/michael-gough.png" alt="">
                                <p class="text-slate-500">email@flowbite.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">13</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <div class="relative w-6 h-6 overflow-hidden bg-gray-100 rounded-full dark:bg-gray-600">
                                    <svg class="absolute w-8 h-8 text-gray-400 -left-1" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M10 9a3 3 0 100-6 3 3 0 000 6zm-7 9a7 7 0 1114 0H3z" clip-rule="evenodd"></path></svg>
                                </div>
                                <p class="text-slate-500">email@flowbite.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">12</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <img class="w-8 h-8 rounded-full" src="https://flowbite.com/application-ui/demo/images/users/thomas-lean.png" alt="">
                                <p class="text-slate-500">email@flowbite.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">8</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <img class="w-8 h-8 rounded-full" src="https://flowbite.com/application-ui/demo/images/users/neil-sims.png" alt="">
                                <p class="text-slate-500">email@flowbite.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">5</h3>
                            </div>
                        </div>
                        <hr class="my-5 border-gray-200 sm:mx-auto" />
                        <div class="flex justify-between items-center">
                            <div class="w-3/4 flex justify-start items-center gap-x-3">
                                <img class="w-8 h-8 rounded-full" src="https://flowbite.com/application-ui/demo/images/users/lana-byrd.png" alt="">
                                <p class="text-slate-500">user@gmail.com</p>
                            </div>
                            <div class="w-1/4 flex justify-end">
                                <h3 class="font-medium text-lg">3</h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import authMiddleware from '~/middleware/auth'

export default{
    data() {
        return {
            slotCount: 0,
            bookingCount: 0
        }
    },
    setup() {
        const setup = () => {
            definePageMeta({
                middleware: [authMiddleware],
                layout: 'default'
            })
        }

        return {
            setup
        }
    },
    created() {
        this.getSlotCount();
        this.getBookingCount();
    },
    methods: {
        async getSlotCount() {
            try {
                const response = await axios.get("https://localhost:7179/api/Slot/GetSlots")
                this.slotCount = response.data.length
            } catch (error) {
                console.log("Can not get slot count:", error.message)
            }
        },
        async getBookingCount() {
            try {
                const response = await axios.get("https://localhost:7179/api/Bookings/GetAllBookings")
                this.bookingCount = response.data.length
            } catch (error) {
                console.log("Can not get slot count:", error.message)
            }
        }
    }
}
</script>
