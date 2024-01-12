export default defineNuxtRouteMiddleware((to,from) => {
    if(process.client) {
        const storedToken = localStorage.getItem('token')

        if (to.path === '/manage-bookings'  && !storedToken) {
            console.log('Token doesn\'t exist');
            return navigateTo("/login");
          }

          if (to.path === '/book-rehearsal'  && !storedToken) {
            console.log('Token doesn\'t exist');
            return navigateTo("/login");
          }

        // if(to.path === '/manage-bookings') {
        //     if(storedToken) {
        //         console.log(storedToken)
        //     } else {
        //         console.log('token doesnt exist')
        //         return navigateTo("/login")
        //     }
        // }
    }
})