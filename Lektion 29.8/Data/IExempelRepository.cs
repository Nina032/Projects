using ExempelProject.Data.Entities;

namespace ExempelProject.Data
{
    public interface IExempelRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SavaAll();
    }
}