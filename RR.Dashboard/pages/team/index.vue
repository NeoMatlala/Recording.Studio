<template>
    <div class="w-full">
        <div class="mt-5 max-w-[95%] mx-auto">
            <div class="flex justify-between items-center mb-10">
                <h1 class="text-3xl text-slate-800 font-medium">Team</h1>
                <NuxtLink to="/team/add" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Add team member</NuxtLink>
            </div>

            <div class="block p-3 bg-white border shadow-sm border-slate-300 rounded-lg">
                <div class="relative overflow-x-auto mb-10">
                    <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                        <thead class="text-xs text-gray-700 uppercase bg-gray-50">
                            <tr>
                                <th scope="col" class="px-6 py-3">
                                    Name
                                </th>
                                <th scope="col" class="px-6 py-3">
                                    Surname
                                </th>
                                <th scope="col" class="px-6 py-3">
                                    Role
                                </th>
                                <th scope="col" class="px-6 py-3"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="odd:bg-white even:bg-gray-50 border-b" v-for="member in team">
                                <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap flex justify-start items-center gap-5">
                                    <div class="relative w-10 h-10 overflow-hidden bg-gray-100 rounded-full dark:bg-gray-600">
                                        <img class="w-full h-full rounded-full" :src="`data:image/png;base64,${member.image}`">
                                    </div>
                                    <div class="text-sm text-gray-500">{{member.name}}</div>
                                    
                                </th>
                                <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                    {{member.surname}}
                                </th>
                                <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">
                                    {{member.title}}
                                </th>
                                <th scope="row" class="px-6 py-4 space-x-5 font-medium text-gray-900 whitespace-nowrap">
                                    <NuxtLink :to="`/team/view/${member.teamId}`" class="text-blue-600 hover:underline">More</NuxtLink> 
                                    <NuxtLink :to="`/team/delete/${member.teamId}`" class="text-red-600 hover:underline">Delete</NuxtLink> 
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
        return{
            team: []
        }
    },
    mounted() {
        this.getTeam();
    },
    methods:{
        async getTeam(){
            try {
                const response = await axios.get('https://localhost:7179/api/Team/get-team-members')
                this.team = response.data
            } catch (error) {
                console.log(error.message)
            }
        }
    }
}
</script>