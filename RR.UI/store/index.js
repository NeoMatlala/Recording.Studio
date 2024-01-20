// import { createStore } from "vuex/types/index";
import { createStore } from "vuex";

export const store = createStore({
    state: {
        userId: null
    },
    mutations: {
        setUserId(state, userId) {
            state.userId = userId
        }
    }
})