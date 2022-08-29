using ExempelProject.Data.Entities;

namespace ExempelProject.Data
{
    public class ExempelRepository : IExempelRepository
    {
        private readonly ExempelProjectContext ctx;
        private readonly ILogger<ExempelRepository> logger;

        public ExempelRepository(ExempelProjectContext ctx, ILogger<ExempelRepository> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                logger.LogInformation("GetAllProducts was called...");
                return ctx.Products
                    .OrderBy(p => p.Artist)
                    .ToList();

            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }
        public bool SavaAll()
        {
            return ctx.SaveChanges() > 0;
        }
    }
}
