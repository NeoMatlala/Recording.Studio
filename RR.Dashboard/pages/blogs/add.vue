<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="font-medium text-3xl">Add New blog post</h1>

        <form class="mt-16">
            <div class="mb-6">
                <label for="large-input" class="block mb-2 font-medium text-gray-900 dark:text-white">Title</label>
                <input type="text" id="large-input" class="block w-full p-4 text-gray-900 border border-gray-300 rounded-lg bg-gray-50 text-xl focus:ring-blue-500 focus:border-blue-500" placeholder="Blog title">
            </div>
            <div class="mb-6">
                <label for="large-input" class="block mb-2 font-medium text-gray-900 dark:text-white">Sub heading</label>
                <input type="text" id="large-input" class="block w-full text-gray-900 border border-gray-300 rounded-lg bg-gray-50  focus:ring-blue-500 focus:border-blue-500" placeholder="Blog sub-heading">
            </div>
            
            <div class="flex justify-between items-start gap-10 mb-6">
                <div class="w-full">
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Photo</label>
                    <input required class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none" @change="handleImageUpload" type="file">
                </div> 
                <div class="w-full">
                    <label for="countries" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Tags</label>
                    <select id="countries" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                        <option disabled selected>Choose a tag</option>
                        <option v-for="tag in tags">{{tag.tagName}}</option>
                    </select>

                    <div class="flex justify-start items-center mt-5">
                        <span id="badge-dismiss-default" class="inline-flex border border-blue-400 items-center px-2 py-1 me-2 text-sm font-medium text-blue-800 bg-blue-100 rounded dark:bg-blue-900 dark:text-blue-300">
                            Music
                            <button type="button" class="inline-flex items-center p-1 ms-2 text-sm text-blue-400 bg-transparent rounded-sm hover:bg-blue-200 hover:text-blue-900" data-dismiss-target="#badge-dismiss-default" aria-label="Remove">
                                <svg class="w-2 h-2" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 14">
                                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6"/>
                                </svg>
                                <span class="sr-only">Remove badge</span>
                            </button>
                        </span>
                        <span id="badge-dismiss-default" class="inline-flex border border-blue-400 items-center px-2 py-1 me-2 text-sm font-medium text-blue-800 bg-blue-100 rounded dark:bg-blue-900 dark:text-blue-300">
                            Music
                            <button type="button" class="inline-flex items-center p-1 ms-2 text-sm text-blue-400 bg-transparent rounded-sm hover:bg-blue-200 hover:text-blue-900" data-dismiss-target="#badge-dismiss-default" aria-label="Remove">
                                <svg class="w-2 h-2" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 14">
                                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6"/>
                                </svg>
                                <span class="sr-only">Remove badge</span>
                            </button>
                        </span>
                        <span id="badge-dismiss-default" class="inline-flex border border-blue-400 items-center px-2 py-1 me-2 text-sm font-medium text-blue-800 bg-blue-100 rounded dark:bg-blue-900 dark:text-blue-300">
                            Music
                            <button type="button" class="inline-flex items-center p-1 ms-2 text-sm text-blue-400 bg-transparent rounded-sm hover:bg-blue-200 hover:text-blue-900" data-dismiss-target="#badge-dismiss-default" aria-label="Remove">
                                <svg class="w-2 h-2" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 14">
                                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6"/>
                                </svg>
                                <span class="sr-only">Remove badge</span>
                            </button>
                        </span>
                    </div>
                </div>
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

<script>
import axios from 'axios'

export default{
    data() {
        return{
            tags: []
        }
    },
    mounted() {
        this.getTags()
    },
    methods: {
        handleImageUpload(event) {
            const file = event.target.files[0]
            this.memberObj.image = file
        },
        async getTags(){
            try {
                const response = await axios.get("https://localhost:7179/api/Tag/get-tags")
                this.tags = response.data
            } catch (error) {
                console.log("Error getting tags: ", error.message)
            }
        }
    }
}
</script>