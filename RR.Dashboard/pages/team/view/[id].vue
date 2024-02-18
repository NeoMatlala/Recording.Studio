<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <div class="flex justify-between items-start gap-10 h-72 mt-10">
            <div class="w-full h-full bg-white border border-gray-200 rounded-lg">
                <div class="py-10 flex justify-center items-center">
                    <div class="flex flex-col justify-center items-center">
                        <img class="w-36 h-36 mb-3 object-cover bg-slate-400 rounded-full shadow-sm" :src="`data:image/png;base64,${memberObj.image}`" alt="team member image"/>
                        <h5 class="mb-1 text-xl font-medium text-gray-900 dark:text-white">{{ memberObj.name }} {{ memberObj.surname }}</h5>
                        <span class="text-sm text-gray-500 dark:text-gray-400">{{memberObj.title}}</span>
                    </div>
                </div>
            </div>
            <div class="w-full h-full px-5 py-10 bg-white border border-gray-200 rounded-lg">
                <h3 class="text-2xl font-medium text-gray-900 my-5">Bio</h3>
                <hr class="my-3 border-gray-200 sm:mx-auto" />
                <p class="text-sm leading-6 text-gray-500">{{ memberObj.bio }}</p>
            </div>
        </div>
        

        <div class="flex justify-end items-center mt-10">
            <NuxtLink :to="`/team/update/${memberObj.teamId}`" type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Update Team Member</NuxtLink>
            <NuxtLink to="/team" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import { ref } from 'vue';
import { useRoute } from 'vue-router';

export default{
    data() {
        return {
            memberObj: {},
        }
    },
    setup(){
        const id = ref(useRoute().params.id)

        return {
            id,
        }
    },
    created(){
        this.getMember()
    },
    methods: {
        async getMember() {
            try{
                var response = await axios.get(`https://localhost:7179/api/Team/get-team-member/${this.id}`)
                console.log(response.data)
                this.memberObj = response.data
            } catch(error) {
                console.log("Error getting slots: ", error.message)
            }
        }
    }
}
</script>