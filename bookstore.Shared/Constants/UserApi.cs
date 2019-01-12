namespace bookstore.Shared.Constants
{
    public static class UserApi
    {
        private const string BaseUri = "api/user";

        public static string Get = $"{BaseUri}/{{0}}";

        public static string GetAll = BaseUri;

        public static string Create = BaseUri;

        public static string Update = BaseUri;

        public static string Delete = $"{BaseUri}/{{0}}";
    }
}
