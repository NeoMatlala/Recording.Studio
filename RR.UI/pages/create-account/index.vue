<template>
    <div class="flex justify-center items-center px-4 md:px-0">
        <div class="max-w-7xl mx-auto w-full md:w-2/3">
            <h1 class="text-center text-4xl md:text-7xl mb-10 md:mb-12 mt-20 md:mt-4 font-medium">Create Account</h1>

            <!-- password error -->
            <div v-if="showPasswordError" class="flex max-w-lg mx-auto items-start p-4 mb-4 text-sm text-red-800 border border-red-300 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400 dark:border-red-800" role="alert">
                <svg class="flex-shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z"/>
                </svg>
                <span class="sr-only">Info</span>
                <div>
                    <span class="font-medium">{{ errors.passwordErrors[0] }} </span>
                </div>
            </div>
            <!-- confirm password error -->
            <div v-if="showConfirmPasswordError" class="flex max-w-lg mx-auto items-start p-4 mb-4 text-sm text-red-800 border border-red-300 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400 dark:border-red-800" role="alert">
                <svg class="flex-shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z"/>
                </svg>
                <span class="sr-only">Info</span>
                <div>
                    <span class="font-medium">{{ errors.ConfirmPasswordError[0] }} </span>
                </div>
            </div>
            <!-- password mismatch error -->
            <div v-if="showPasswordMismatchError" class="flex max-w-lg mx-auto justify-center items-start p-4 mb-4 text-sm text-red-800 border border-red-300 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400 dark:border-red-800" role="alert">
                <svg class="flex-shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z"/>
                </svg>
                <span class="sr-only">Info</span>
                <div>
                    <span class="font-medium">Passwords do not match!</span>
                </div>
            </div>
            <!-- username already taken error -->
            <div v-if="usernameAlreadyTaken" class="flex max-w-lg mx-auto justify-center items-start p-4 mb-4 text-sm text-red-800 border border-red-300 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400 dark:border-red-800" role="alert">
                <svg class="flex-shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z"/>
                </svg>
                <span class="sr-only">Info</span>
                <div>
                    <span class="font-medium">{{ errors.alreadyTaken[0] }}</span>
                </div>
            </div>

            <form class="max-w-sm mx-auto" @submit.prevent="registerUser">
                <div class="mb-5">
                    <label for="email" class="block mb-2 text-sm font-medium text-gray-900 ">Email</label>
                    <input type="email" id="email" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="name@email.com" v-model="user.email" required>
                </div>
                <div class="mb-5 relative">
                    <label for="password" class="block mb-2 text-sm font-medium text-gray-900 ">Password</label>

                    <div class="flex">
                        <input :type="showPassword ? 'text' : 'password'" v-model="user.password" id="password" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm  rounded-l-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" required @input="onPasswordInput" @blur="onPasswordBlur">
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

                    <div v-if="user.password.length > 0" class="p-4 opacity-80 rounded min-h-[10vh] shadow absolute -right-[26rem] -top-5">
                        <!-- Your div content goes here -->
                        <p class="font-medium">Password must:</p>
                        <ul class="mt-2 text-sm text-slate-500 list-disc ml-5 space-y-1">
                            <li>Be a minimum length of 5 & maximum length of 50</li>
                            <li>Have at least one non alphanumeric character</li>
                            <li>Have at least one digit ('0'-'9')</li>
                            <li>Have at least one uppercase ('A'-'Z')</li>
                        </ul>
                    </div>
                </div>
                <div class="mb-5">
                    <label for="password" class="block mb-2 text-sm font-medium text-gray-900 ">Confirm Password</label>
                    
                    <div class="flex">
                        <input :type="showPasswordConfirm ? 'text' : 'password'" v-model="user.confirmPassword" id="confirmPassword" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm  rounded-l-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" required>
                        <span class="inline-flex items-center px-3 text-sm text-gray-900 bg-gray-200 border border-e-0 border-gray-300 rounded-r-lg cursor-pointer" @click="showHidePasswordConfirm">
                            <svg v-if="!hidePasswordIconConfirm" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M2.036 12.322a1.012 1.012 0 0 1 0-.639C3.423 7.51 7.36 4.5 12 4.5c4.638 0 8.573 3.007 9.963 7.178.07.207.07.431 0 .639C20.577 16.49 16.64 19.5 12 19.5c-4.638 0-8.573-3.007-9.963-7.178Z" />
                                <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z" />
                            </svg>
                            <svg v-if="hidePasswordIconConfirm" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round" d="M3.98 8.223A10.477 10.477 0 0 0 1.934 12C3.226 16.338 7.244 19.5 12 19.5c.993 0 1.953-.138 2.863-.395M6.228 6.228A10.451 10.451 0 0 1 12 4.5c4.756 0 8.773 3.162 10.065 7.498a10.522 10.522 0 0 1-4.293 5.774M6.228 6.228 3 3m3.228 3.228 3.65 3.65m7.894 7.894L21 21m-3.228-3.228-3.65-3.65m0 0a3 3 0 1 0-4.243-4.243m4.242 4.242L9.88 9.88" />
                            </svg>
                        </span>
                    </div>
                </div>
                <button type="submit" id="button" class="text-black bg-yellow-400 hover:bg-yellow-500 focus:ring-2 focus:outline-none focus:ring-yellow-400 font-medium rounded-lg text-base w-full  px-5 py-2.5 mt-5 text-center ">Create Account</button>

            </form>
            <p class="text-center text-slate-500 font-light mt-5">Already have an account? 
                <NuxtLink to="/login" class="underline underline-offset-2 md:no-underline md:hover:underline">Login</NuxtLink>
            </p>
        </div>

        <!-- success modal -->
        <div id="popup-modal" tabindex="-1" class="hidden overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full">
            <div class="relative p-4 w-full max-w-md max-h-full">
                <div class="relative bg-white rounded-lg shadow">
                    <div class="p-4 md:p-5 text-center">
                        <svg class="mx-auto mb-4 text-gray-400 w-12 h-12" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 11V6m0 8h.01M19 10a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z"/>
                        </svg>
                        <h3 class="mb-5 text-lg font-normal text-gray-5000">Account Successfully created!</h3>
                        <button id="closeButton" type="button" class="text-gray-500 bg-white hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-gray-200 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Login</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
