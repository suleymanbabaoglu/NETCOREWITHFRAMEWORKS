/* eslint-disable */
import BaseActions from "./BaseActions";
import {AccountRoutes, AuthRoutes} from "../constraints/Routes";
import router from "../router";


export const login = async ({state}, payload) => {
    let response = await new BaseActions("").request(
        "POST",
        AuthRoutes.Login(),
        payload
    );
    if (response.token !== null) {
        setLocalStorage(
            response.token,
            response.refreshToken,
            response.tokenExpire
        );
        router.push("/");
    }
};

export const loginByRefreshToken = async ({state}) => {
    let response = await new BaseActions("").request(
        "POST",
        AuthRoutes.LoginByRefreshToken(),
        JSON.stringify(getLocalStorage().refreshToken)
    );
    if (response.token !== null) {
        state.isAuthenticated = true;
        setLocalStorage(response.token, "", response.tokenExpire);
        router.push("/");
    } else {
        removeLocalStorage();
        router.push("/account/login");
    }
};

export const logout = async ({state}) => {
    await new BaseActions("").request("GET", AuthRoutes.Logout());
    removeLocalStorage();

    router.push("/account/login");
};

export const register = async ({state}, payload) => {
    await new BaseActions("").request("POST", AccountRoutes.Register(), payload);
    router.push("/account/login");
};

export const passwordReset = async ({state}, payload) => {
    await new BaseActions("").request(
        "POST",
        AccountRoutes.PasswordReset(),
        payload
    );
};

export const isAuthenticated = () => {
    let token = getLocalStorage().token;
    let refreshToken = getLocalStorage().refreshToken;
    let tokenExpire = getLocalStorage().expire;
    return (
        token !== undefined &&
        token?.length > 50 &&
        refreshToken !== undefined &&
        tokenExpire !== undefined
    );
};

function getLocalStorage() {
    return {
        token: localStorage.getItem("token"),
        refreshToken: localStorage.getItem("refreshToken"),
        expire: localStorage.getItem("tokenExpire"),
    };
}

function setLocalStorage(
    token,
    refreshToken = localStorage.getItem("refreshToken"),
    tokenExpire
) {
    localStorage.setItem("token", token);
    localStorage.setItem("tokenExpire", tokenExpire);
    localStorage.setItem("refreshToken", refreshToken);
}

function removeLocalStorage() {
    localStorage.removeItem("token");
    localStorage.removeItem("tokenExpire");
    localStorage.removeItem("refreshToken");
}

export const toExcel = (header, list) => {

}
