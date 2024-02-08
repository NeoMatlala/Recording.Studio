<template>
    <div class="flex justify-center items-center mt-28 px-4 md:px-0">
        <div class="max-w-7xl md:mx-auto w-full md:w-2/3">
            <h1 class="text-center  text-4xl md:text-7xl mb-10 md:mb-20 font-medium">Login</h1>

            <!-- incorect password error -->
            <div v-if="showIncorrectPasswordError" class="flex max-w-sm justify-center mx-auto items-start p-4 mb-5 text-sm text-red-800 border border-red-300 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400 dark:border-red-800" role="alert">
                <svg class="flex-shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z"/>
                </svg>
                <span class="sr-only">Info</span>
                <div>
                    <span class="font-medium">{{ errors.incorrectPassword }} </span>
                </div>
            </div>
            <!-- password error -->
            <div v-if="showPasswordError" class="flex max-w-md mx-auto items-start p-4 mb-4 text-sm text-red-800 border border-red-300 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400 dark:border-red-800" role="alert">
                <svg class="flex-shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z"/>
                </svg>
                <span class="sr-only">Info</span>
                <div>
                    <span class="font-medium">{{ errors.passwordErrors[0] }} </span>
                </div>
            </div>

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
                <button type="submit" class="text-black bg-yellow-400 hover:bg-yellow-500 focus:ring-2 focus:outline-none focus:ring-yellow-400 font-medium rounded-lg text-base w-full  px-5 py-2.5 mt-5 text-center">
                    Login
                    <svg v-if="showLoader" aria-hidden="true" role="status" class="inline w-4 h-4 ml-2 me-3 text-gray-200 animate-spin dark:text-gray-600" viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
                        <path d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z" fill="currentColor"/>
                        <path d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z" fill="#1C64F2"/>
                    </svg>
                </Button>
            </form>
            <p class="text-center text-slate-500 font-light mt-4">Don't have an account? 
                <NuxtLink to="/create-account" class="underline underline-offset-2 md:no-underline md:hover:underline">Create an account</NuxtLink>
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
            userId : null,
            errors: {
                incorrectPassword: '',
                passwordErrors: ''
            },
            showIncorrectPasswordError: false,
            showPasswordError: false,
            showLoader: false
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
            this.showLoader = true
            try {
                const response = await axios.post("https://localhost:7179/api/Auth/login", this.user)

                const userId = response.data.userId
                const selectedId = useStateUserId()
                selectedId.value = userId 

                const authToken = response.data.message
                localStorage.setItem('token', authToken)
                localStorage.setItem('varchar', userId)

                if(response.data.isSuccess) {
                    this.showLoader = false
                    this.$router.replace('/manage-bookings')
                }
                
            } catch (error) {
                console.log("Error creating employee: ", error.message);

                if (error.response) {
                    // The request was made and the server responded with a status code that falls out of the range of 2xx
                    console.log("Server response data:", error.response.data);
                    
                    // incorrct password
                    if(error.response.data.message == 'Incorrect Password') {
                        this.errors.incorrectPassword = error.response.data.message
                        this.showPasswordError = false
                        this.showIncorrectPasswordError = true
                    }

                    //password length error
                    if(error.response.data.errors.Password) {
                            this.errors.passwordErrors = error.response.data.errors.Password
                            this.showIncorrectPasswordError = false
                            this.showPasswordError = true
                        }

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