import { onMounted } from 'vue'
import { Modal } from 'flowbite'

export default{
    data(){
        return {
            user : {
                email: '',
                password: '',
                confirmPassword: '',
            },
            showPassword: false,
            hidePasswordIcon : false,
            showPasswordConfirm: false,
            hidePasswordIconConfirm : false,
            errors: {
                passwordErrors: '',
                ConfirmPasswordError: '',
                alreadyTaken: '',
            },
            showPasswordError: false,
            showConfirmPasswordError: false,
            showPasswordMismatchError: false,
            usernameAlreadyTaken: false,
        }
    },
    setup(){
        // onMounted(() => {
        //     const $buttonElement = document.querySelector('#button');
        //     const $modalElement = document.querySelector('#popup-modal');
        //     const $closeButton = document.querySelector('#closeButton');
        //     const modalOptions = {
        //         backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
        //     }
        //     if ($modalElement) {
        //         const modal = new Modal($modalElement, modalOptions);
        //         $buttonElement.addEventListener('click', () => modal.toggle());
        //         $closeButton.addEventListener('click', () => modal.hide());
        //     }
        // })
    },
    methods :{
        async registerUser() {
            const $modalElement = document.querySelector('#popup-modal');
            const $closeButton = document.querySelector('#closeButton');
            const modalOptions = {
                backdrop: 'static',
                backdropClasses: 'bg-gray-900 bg-opacity-50 fixed inset-0 z-40'
            }

            if (this.user.password !== this.user.confirmPassword) {
                console.log('Passwords fo not match')
                this.showPasswordMismatchError = true
            } else {
                try {
                    const response = await axios.post("https://localhost:7179/api/Auth/Register", this.user)
                    console.log(response.data)

                    if(response.data.isSuccess) {
                        const $modalElement = document.querySelector('#popup-modal');

                        if ($modalElement) {
                            const modal = new Modal($modalElement, modalOptions);
                            modal.toggle();
                            $closeButton.addEventListener('click', () => {
                                this.$router.push('/login')
                                modal.hide()
                                
                            });
                        }
                    }
                    
                } catch(error) {
                    console.log("Error creating employee: ", error.message);
                    if (error.response) {
                        // The request was made and the server responded with a status code
                        // that falls out of the range of 2xx
                        console.log("Server response data:", error.response.data);

                        //password length error
                        if(error.response.data.errors.Password) {
                            this.errors.passwordErrors = error.response.data.errors.Password
                            this.showPasswordError = true
                        }

                        //Confirm password length error
                        if(error.response.data.errors.ConfirmPassword) {
                            this.errors.ConfirmPasswordError = error.response.data.errors.ConfirmPassword
                            console.log(`Password errors: ${this.errors.ConfirmPasswordError}`)
                            this.showConfirmPasswordError = true
                        }

                        // username taken
                        if(error.response.data.errors) {
                            this.errors.alreadyTaken = error.response.data.errors
                            this.usernameAlreadyTaken = true
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
            }
            
            
        },
        showHidePassword() {
            this.showPassword = !this.showPassword;

            if (this.showPassword) {
                this.hidePasswordIcon = true
            } else {
                this.hidePasswordIcon = false
            }
        },
        showHidePasswordConfirm() {
            this.showPasswordConfirm = !this.showPasswordConfirm;

            if (this.showPasswordConfirm) {
                this.hidePasswordIconConfirm = true
            } else {
                this.hidePasswordIconConfirm = false
            }
        }
    }
}

</script>