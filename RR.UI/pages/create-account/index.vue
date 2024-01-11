<template>
    <div class="flex justify-center items-center">
        <div class="max-w-7xl mx-auto w-2/3">
            <h1 class="text-center text-7xl mb-20 mt-10 font-medium">Create Account</h1>

            <div v-if="errorDisplay" class="flex max-w-lg mx-auto items-center p-4 mb-4 text-sm text-red-800 border border-red-300 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400 dark:border-red-800" role="alert">
                <svg class="flex-shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z"/>
                </svg>
                <span class="sr-only">Info</span>
                <div>
                    <span class="font-medium">{{ errorMessage }} </span>
                </div>
            </div>

            <form class="max-w-sm mx-auto" @submit.prevent="registerUser">
                <div class="mb-5">
                    <label for="email" class="block mb-2 text-sm font-medium text-gray-900 ">Email</label>
                    <input type="email" id="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="name@flowbite.com" v-model="user.email" required>
                </div>
                <div class="mb-5">
                    <label for="password" class="block mb-2 text-sm font-medium text-gray-900 ">Password</label>
                    <input type="password" id="password" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" v-model="user.password" required>
                </div>
                <div class="mb-5">
                    <label for="password" class="block mb-2 text-sm font-medium text-gray-900 ">Confirm Password</label>
                    <input type="password" id="confirmPassword" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" v-model="user.confirmPassword" required>
                </div>
                <button type="submit" class="text-black bg-yellow-400 hover:bg-yellow-500 focus:ring-2 focus:outline-none focus:ring-yellow-400 font-medium rounded-lg text-base w-full  px-5 py-2.5 mt-5 text-center ">Create Account</button>
            </form>
            <p class="text-center text-slate-500 font-light mt-4">Already have an account? 
                <NuxtLink to="/login" class="hover:underline">Login</NuxtLink>
            </p>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data(){
        return {
            user : {
                email: '',
                password: '',
                confirmPassword: '',
            },
            // errorMessage : '',
            // errorDisplay: false
        }
    },
    methods :{
        async registerUser() {
            try {
                const response = await axios.post("https://localhost:7179/api/Auth/Register", this.user)
                console.log(response.data)

                if(response.data.isSuccess) {
                    this.$router.replace('/login')
                }
                
            } catch(error) {
                console.log("Error creating employee: ", error.message);
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
        }
    }
}

</script>