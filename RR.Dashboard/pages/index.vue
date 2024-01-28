<template>
    <div>
        <div class="w-full">
            <div class="">
                <h1 class="text-center text-4xl mb-16 font-medium">Login into dashboard</h1>

                <form class="max-w-sm mx-auto" @submit.prevent="checkAdmin">
                    <div class="mb-5">
                        <label for="email" class="block mb-2 text-sm font-medium text-gray-900">Email</label>
                        <input type="email" id="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="something@admin.com" v-model="user.email" required>
                    </div>
                    <div class="mb-5">
                        <label for="password" class="block mb-2 text-sm font-medium text-gray-900">Password</label>
                        <div class="flex">
                            <input :type="showPassword ? 'text' : 'password'" v-model="user.password" id="password" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm  rounded-l-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" required placeholder="••••••••">
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
                    <button type="submit" class="text-white bg-blue-500 hover:bg-blue-600 focus:ring-2 focus:outline-none focus:ring-blue-400 font-medium rounded-lg text-base w-full  px-5 py-2.5 mt-5 text-center">
                        Login
                        <svg v-if="showLoader" aria-hidden="true" role="status" class="inline w-4 h-4 ml-2 me-3 text-gray-200 animate-spin dark:text-gray-600" viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
                            <path d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z" fill="currentColor"/>
                            <path d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z" fill="#1C64F2"/>
                        </svg>
                    </Button>

                    <div v-if="showAccountError" class="flex mt-10 items-center p-4 mb-4 text-sm text-red-800 border border-red-300 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400 dark:border-red-800" role="alert">
                        <svg class="flex-shrink-0 inline w-6 h-6 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                            <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z"/>
                        </svg>
                        <span class="sr-only">Info</span>
                        <div>
                            <span class="font-medium">Not an admin account.</span> Please use admin credentials & try again.
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    //layout: 'default',
    setup(){
        const setup = () => {
            definePageMeta({
                layout: 'account'
            })
        }

        return {
            setup
        }
    },
    data() {
        return {
            user : {
                email: '',
                password: ''
            },
            showPassword: false,
            hidePasswordIcon : false,
            showAccountError: false,
            showLoader: false
        }
    },
    mounted() {
        const redirect = localStorage.getItem('redirectedFromAuthMiddleware')

        console.log(redirect)

        if(redirect === 'true') {
            localStorage.removeItem('redirectedFromAuthMiddleware')
            window.location.reload(true)
        }
        
    },
    methods: {
        checkAdmin(){
            if(this.user.email != 'admin@rr.com') {
                this.showAccountError = true
            } else {
                console.log(' admin')
                this.loginUser(this.user)
            }
        },
        async loginUser(user) {
            this.showLoader = true
            try {
                const response = await axios.post("https://localhost:7179/api/Auth/Login", user)

                console.log(response.data)

                const authToken = response.data.message
                localStorage.setItem('token', authToken)

                if(response.data.isSuccess) {
                    this.showLoader = false
                    this.$router.replace('/dashboard')
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