import axios from "axios";
import { Base, CRUDRoutes } from "../constraints/Routes";
/*import { ErrorConstraints, ReturnConstraints } from "../helpers/Constraints";*/

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
      /* if (e.response !== undefined && e.response.status === 401) {
                return (await new AccountService().loginByRefreshToken()) ? ReturnConstraints.REFRESH : null;
            } else throw ErrorConstraints.NETWORK_ERROR;*/
    }
  }

  async getById(objectId) {
    return await this.request(
      "GET",
      CRUDRoutes.GetById(this.controllerRoute, objectId)
    );
  }

  async getAll() {
    return await this.request("GET", CRUDRoutes.GetAll(this.controllerRoute));
  }

  async create(model) {
    return await this.request(
      "POST",
      CRUDRoutes.Create(this.controllerRoute),
      model
    );
  }

  async update(model, objectId) {
    return await this.request(
      "PUT",
      CRUDRoutes.Update(this.controllerRoute, objectId),
      model
    );
  }

  async delete(objectId) {
    return await this.request(
      "DELETE",
      CRUDRoutes.Delete(this.controllerRoute, objectId)
    );
  }
}
