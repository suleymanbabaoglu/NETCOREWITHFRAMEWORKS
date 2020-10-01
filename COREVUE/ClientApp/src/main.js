import Vue from "vue";
import App from "./App.vue";
import Axios from "axios";
import VueAxios from "vue-axios";
import { store } from "./store/store";
import { router } from "./router";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(Axios, VueAxios);

router.beforeEach((to, from, next) => {
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if (!store.getters["getAuth"]) {
      next({
        path: "account/login",
        query: { redirect: to.fullPath },
      });
    } else {
      next();
    }
  }  else {
    next();
  }
});
router.beforeResolve((to, from, next)=> {
  next() // DO IT!
});
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
