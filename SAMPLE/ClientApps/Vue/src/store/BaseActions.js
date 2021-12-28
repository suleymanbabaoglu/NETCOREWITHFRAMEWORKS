import axios from "axios";
import { Base, GeneralRoutes } from "../constraints/Routes";
import {Actions, ErrorConstraints, ReturnConstraints} from "../constraints/Constraints";
import store from "./store";

export default class BaseActions {
  constructor(controllerRoute) {
    this.controllerRoute = controllerRoute;
    this.refreshToken = localStorage.getItem("refreshToken");
  }

  getRequestHeader() {
    return {
      "Content-Type": "application/json",
      Authorization: "Bearer " + localStorage.getItem("token")
    };
  }

  async request(method, url, data = {}) {
    const client = axios.create({
      baseURL: Base,
      json: true
    });
    try {
      let result = await client({
        method: method,
        url: url,
        headers: this.getRequestHeader(),
        data: data
      });
      return result.data;
    } catch (e) {
      if (e.response !== undefined && e.response.status === 401) {
        return (await store.dispatch(Actions.LOGIN_BY_REFRESH_TOKEN))
          ? ReturnConstraints.REFRESH
          : null;
      } else throw ErrorConstraints.NETWORK_ERROR;
    }
  }

  async getById(objectId) {
    return await this.request(
      "GET",
      GeneralRoutes.GetById(this.controllerRoute, objectId)
    );
  }

  async getAll() {
    return await this.request("GET", GeneralRoutes.GetAll(this.controllerRoute));
  }

  async create(model) {
    return await this.request(
      "POST",
      GeneralRoutes.Create(this.controllerRoute),
      model
    );
  }

  async update(model) {
    return await this.request(
      "PUT",
      GeneralRoutes.Update(this.controllerRoute),
      model
    );
  }

  async delete(objectId) {
    return await this.request(
      "DELETE",
      GeneralRoutes.Delete(this.controllerRoute, objectId)
    );
  }

  async count() {
    return await this.request(
        "GET",
        GeneralRoutes.Count(this.controllerRoute)
    );
  }
}
