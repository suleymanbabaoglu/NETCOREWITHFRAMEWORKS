import { createRouter, createWebHashHistory } from "vue-router";

import EmptyLayout from "./layouts/EmptyLayout";
import LoginPage from "./pages/Account/LoginPage";
import RegisterPage from "./pages/Account/RegisterPage";
import NotFound from "./pages/NotFound";
import MainLayout from "./layouts/MainLayout";
import DashboardPage from "./pages/Main/DashboardPage";
import CustomerPage from "./pages/Main/CustomerPage";
import UserPage from "./pages/Main/UserPage";
import ProductPage from "./pages/Main/ProductPage";
import SettingsPage from "./pages/Main/SettingsPage";

const routes = [
    {
        path: "/account",
        redirect: "login",
        component: EmptyLayout,
        children: [
            { path: "login", component: LoginPage, name: "login" },
            { path: "register", component: RegisterPage, name: "register" }
        ],
        meta: { requiresAuth: false }
    },
    {
        path: "/",
        component: MainLayout,
        children: [
            { path: "/", component: DashboardPage, name: "dashboard" },
            { path: "customer", component: CustomerPage, name: "customer" },
            { path: "user", component: UserPage, name: "user" },
            { path: "product", component: ProductPage, name: "product" },
            { path: "settings", component: SettingsPage, name: "settings" }
        ],
        meta: { requiresAuth: true }
    },
    { path: "/notfound", component: NotFound, name: "notfound" },
    { path: "/:pathMatch(.*)*", redirect: "/notfound" }
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;