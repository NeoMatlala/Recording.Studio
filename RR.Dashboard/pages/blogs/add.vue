<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="font-medium text-3xl">Add New blog post</h1>

        <form class="mt-16">
            <div class="mb-6">
                <label for="large-input" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Title</label>
                <input type="text" id="large-input" class="block w-full p-4 text-gray-900 border border-gray-300 rounded-lg bg-gray-50 text-xl focus:ring-blue-500 focus:border-blue-500" placeholder="Blog title">
            </div>
            <div class="mb-6">
                <label for="large-input" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Sub heading</label>
                <input type="text" id="large-input" class="block w-full p-4 text-gray-900 border border-gray-300 rounded-lg bg-gray-50 text-lg focus:ring-blue-500 focus:border-blue-500" placeholder="Blog sub-heading">
            </div>
            <div>
                <label for="message" class="block mb-2 text-sm font-medium text-gray-900">Blog Post</label>
                <textarea id="message" rows="20" class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 whitespace-pre-wrap focus:ring-blue-500 focus:border-blue-500" placeholder="Write the blog body here..."></textarea>
            </div>
            <div class="flex justify-end items-center mt-10">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Publish blog post</button>
                <NuxtLink to="/blogs" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>