export const Base = "http://localhost:5000/";
const Authentication = Base + "authentication/";
const Account = Base + "account/";
const Customer = Base + "customer/";
const Product = Base + "product/";
const User = Base + "user/";
const Settings = Base + "settings/";

export const ControllerRoutes = {
  Account: Account,
  Authentication: Authentication,
  Customer: Customer,
  Product: Product,
  User: User,
  Settings: Settings,
};

export const GeneralRoutes = {
  GetAll(controller) {
    return controller + "getAll";
  },
  Create(controller) {
    return controller + "create";
  },
  Update(controller) {
    return controller + "update";
  },
  Delete(controller, objectId) {
    return controller + `delete/${objectId}`;
  },
  GetById(controller, objectId) {
    return controller + `get/${objectId}`;
  },
  Count(controller) {
    return controller + "count";
  },
};

export const AccountRoutes = {
  Register() {
    return Account + "register";
  },
  PasswordReset() {
    return Account + "passwordReset";
  },
  GetLoggedInUser() {
    return Account + "getLoggedInUser";
  },
};

export const AuthRoutes = {
  Login() {
    return Authentication + "login";
  },
  LoginByRefreshToken() {
    return Authentication + "loginByRefreshToken";
  },
  Logout() {
    return Authentication + "logout";
  },
};

export const CustomerRoutes = {
  GetProducts(customerId) {
    return Customer + `${customerId}/products`;
  },
  AddProduct(customerId, productId) {
    return Customer + `${customerId}/add-product/${productId}`;
  },
  RemoveProduct(customerId, productId) {
    return Customer + `${customerId}/remove-product/${productId}`;
  },
};

export const SettingsRoutes = {
  Get() {
    return Settings + "get";
  },
};
