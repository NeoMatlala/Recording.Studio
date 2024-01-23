export default defineNuxtRouteMiddleware((to) => {
    if(process.client) {
        const storedToken = localStorage.getItem('token')

        if(to.path === '/dashboard' && !storedToken) {
            localStorage.setItem('redirectedFromAuthMiddleware', 'true')
            return navigateTo('/')
        }

        if(to.path.startsWith('/bookings') && !storedToken) {
            localStorage.setItem('redirectedFromAuthMiddleware', 'true')
            return navigateTo('/')
        }

        if(to.path.startsWith('/slots') && !storedToken) {
            localStorage.setItem('redirectedFromAuthMiddleware', 'true')
            return navigateTo('/')
        }
    }
})