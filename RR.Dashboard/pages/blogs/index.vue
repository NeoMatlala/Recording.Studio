<template>
    <div class="mt-5 max-w-[95%] mx-auto">
        <div class="flex justify-between items-center mb-10">
            <h1 class="text-3xl text-slate-800 font-medium">Blog Posts</h1>
            <NuxtLink to="/blogs/add" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Add blog post</NuxtLink>
        </div>

        <div class="relative overflow-x-auto sm:rounded-lg">
            <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                    <tr>
                        <th scope="col" class="px-6 py-3">
                            Blog title
                        </th>
                        <th scope="col" class="px-6 py-3">
                            Blog sub-heading
                        </th>
                        <th scope="col" class="px-6 py-3">
                            Date published
                        </th>
                        <th scope="col" class="px-6 py-3"></th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700" v-for="post in blogs">
                        <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                            {{ post.title}}
                        </th>
                        <td class="px-6 py-4">
                           {{ post.subTitle }}
                        </td>
                        <td class="px-6 py-4">
                            {{ post.datePublished }}
                        </td>
                        <td class="px-6 py-4 space-x-5 font-medium text-gray-900 whitespace-nowrap">
                            <!-- <NuxtLink to="blogs/view" class="text-blue-600 hover:underline">View</NuxtLink>  -->
                            <NuxtLink :to="`/blogs/view/${post.blogId}`" class="text-blue-600 hover:underline">More</NuxtLink> 
                            <NuxtLink :to="`/blogs/delete/${post.blogId}`" class="text-red-600 hover:underline">Delete</NuxtLink> 
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    data() {
        return{
            blogs: []
        }
    },
    mounted(){
        this.getBlogs()
    },
    methods: {
        async getBlogs(){
            try {
                const response = await axios.get("https://localhost:7179/api/Blog/get-blog-posts")
                this.blogs = response.data
            } catch (error) {
                console.log("Error getting blogs post: ", error.message)
            }
        }
    }
}
</script>