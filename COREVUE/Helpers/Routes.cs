using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREVUE.Helpers
{
    public static class Routes
    {
        public static class ControllerRoutes
        {
            public const string MainController ="Main";
            public const string UserController ="User";
            public const string CustomerController ="Customer";
            public const string ProductController ="Product";
        }
        public static class CRUDRoutes
        {
            public const string GetAll = "getAll";
            public const string GetById = "get/{id:int}";
            public const string Create = "create";
            public const string Update = "update";
            public const string Delete = "delete/{id:int}";
        }
    }
}
