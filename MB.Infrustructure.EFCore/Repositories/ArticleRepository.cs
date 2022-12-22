using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Globalization;

namespace MB.Infrustructure.EFCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBlogerContext _context;
        public ArticleRepository(MasterBlogerContext context)
        {
            _context = context;
        }

        public void Add(Article article)
        {
            _context.Articles.Add(article);
            Save();
        }

        public List<ArticleViewModel> GetAll()
        {
            return _context.Articles.Include(x => x.ArticleCategroy).Select(x => new ArticleViewModel 
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted= x.IsDeleted,
                ArticleCategroy = x.ArticleCategroy.Title
            }).ToList();
        }
        public Article GetBy(long id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
