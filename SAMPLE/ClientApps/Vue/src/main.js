import Vue from "vue";
import App from "./App.vue";
import Axios from "axios";
import VueAxios from "vue-axios";
import { store } from "./store/store";
import { router } from "./router";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import { Actions } from "./constraints/Constraints";
import BaseActions from "./store/BaseActions";
import { ControllerRoutes, SettingsRoutes } from "./constraints/Routes";

import JsonExcel from 'vue-json-excel'

Vue.component('downloadExcel', JsonExcel)
Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(Axios, VueAxios);

router.beforeEach((to, from, next) => {
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if (!store.dispatch(Actions.IS_AUTHENTICATED)) {
      next({
        path: "account/login",
        query: { redirect: to.fullPath },
      });
    } else {
      next();
    }
  } else {
    next();
  }
});
router.beforeResolve((to, from, next) => {
  next(); // DO IT!
});

new BaseActions(ControllerRoutes.Settings)
  .request("GET", SettingsRoutes.Get())
  .then((settings) => {
    document.getElementsByTagName("title")[0].innerHTML = settings.title;
  });

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
