<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="font-medium text-3xl">Add New blog post</h1>

        <form class="mt-16" @submit.prevent="createBlogPost">
            <div class="mb-6">
                <label for="large-input" class="block mb-2 font-medium text-gray-900 dark:text-white">Title</label>
                <input type="text" required v-model="post.title" id="large-input" class="block w-full p-4 text-gray-900 border border-gray-300 rounded-lg bg-gray-50 text-xl focus:ring-blue-500 focus:border-blue-500" placeholder="Blog title">
            </div>
            <div class="mb-6">
                <label for="large-input" class="block mb-2 font-medium text-gray-900 dark:text-white">Sub heading</label>
                <input type="text" v-model="post.subTitle" required id="large-input" class="block w-full text-gray-900 border border-gray-300 rounded-lg bg-gray-50  focus:ring-blue-500 focus:border-blue-500" placeholder="Blog sub-heading">
            </div>
            
            <div class="flex justify-between items-start gap-10 mb-6">
                <div class="w-full">
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Photo</label>
                    <input class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none" @change="handleImageUpload" type="file">
                </div> 
                <div class="w-full">
                    <label for="countries" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Tags</label>
                    <select id="countries" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" @change="addTag">
                        <option disabled selected>Choose a tag</option>
                        <option v-for="tag in tags" :key="tag.tagId" :value="tag.tagId">{{tag.tagName}}</option>
                    </select>

                    <div class="flex justify-start items-center mt-5">
                        <span id="badge-dismiss-default" class="inline-flex border border-blue-400 items-center px-2 py-1 me-2 text-sm font-medium text-blue-800 bg-blue-100 rounded dark:bg-blue-900 dark:text-blue-300" v-for="(tag, index) in selectedTags" :key="index">
                            {{ tag.tagName }}
                            <button @click="removeTag(index)" type="button" class="inline-flex items-center p-1 ms-2 text-sm text-blue-400 bg-transparent rounded-sm hover:bg-blue-200 hover:text-blue-900" data-dismiss-target="#badge-dismiss-default" aria-label="Remove">
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
                <textarea id="message" required rows="20" v-model="post.body" class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 whitespace-pre-wrap focus:ring-blue-500 focus:border-blue-500" placeholder="Write the blog body here..."></textarea>
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
            tags: [],
            selectedTags: [],
            tagIds: [],
            post: {
                title: '',
                subTitle: '',
                datePublished: '',
                body: '',
                image: '',
                tagIds: null
            }
        }
    },
    mounted() {
        this.getTags()
    },
    methods: {
        addTag(event) {
            const tagId = parseInt(event.target.value);

            const tag = this.tags.find(tag => tag.tagId === tagId);

            if (tag && !this.selectedTags.includes(tag)) {
                this.selectedTags.push(tag);
                this.tagIds.push(tag.tagId);
            }

            //console.log(this.tagIds)
        },
        removeTag(index) {
            this.selectedTags.splice(index, 1);
            this.tagIds.splice(index, 1);
            //console.log(this.tagIds)
        },
        handleImageUpload(event) {
            const file = event.target.files[0]
            this.post.image = file
        },
        async getTags(){
            try {
                const response = await axios.get("https://localhost:7179/api/Tag/get-tags")
                this.tags = response.data
            } catch (error) {
                console.log("Error getting tags: ", error.message)
            }
        },
        async createBlogPost() {
            this.post.datePublished = this.currentDate()
            this.post.tagIds = this.tagIds

            try {
                const formData = new FormData()
                formData.append('title', this.post.title)
                formData.append('subTitle', this.post.subTitle)
                formData.append('datePublished', this.currentDate())
                formData.append('body', this.post.body)
                formData.append('image', this.post.image)
                 this.tagIds.forEach(tagId => {
                    formData.append('tagIds', tagId);
                });

                const response = await axios.post('https://localhost:7179/api/Blog/create-blog-post', formData, {
                    headers: {
                        "Content-Type": 'multipart/form-data'
                    }
                })

                console.log(response.data)
                this.$router.replace('/blogs');
            } catch (error) {
                console.log("Error creating blog: ", error.message);

                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    console.log("Server response data:", error.response.data);
                    // this.errorDisplay = true
                    // this.errorMessage = error.response.data.message
                    console.log("Status code:", error.response.status);
                } else if (error.request) {
                    // The request was made but no response was received
                    console.log("No response received from the server");
                } else {
                    // Something happened in setting up the request that triggered an Error
                    console.log("Error:", error.message);
                }
            }
        },
        currentDate() {
            const currentDate = new Date();

            const year = currentDate.getFullYear();
            const month = String(currentDate.getMonth() + 1).padStart(2, '0'); // Months are zero-indexed, so we add 1
            const day = String(currentDate.getDate()).padStart(2, '0');

            const formattedDate = `${year}-${month}-${day}`;

            return formattedDate 
        }
    }
}
</script>