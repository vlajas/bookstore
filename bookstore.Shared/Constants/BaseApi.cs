namespace bookstore.Shared.Constants
{
    public abstract class BaseApi
    {
        protected BaseApi(string baseUri)
        {
            Get = $"{baseUri}/{{0}}";

            GetAll = baseUri;

            Create = baseUri;

            Update = baseUri;

            Delete = $"{baseUri}/{{0}}";
        }

        public string Get { get; }

        public string GetAll { get; }

        public string Create { get; }

        public string Update { get; }

        public string Delete { get; }
    }
}
