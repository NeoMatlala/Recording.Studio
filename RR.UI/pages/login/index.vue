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
                    <div class="flex">
                        <input :type="showPassword ? 'text' : 'password'" v-model="user.password" id="password" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm  rounded-l-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" required>
                        <span class="inline-flex items-center px-3 text-sm text-gray-900 bg-gray-200 border border-e-0 border-gray-300 rounded-r-lg cursor-pointer" @click="showHidePassword">
                            <svg v-if="!hidePasswordIcon" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M2.036 12.322a1.012 1.012 0 0 1 0-.639C3.423 7.51 7.36 4.5 12 4.5c4.638 0 8.573 3.007 9.963 7.178.07.207.07.431 0 .639C20.577 16.49 16.64 19.5 12 19.5c-4.638 0-8.573-3.007-9.963-7.178Z" />
                                <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z" />
                            </svg>
                            <svg v-if="hidePasswordIcon" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M3.98 8.223A10.477 10.477 0 0 0 1.934 12C3.226 16.338 7.244 19.5 12 19.5c.993 0 1.953-.138 2.863-.395M6.228 6.228A10.451 10.451 0 0 1 12 4.5c4.756 0 8.773 3.162 10.065 7.498a10.522 10.522 0 0 1-4.293 5.774M6.228 6.228 3 3m3.228 3.228 3.65 3.65m7.894 7.894L21 21m-3.228-3.228-3.65-3.65m0 0a3 3 0 1 0-4.243-4.243m4.242 4.242L9.88 9.88" />
                            </svg>

                        </span>
                    </div>
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
    layout: 'default',
    data() {
        return {
            user : {
                email: '',
                password: ''
            },
            showPassword: false,
            hidePasswordIcon : false,
            userId : null
        }
    },
    setup(){
        const selectedId = useStateUserId()

        return {
            selectedId
        }
    },
    methods: {
        async loginUser() {
            try {
                const response = await axios.post("https://localhost:7179/api/Auth/Login", this.user)

                //console.log(response.data)

                const userId = response.data.userId
                const selectedId = useStateUserId()
                selectedId.value = userId 

                const authToken = response.data.message
                localStorage.setItem('token', authToken)
                localStorage.setItem('varchar', userId)

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
        },
        showHidePassword() {
            this.showPassword = !this.showPassword;

            if (this.showPassword) {
                this.hidePasswordIcon = true
            } else {
                this.hidePasswordIcon = false
            }
        }
    }
}
</script>