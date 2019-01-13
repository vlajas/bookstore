namespace bookstore.Shared.Api
{
    public static class PublicApi
    {
        public static string Authorize = "api/account/authorize";

        public static string AddToCart = "api/shoppingcart/addtocart";

        public static string DeleteSci = "api/shoppingcart/{{0}}";
    }
}
