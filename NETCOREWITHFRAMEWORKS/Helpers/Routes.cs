namespace NETCOREWITHFRAMEWORKS.Helpers
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
        }
        public static class CRUDRoutes
        {
            public const string GetAll = "getAll";
            public const string GetById = "get/{id:int}";
            public const string Create = "create";
            public const string Update = "update";
            public const string Delete = "delete/{id:int}";
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
    }
}
