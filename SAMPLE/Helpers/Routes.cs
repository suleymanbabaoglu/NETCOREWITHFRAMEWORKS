namespace SAMPLE.Helpers
{
    public static class Routes
    {
        public static class ControllerRoutes
        {
            public const string AccountController = "Account";
            public const string AuthenticationController = "Authentication";
            public const string CustomerController = "Customer";
            public const string MainController = "Main";
            public const string ProductController = "Product";
            public const string UserController = "User";
            public const string SettingsController = "Settings";
        }
        public static class GeneralRoutes
        {
            public const string GetAll = "getAll";
            public const string GetById = "get/{id:int}";
            public const string Create = "create";
            public const string Update = "update";
            public const string Delete = "delete/{id:int}";
            public const string Count = "count";
        }

        public static class AccountRoutes
        {
            public const string Register = "register";
            public const string PasswordReset = "passwordReset";
            public const string GetLoggedInUser = "getLoggedInUser";
        }
        public static class AuthRoutes
        {
            public const string Login = "login";
            public const string LoginByRefreshToken = "loginByRefreshToken";
            public const string Logout = "logout";
        }
        public static class CustomerRoutes
        {
            public const string GetProducts = "{customerId:int}/products";
            public const string AddProduct = "{customerId:int}/add-product/{productId:int}";
            public const string RemoveProduct = "{customerId:int}/remove-product/{productId:int}";
        }
        public static class SettingsRoutes
        {
            public const string Get = "get";
        }

    }
}
