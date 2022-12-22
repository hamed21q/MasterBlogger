using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _repository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            this._repository = articleRepository;
        }

        public void Activate(long id)
        {
            var article = _repository.GetBy(id);
            article.Activate();
            _repository.Save();
        }

        public void Add(CreateArticleCommand command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
            _repository.Add(article);
        }

        public void Edit(EditArticleCommand command)
        {
            var article = _repository.GetBy(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
            _repository.Save();
        }

        public List<ArticleViewModel> GetAll()
        {
            return _repository.GetAll();
        }

        public EditArticleCommand GetBy(long id)
        {
            var article = _repository.GetBy(id);
            return new EditArticleCommand{
                Id = article.Id,
                Title = article.Title,  
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public void Remove(long id)
        {
            var article = _repository.GetBy(id);
            article.Remove();
            _repository.Save();
        }
    }
}
