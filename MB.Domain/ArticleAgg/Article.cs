using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategroy { get; private set; }

        public Article()
        {

        }
        public Article(string title, string shortDecription, string image, string content, long articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDecription;
            Image = image;
            Content = content;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            ArticleCategoryId = articleCategoryId;
        }
        public void Edit(string title, string shortDecription, string image, string content, long articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDecription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }

        public void Remove()
        {
            this.IsDeleted = true;
        }
        public void Activate()
        {
            this.IsDeleted = false;
        }
    }
}
