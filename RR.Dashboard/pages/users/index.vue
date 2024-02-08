<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <h1 class="text-3xl text-slate-800 font-medium mb-10">Users</h1>

            <div class="block p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                <div class="relative overflow-x-auto mb-10">
                    <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                        <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                            <tr>
                                <th scope="col" class="px-6 py-3">
                                    Email address
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="odd:bg-white even:bg-gray-50 border-b" v-for="user in users">
                                <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                    {{user.email}}
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    data() {
        return {
            users: []
        }
    },
    mounted() {
        this.getUsers()
    },
    methods: {
        async getUsers() {
            try {
                var response = await axios.get("https://localhost:7179/api/Users/get-all-users")
                this.users = response.data
            } catch (error) {
                console.log("Error getting users", error.message)
            }
        }
    }
}
</script>