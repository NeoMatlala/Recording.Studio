<template>
    <div class="flex justify-center items-center">
        <div class="max-w-7xl mx-auto w-2/3">
            <h1 class="text-center text-7xl mb-20 font-medium">Login</h1>

            <form class="max-w-sm mx-auto" @submit.prevent="loginUser">
                <div class="mb-5">
                    <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Email</label>
                    <input type="email" id="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="name@flowbite.com" v-model="user.email" required>
                </div>
                <div class="mb-5">
                    <label for="password" class="block mb-2 text-sm font-medium text-gray-900">Password</label>
                    <input type="password" v-model="user.password" id="password" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" required>
                </div>
                <button type="submit" class="text-black bg-yellow-400 hover:bg-yellow-500 focus:ring-2 focus:outline-none focus:ring-yellow-400 font-medium rounded-lg text-base w-full  px-5 py-2.5 mt-5 text-center">Login</Button>
            </form>
            <p class="text-center text-slate-500 font-light mt-4">Don't have an account? 
                <NuxtLink to="/create-account" class="hover:underline">Create an account</NuxtLink>
            </p>

        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data() {
        return {
            user : {
                email: '',
                password: ''
            }
        }
    },
    methods: {
        async loginUser() {
            try {
                const response = await axios.post("https://localhost:7179/api/Auth/Login", this.user)

                console.log(response.data)

                const authToken = response.data.message
                localStorage.setItem('token', authToken)

                if(response.data.isSuccess) {
                    this.$router.replace('/manage-bookings')
                }
            } catch (error) {
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