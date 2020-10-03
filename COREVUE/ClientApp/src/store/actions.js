/* eslint-disable */
import BaseActions from "./BaseActions";
import { AccountRoutes, AuthRoutes } from "../constraints/Routes";
import { router } from "../router";

export const login = async (state, payload) => {
  let response = await new BaseActions("").request(
    "POST",
    AuthRoutes.Login(),
    payload
  );
  if (response.token !== null) {
    state.isAuthenticated = true;
    localStorage.setItem("token", response.token);
    localStorage.setItem("tokenExpire", response.tokenExpire);
    localStorage.setItem("refreshToken", response.refreshToken);
    router.push("/");
  }
};

export const loginByRefreshToken = async (state, payload) => {
  let response = await new BaseActions("").request(
    "POST",
    AuthRoutes.LoginByRefreshToken(),
    payload
  );
  if (response.token !== null) {
    state.isAuthenticated = true;

    localStorage.setItem("token", response.token);
    localStorage.setItem("tokenExpire", response.tokenExpire);
    router.push("/");
  }
};

export const logout = async (state) => {
  await new BaseActions("").request("GET", AuthRoutes.Logout());
  localStorage.removeItem("token");
  localStorage.removeItem("refreshToken");
  localStorage.removeItem("tokenExpire");
  localStorage.removeItem("vuex");
  state.isAuthenticated = false;
  router.push("account/login");
};

export const register = async (state, payload) => {
  await new BaseActions("").request("POST", AccountRoutes.Register(), payload);
};

export const passwordReset = async (state, payload) => {
  await new BaseActions("").request(
    "POST",
    AccountRoutes.PasswordReset(),
    payload
  );
};
