import Vue from "vue";
import VueRouter from "vue-router";
import EmptyLayout from "./layouts/EmptyLayout";
import Login from "./pages/Account/Login";
import Register from "./pages/Account/Register";
import NotFound from "./pages/NotFound";
import MainLayout from "./layouts/MainLayout";
import Dashboard from "./pages/Main/Dashboard";
import Customer from "./pages/Main/Customer";
import User from "./pages/Main/User";
import Product from "./pages/Main/Product";
import Settings from "./pages/Main/Settings";

Vue.use(VueRouter);

export const routes = [
  {
    path: "/account",
    redirect: "login",
    component: EmptyLayout,
    children: [
      { path: "login", component: Login, name: "login" },
      { path: "register", component: Register, name: "register" }
    ],
    meta: { requiresAuth: false }
  },
  {
    path: "/",
    redirect: "/",
    component: MainLayout,
    children: [
      { path: "/", component: Dashboard, name: "dashboard" },
      { path: "customer", component: Customer, name: "customer" },
      { path: "user", component: User, name: "user" },
      { path: "product", component: Product, name: "product" },
      { path: "settings", component: Settings, name: "settings" }
    ],
    meta: { requiresAuth: false }
  },
  { path: "/notfound", component: NotFound, name: "notfound" },
  { path: "*", redirect: "/notfound" }
];

export const router = new VueRouter({
  mode: "history",
  routes
});
