<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="font-medium text-3xl">Add New blog post</h1>

        <form class="mt-16">
            <div class="mb-6">
                <label for="large-input" class="block mb-2 font-medium text-gray-900 dark:text-white">Title</label>
                <input type="text" v-model="post.title" id="large-input" class="block w-full p-4 text-gray-900 border border-gray-300 rounded-lg bg-gray-50 text-xl focus:ring-blue-500 focus:border-blue-500" placeholder="Blog title">
            </div>
            <div class="mb-6">
                <label for="large-input" class="block mb-2 font-medium text-gray-900 dark:text-white">Sub heading</label>
                <input type="text" v-model="post.subTitle" id="large-input" class="block w-full text-gray-900 border border-gray-300 rounded-lg bg-gray-50  focus:ring-blue-500 focus:border-blue-500" placeholder="Blog sub-heading">
            </div>
            
            <div class="flex justify-between items-start gap-10 mb-6">
                <div class="w-full">
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Photo</label>
                    <input required class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none" type="file">
                </div> 
                <div class="w-full">
                    <label for="countries" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Tags</label>
                    <!-- <select id="countries" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                        <option disabled selected>Choose a tag</option>
                        <option v-for="tag in tags">{{tag.tagName}}</option>
                    </select> -->

                    <div class="flex justify-start items-center mt-5">
                        <span id="badge-dismiss-default" class="inline-flex border border-blue-400 items-center px-2 py-1 me-2 text-sm font-medium text-blue-800 bg-blue-100 rounded dark:bg-blue-900 dark:text-blue-300" v-for="tag in post.tags">
                            {{tag}}
                        </span>
                        
                    </div>
                </div>
            </div>
            <div>
                <label for="message" class="block mb-2 text-sm font-medium text-gray-900">Blog Post</label>
                <textarea id="message" v-model="post.body" rows="20" class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 whitespace-pre-wrap focus:ring-blue-500 focus:border-blue-500" placeholder="Write the blog body here..."></textarea>
            </div>
            <div class="flex justify-end items-center mt-10">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Publish blog post</button>
                <NuxtLink to="/blogs" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios';
import { ref } from 'vue';
import { useRoute } from 'vue-router';

export default{
    data() {
        return {
            post: {
                tagName: '',
                title: '',
                subTitle: '',
                datePublished: '',
                body: '',
                image: '',
                tags: []
            }
        }
    },
    setup() {
        const id = ref(useRoute().params.id)

        return {
            id,
        }
    },
    created() {
        this.fetchPost();
    },
    methods : {
        async fetchPost() {
            try {
                const response = await axios.get(`https://localhost:7179/api/Blog/get-blog-post/${this.id}`)
                this.post = response.data
                console.log(this.post)
            } catch (error) {
                console.log("Could not fetch this blog post: ", error.message)
            }
        },
        async updateTag() {
            try {
                const response = await axios.put(`https://localhost:7179/api/Tag/update-tag/${this.id}`, this.tag)
                this.$router.replace('/tags');
            } catch (error) {
                console.log("Could not update this tag: ", error.message)
            }
        }
    }
}
</script>