<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="font-medium text-3xl">Update Rehearsal Slot</h1>

        <form class="mt-16" @submit.prevent="updateTag">
            <div class="mb-6">
                <label for="large-input" class="block mb-5 text-base font-medium text-gray-900 dark:text-white">Tag Name</label>
                <input type="text" id="large-input" v-model="tag.tagName" class="block w-full p-4 text-gray-900 border border-gray-300 rounded-lg bg-gray-50 text-xl focus:ring-blue-500 focus:border-blue-500" placeholder="Tag Name">
            </div>
            <div class="flex justify-end items-center mt-10">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Update Tag</button>
                <NuxtLink to="/tags" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
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
            tag: {
                tagName: '',
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
        this.fetchTag();
    },
    methods : {
        async fetchTag() {
            try {
                const response = await axios.get(`https://localhost:7179/api/Tag/get-tag/${this.id}`)
                this.tag = response.data

            } catch (error) {
                console.log("Could not fetch this tag: ", error.message)
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