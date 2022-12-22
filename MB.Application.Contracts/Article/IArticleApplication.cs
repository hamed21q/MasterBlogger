

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAll();
        void Add(CreateArticleCommand command);
        void Edit(EditArticleCommand command);
        EditArticleCommand GetBy(long id);
        void Remove(long id);
        void Activate(long id);
    }
}
