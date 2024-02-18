<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <h1 class="font-medium text-3xl">Add team member</h1>

        

        <form class="mt-16" @submit.prevent="createMember">
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
                    <input type="text" id="company" v-model="memberObj.title" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Lead engineer" required>
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Photo</label>
                    <input required class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none" @change="handleImageUpload" type="file">
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900">Bio</label>
                    <textarea id="message" rows="4" v-model="memberObj.bio" class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-blue-500 focus:border-blue-500" required placeholder="Write bio here..."></textarea>
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Create Team Member</button>
                <NuxtLink to="/slots" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data(){
        return{
            memberObj:{
                name: '',
                surname: '',
                title: '',
                bio: '',
                image: null
            },
        }
    },
    methods: {
        handleImageUpload(event) {
            const file = event.target.files[0]
            this.memberObj.image = file
        },
        async createMember() {
            try {
                const formData = new FormData()
                formData.append('name', this.memberObj.name)
                formData.append('surname', this.memberObj.surname)
                formData.append('title', this.memberObj.title)
                formData.append('bio', this.memberObj.bio)
                formData.append('image', this.memberObj.image)

                const response = await axios.post('https://localhost:7179/api/Team/create-team-member', formData, {
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