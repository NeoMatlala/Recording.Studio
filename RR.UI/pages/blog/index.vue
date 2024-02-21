<template>
    <div class="max-w-7xl mx-auto mt-28 px-4 md:px-0">
        <!-- hero -->
        <div class="flex justify-between gap-5">
            <!-- LHS -->
            <div class="w-1/4 flex-1">
                <!-- <h1 class="text-2xl mb-5 font-medium">Latest blogs</h1> -->
                <ul>
                    <li>
                        <div class="w-full h-36 mb-2">
                            <img src="../../assets/img/studio.jpg" class="w-full object-cover h-full" alt="">
                        </div>
                        <NuxtLink to="blog/view" class="hover:underline text-lg -mb-1">Music Festivals Unveiled: Insider Tips for Navigating the Ultimate Music Experience</NuxtLink>
                        <hr class="my-4">
                    </li>
                    <li>
                        <NuxtLink to="blog/view" class="text-lg hover:underline">The Global Sound: Exploring Music from Around the World</NuxtLink>
                        <hr class="my-4">
                    </li>
                    <li>
                        <NuxtLink to="blog/view" class="text-lg hover:underline">Music and Mental Health: Healing Harmonies and Therapeutic Rhythms</NuxtLink>
                        <hr class="my-4">
                    </li>
                    <li>
                        <NuxtLink to="blog/view" class="text-lg -mb-1 hover:underline">Music Theory</NuxtLink>
                        <div class="w-full h-36 mt-5">
                            <img src="../../assets/img/studio-2.jpg" class="w-full object-cover h-full" alt="">
                        </div>
                    </li>
                </ul>
            </div>

            <!-- MAin Center -->
            <div class="w-2/4">
                <div class=" md:h-[65vh] 2xl:h-[40vh]">
                    <img src="../../assets/img/artist-1.jpg" class="w-full object-cover h-full" alt="">
                </div>
                <div class="mt-5">
                    <div class="">
                        <NuxtLink to="blog/view" class="text-5xl hover:underline leading-12">Why average musicians deserve average pay!</NuxtLink>
                    </div>
                    <div class="mt-5">
                        <p class="text-md leading-8 font-light  mb-8">Exploring the Link Between Skill Level and Compensation: Why Fair Compensation Reflects the Value of Average Musicians in the Music Industry. Exploring the Link Between Skill Level and Compensation: Why Fair Compensation Reflects the Value of Average Musicians in the Music Industry</p>
                    </div>
                </div>
            </div>

            <!-- RHS -->
            <div class="w-1/4 flex-1">
                <!-- <h1 class="text-2xl mb-5 font-medium">Latest blogs</h1> -->
                <ul>
                    <li>
                        <NuxtLink to="blog/view" class="text-lg hover:underline block mb-2">Music Theory</NuxtLink>
                        <small class="text-slate-500 font-light">Unlocking Musical Mastery: Essential Concepts and Techniques for Understanding and Creating Beautiful Melodies.</small>
                        <hr class="my-8">
                    </li>
                    <li>
                        <NuxtLink to="blog/view" class="text-lg hover:underline block">Master your basics</NuxtLink>
                        <small class="text-slate-500 font-light">Unlock Your Musical Potential: Delve Deep into Fundamental Skills to Master Your Musical Journey.</small>
                        <hr class="my-8">
                    </li>
                    <li>
                        <NuxtLink to="blog/view" class="text-lg hover:underline block mb-2">Top 10 Keyboards</NuxtLink>
                        <small class="text-slate-500 font-light">Discover the Best: Dive into Reviews and Rankings to Find Your Ideal Keyboard Among the Top 10 Choices..</small>
                        <hr class="my-8">
                    </li>
                    <li>
                        <NuxtLink to="blog/view" class="text-lg hover:underline block">Music Theory</NuxtLink>
                        <small class="text-slate-500 font-light">All you need to be a musician</small>
                    </li>
                    
                </ul>
            </div>
        </div>

        <hr class="my-12">

        <!-- rest of articles -->
        <div class="grid grid-cols-4 gap-10">
            <div class="border border-slate-200">
                <div class="w-full h-64 mb-2">
                    <img src="../../assets/img/artist-4.jpg" class="w-full object-cover h-full" alt="">
                </div>
                <div class="p-3 pb-5">
                    <NuxtLink to="blog/view" class="text-xl hover:underline -mb-1">Exploring the Evolution of Jazz: From its Roots to Modern Innovations</NuxtLink>
                </div>
            </div>
            <div class="border border-slate-200">
                <div class="w-full h-64 mb-2">
                    <img src="../../assets/img/artist-3.jpg" class="w-full object-cover h-full" alt="">
                </div>
                <div class="p-3 pb-5">
                    <NuxtLink to="blog/view" class="text-xl hover:underline -mb-1">The Power of Lyrics: How Songwriting Shapes Emotions and Perspectives</NuxtLink>
                </div>
            </div>
            <div class="border border-slate-200">
                <div class="w-full h-64 mb-2">
                    <img src="../../assets/img/artist-2.jpg" class="w-full object-cover h-full" alt="">
                </div>
                <div class="p-3 pb-5">
                    <NuxtLink to="blog/view" class="text-xl hover:underline -mb-1">Breaking Down Barriers: Women Making Waves in the Music Industry</NuxtLink>
                </div>
            </div>
            <div class="border border-slate-200">
                <div class="w-full h-64 mb-2">
                    <img src="../../assets/img/artist-1.jpg" class="w-full object-cover h-full" alt="">
                </div>
                <div class="p-3 pb-5">
                    <NuxtLink to="blog/view" class="text-xl hover:underline -mb-1">Behind the Beat: Unraveling the Mysteries of Music Production</NuxtLink>
                </div>
            </div>
            <div class="border border-slate-200">
                <div class="w-full h-64 mb-2">
                    <img src="../../assets/img/studio.jpg" class="w-full object-cover h-full" alt="">
                </div>
                <div class="p-3 pb-5">
                    <NuxtLink to="blog/view" class="text-xl hover:underline -mb-1">From Classical to Contemporary: Understanding Music Genres and Their Influence</NuxtLink>
                </div>
            </div>
            <div class="border border-slate-200">
                <div class="w-full h-64 mb-2">
                    <img src="../../assets/img/studio-3.jpg" class="w-full object-cover h-full" alt="">
                </div>
                <div class="p-3 pb-5">
                    <NuxtLink to="blog/view" class="text-xl hover:underline -mb-1">The Impact of Technology on Music: Navigating the Digital Revolution</NuxtLink>
                </div>
            </div>
            <div class="border border-slate-200">
                <div class="w-full h-64 mb-2">
                    <img src="../../assets/img/studio-2.jpg" class="w-full object-cover h-full" alt="">
                </div>
                <div class="p-3 pb-5">
                    <NuxtLink to="blog/view" class="text-xl hover:underline -mb-1">Breaking Down Barriers: Women Making Waves in the Music Industry</NuxtLink>
                </div>
            </div>
        </div>
    </div>
</template>