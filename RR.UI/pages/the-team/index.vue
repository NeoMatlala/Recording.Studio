<template>
    <div class="max-w-7xl mx-auto mt-28 px-4 md:px-0">
        <h1 class="text-4xl md:text-center font-medium mt-10 md:w-2/3 mx-auto mb-5">Meet the team</h1>
        <p class="text-base md:text-center">Elevating Soundscapes with the Industry's Finest – Where Mastery Meets Music</p>

        <div class="mt-10 flex flex-col md:flex-row justify-start gap-8 md:gap-5 items-start">
            <div class="w-full md:w-1/4" v-for="member in team">
                <img :src="`data:image/png;base64,${member.image}`" alt="team member image" class="w-full object-cover h-96">
                <h4 class="md:mb-1 mt-2 font-medium text-xl">{{member.name}} {{member.surname}}</h4>
                <h4 class="text-base font-light mb-5">{{member.title}}</h4>
                <p class="text-sm leading-6 text-gray-500">{{ member.bio }}</p>
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