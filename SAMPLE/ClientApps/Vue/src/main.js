import { createApp } from "vue";
import App from "./App.vue";
import store from "./store/store";
import router from "./router";

import { Actions } from "./constraints/Constraints";
import BaseActions from "./store/BaseActions";
import { ControllerRoutes, SettingsRoutes } from "./constraints/Routes";

import JsonExcel from "vue-json-excel";
import axios from "axios";

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

const app = createApp(App);
app.config.globalProperties.$axios = axios;
app.component("downloadExcel", JsonExcel);

app.use(store);
app.use(router);
app.mount("#app");
