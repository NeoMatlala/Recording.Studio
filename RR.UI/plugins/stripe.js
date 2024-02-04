import { createApp } from "vue";
import { loadStripe } from "@stripe/stripe-js";

const stripePromise = loadStripe('pk_test_51Oevw8Akocj1NhM2cNSKeekY40NGbu72Xhya9vpOutg6257GxdwzshLB0Yi4j7lkLXcgjfgpTTFc9aZ4jZuWuFdV00lpoGm4V1')

// export default defineNuxtPlugin({app}) {
//     app.use(stripePromise)
// }

export default defineNuxtPlugin(() => {
    return {
        provide: {
            stripePromise: stripePromise
        }
    }
})