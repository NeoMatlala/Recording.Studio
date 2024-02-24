<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <div class="flex justify-end items-center mt-5">
            <NuxtLink :to="`/blogs/update/${post.blogId}`" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Edit post</NuxtLink>
            <NuxtLink to="/blogs" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Back</NuxtLink>
        </div>

        <div>
            <span id="badge-dismiss-default" class="inline-flex border-[1px] border-slate-400 text-slate-500 items-center px-2 py-1 me-2 text-xs rounded-full" v-for="tag in post.tags">
                {{tag}}
            </span>
        </div>

        <h1 class="font-medium mt-5 mb-4 text-5xl capitalize">{{ post.title }}</h1>

        <p class="text-xl capitalize">{{post.subTitle}}</p>

        <hr class="my-10">
        
        <div class="whitespace-pre-wrap">{{post.body}}</div>
    </div>
</template>

<script>
import axios from 'axios';
import { ref } from 'vue';
import { useRoute } from 'vue-router';

export default{
    data() {
        return {
            post: {}
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
                //console.log(this.post)
            } catch (error) {
                console.log("Could not fetch this blog post: ", error.message)
            }
        }
    }
}
</script>