<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <div class="flex justify-end items-center mt-5">
            <a id="button" class="text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Delete blog post</a>
            <NuxtLink to="/blogs" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Back</NuxtLink>
        </div>

        <form @submit.prevent="handleDelete">
            <div>
                <span id="badge-dismiss-default" class="inline-flex border-[1px] border-slate-400 text-slate-500 items-center px-2 py-1 me-2 text-xs rounded-full" v-for="tag in post.tags">
                    {{tag}}
                </span>
            </div>

            <h1 class="font-medium mt-5 mb-4 text-5xl capitalize">{{ post.title }}</h1>

            <p class="text-xl capitalize">{{post.subTitle}}</p>

            <hr class="my-10">

            <div class="w-full h-[90vh] mb-12">
                <img class="w-full h-full object-cover bg-slate-400" :src="`data:image/png;base64,${post.image}`" alt="blog image"/>
            </div>
            
            <div class="whitespace-pre-wrap">{{post.body}}</div>

            <!-- delete modal -->
            <div id="popup-modal" tabindex="-1" class="hidden overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full">
                <div class="relative p-4 w-full max-w-md max-h-full">
                    <div class="relative bg-white rounded-lg shadow">
                        <div class="p-4 md:p-5 text-center">
                            <svg class="mx-auto mb-4 text-gray-400 w-12 h-12" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 11V6m0 8h.01M19 10a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"/>
                            </svg>
                            <h3 class="mb-5 text-lg font-normal text-gray-5000">Are you sure you want to delete blog post: {{ post.title }} ?</h3>
                            <button type="submit" class="text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm inline-flex items-center px-5 py-2.5 text-center me-2">
                                Yes, I'm sure
                            </button>
                            <button id="closeButton" type="button" class="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">No, cancel</button>
                        </div>
                    </div>
                </div>
            </div>
        </form>

        
    </div>
</template>

<script>
import axios from 'axios';
import { ref } from 'vue';
import { useRoute } from 'vue-router';
import { onMounted } from 'vue'
import { Modal } from 'flowbite'

export default{
    data() {
        return {
            post: {}
        }
    },
    setup() {
        const id = ref(useRoute().params.id)

        onMounted(() => {
            const $buttonElement = document.querySelector('#button');
            const $modalElement = document.querySelector('#popup-modal');
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }
            if ($modalElement) {
                const modal = new Modal($modalElement, modalOptions);
                $buttonElement.addEventListener('click', () => modal.toggle());
                $closeButton.addEventListener('click', () => modal.hide());
            }
        })

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
        },
        async handleDelete() {
            const $modalElement = document.querySelector('#popup-modal');
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }

            try {
                const response = await axios.delete(`https://localhost:7179/api/Blog/delete-blog-post/${this.id}`)
                console.log(response.data)

                if ($modalElement) {
                    const modal = new Modal($modalElement, modalOptions);
                    $closeButton.addEventListener('click', () => modal.hide());
                }

                this.$router.replace('/blogs');
            } catch (error) {
                console.log("Could not update this slot: ", error.message)
            }
        }
    }
}
</script>