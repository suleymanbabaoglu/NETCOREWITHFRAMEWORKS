export const Base = "http://localhost:5000/";
const Authentication = Base + "authentication/";
const Account = Base + "account/";
const Customer = Base + "customer/";
const Product = Base + "product/";
const User = Base + "user/";

export const ControllerRoutes = {
  Account: Account,
  Authentication: Authentication,
  Customer: Customer,
  Product: Product,
  User: User
};

export const CRUDRoutes = {
  GetAll(controller) {
    return controller + "getAll";
  },
  Create(controller) {
    return controller + "create";
  },
  Update(controller, objectId) {
    return controller + `update/${objectId}`;
  },
  Delete(controller, objectId) {
    return controller + `delete/${objectId}`;
  },
  GetById(controller, objectId) {
    return controller + `getById/${objectId}`;
  }
};
