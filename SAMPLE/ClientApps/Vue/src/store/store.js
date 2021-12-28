import { createStore } from "vuex";

import * as getters from "./getters";
import * as mutations from "./mutations";
import * as actions from "./actions";

const store = createStore({
    state: {
        isAuthenticated: false
    },
    getters,
    mutations,
    actions
});
export default store;