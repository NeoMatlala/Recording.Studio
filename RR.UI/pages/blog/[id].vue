<template>
    <div class="max-w-7xl mx-auto mt-28 px-4 md:px-0">
        <h1 class="font-medium text-5xl leading-snug pt-5 capitalize w-2/3">{{ post.title }}</h1>
        <h3 class="text-3xl font-light leading-snug capitalize my-5">{{post.subTitle}}</h3>

        <div class="flex justify-start items-center">
            <span v-for="tag in post.tags" class="text-slate-500 text-sm font-light me-2 px-5 py-1.5 rounded-full border border-slate-300">{{tag}}</span>
        </div>

        <hr class="mb-12 mt-5">

        <div class="w-full h-[80vh]">
            <img :src="`data:image/png;base64,${post.image}`" class="w-full object-cover h-full" alt="">
        </div>

        <div class="mt-10 whitespace-pre-wrap">{{post.body}}</div>
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