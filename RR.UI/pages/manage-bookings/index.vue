<template>
    <div class="flex justify-center items-center">
        <div class="max-w-7xl mx-auto w-2/3">
            <h1 class="text-center text-7xl mb-16 font-medium">Manage bookings</h1>

            <div class="max-w-2xl mx-auto flex justify-between items-center gap-5">
                <NuxtLink class="bg-slate-200 hover:bg-slate-300 w-1/2 p-6 h-60 ">
                    <h1 class="text-3xl font-medium">Book Rehearsal space</h1>
                    <p class="mt-4 font-light text-slate-500">
                        Perfect your performance in our state-of-the-art rehearsal spaces designed to amplify your musical potential.
                    </p>
                </NuxtLink>
                <NuxtLink class="bg-slate-200 hover:bg-slate-300 w-1/2 p-6 h-60 ">
                    <h1 class="text-3xl font-medium">Book Recording Equipment</h1>
                    <p class="mt-4 font-light text-slate-500">
                        Elevate your music journey—book recording sessions and achieve sonic perfection through our expert mixing and mastering services.
                    </p>
                </NuxtLink>
            </div>
        </div>
    </div>
</template>

<script setup>
definePageMeta({
  //layout: 'bookings',
  middleware: [
    'auth'
  ]
})
</script>
