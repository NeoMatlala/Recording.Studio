<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <!-- <div class="flex justify-between items-start gap-10 h-72 mt-10">
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
        </div> -->
        

        <form class="mt-16" @submit.prevent="updateMember">
            <div class="grid gap-10 mb-6 md:grid-cols-2">
                <div>
                    <label for="first_name" class="block mb-2 text-sm font-medium text-gray-900">Name</label>
                    <input type="text" id="first_name" v-model="memberObj.name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="John" required>
                </div>
                <div>
                    <label for="last_name" class="block mb-2 text-sm font-medium text-gray-900">Surname</label>
                    <input type="text" id="last_name" v-model="memberObj.surname" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Doe" required>
                </div>
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Role</label>
                    <input type="text" id="company" v-model="memberObj.title" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="200" required>
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Photo</label>
                    <input required class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none" @change="handleImageUpload" type="file">
                    <!-- TODO: dynamic image so that when they upload, they can see... even on add page -->
                    <!-- <img :src="`data:image/png;base64,${memberObj.image}`"> -->
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Bio</label>
                    <textarea id="message" rows="4" v-model="memberObj.bio" class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-blue-500 focus:border-blue-500" placeholder="Write bio here..."></textarea>
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Update Team Member</button>
                <NuxtLink to="/team" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
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
        },
        handleImageUpload(event) {
            const file = event.target.files[0]
            this.memberObj.image = file
        },
        async updateMember() {
            try {
                const formData = new FormData()
                formData.append('name', this.memberObj.name)
                formData.append('surname', this.memberObj.surname)
                formData.append('title', this.memberObj.title)
                formData.append('bio', this.memberObj.bio)
                formData.append('image', this.memberObj.image)

                const response = await axios.post(`https://localhost:7179/api/Team/update-team-member/${this.id}`, formData, {
                    headers: {
                        "Content-Type": 'multipart/form-data'
                    }
                })

                console.log(response.data)
                this.$router.replace('/team');
            } catch (error) {
                console.log(error.message)
            }
        }
    }
}
</script>