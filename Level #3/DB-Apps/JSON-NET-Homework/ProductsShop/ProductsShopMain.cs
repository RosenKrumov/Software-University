using System.Linq;

namespace ProductsShop
{
    public class ProductsShopMain
    {
        static void Main()
        {
            var context = new ProductsShopEntities();
            var count = context.Users.Count();
        }
    }
}
