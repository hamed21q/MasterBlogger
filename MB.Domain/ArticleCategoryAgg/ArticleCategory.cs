using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public Boolean IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ICollection<Article> Articles { get; private set; }
        public ArticleCategory(string title, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            articleCategoryValidatorService.NullCheck(title);
            articleCategoryValidatorService.ExistanceCheck(title);
            CreationDate= DateTime.Now;
            Title = title;
            IsDeleted = false;
            Articles = new List<Article>();
        }
        protected ArticleCategory()
        {

        }
        public void Rename(string title)
        {
            this.Title= title;
        }
        public void Remove()
        {
            this.IsDeleted = true;
        }
        public void Activate()
        {
            this.IsDeleted= false;
        }
    }
}
