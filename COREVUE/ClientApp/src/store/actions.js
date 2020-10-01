/* eslint-disable */
import BaseActions from "./BaseActions";
import { AccountRoutes, AuthRoutes } from "../constraints/Routes";

export const login = async (state, payload) => {
  await new BaseActions("").request("POST", AuthRoutes.Login(), payload);
};

export const loginByRefreshToken = async (state, payload) => {
  await new BaseActions("").request(
    "POST",
    AuthRoutes.LoginByRefreshToken(),
    payload
  );
};

export const logout = async (state, payload) => {
  await new BaseActions("").request("GET", AuthRoutes.Logout());
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
