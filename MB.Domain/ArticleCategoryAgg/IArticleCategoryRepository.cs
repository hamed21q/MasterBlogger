namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        void Create(ArticleCategory articleCategory);
        ArticleCategory GetBy(long id);
        void Save();
        bool Exist(string title);

    }
}
