<template>
    <div>
        <div class="mt-10">
            <div v-for="entry in sortedEmailCountsWithImgUrl" :key="entry[0]">
                <div class="flex justify-between items-center">
                    <div class="w-3/4 flex justify-start items-center gap-x-3">
                        <img class="w-8 h-8 rounded-full" :src="entry[2]" alt="">
                        <p class="text-slate-500">{{ entry[0] }}</p>
                    </div>
                    <div class="w-1/4 flex justify-end">
                        <h3 class="font-medium text-lg">{{ entry[1] }}</h3>
                    </div>
                </div>
                <hr class="my-5 border-gray-200 sm:mx-auto" />
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    data() { 
        return{
            bookings: [],
            userNames: [],
            sortedEmailCounts: [],
            sortedEmailCountsWithImgUrl: []
        }
    },
    mounted(){
        this.getBookings()
    },
    methods: {
        async getBookings() {
            try{
                var response = await axios.get("https://localhost:7179/api/Bookings/get-all-bookings")

                this.bookings = response.data
                
                for(var i = 0; i < this.bookings.length; i++) {
                    this.userNames.push(this.bookings[i].userName)
                }

                this.bookingsCount(this.userNames)

            } catch(error) {
                console.log("Error getting bookings: ", error.message)
            }
        },
        bookingsCount(userEmails ){
            const emailCounts = {}

            userEmails.forEach((email) => {
                emailCounts[email] = (emailCounts[email] || 0) + 1;
            })

            //console.log(emailCounts)
            const emailCountsArray = Object.entries(emailCounts);

            emailCountsArray.sort((a, b) => b[1] - a[1]);

            this.sortedEmailCounts = emailCountsArray

            this.sortedEmailCountsWithImgUrl = this.sortedEmailCounts.map(user => {
                var randomNumber = Math.floor(Math.random() * (999 - 100 + 1)) + 100
                var imageUrl = `https://ozgrozer.github.io/100k-faces/0/0/000${randomNumber}.jpg`

                return [...user, imageUrl]
            })

            //console.log(this.sortedEmailCountsWithImgUrl);
        }
    }
}

</script>