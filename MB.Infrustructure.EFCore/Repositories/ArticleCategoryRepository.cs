using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrustructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBlogerContext _context;
        public ArticleCategoryRepository(MasterBlogerContext context)
        {
            _context = context;
        }
        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.ToList();
        }
        public void Create(ArticleCategory category) 
        {
            _context.ArticleCategories.Add(category);
            Save();
        }
        public ArticleCategory GetBy(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(category => category.Id == id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exist(string title)
        {
            return _context.ArticleCategories.Any(category => category.Title == title); 
        }
    }
}