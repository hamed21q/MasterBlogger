using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System.Globalization;
using System.Xml.Linq;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository repository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryValidatorService = articleCategoryValidatorService;
            _repository = repository;
        }
        public void Create(CreateArticleCategoryCommand command)
        {
            var articleCategory = new ArticleCategory(command.title, _articleCategoryValidatorService);
            _repository.Create(articleCategory);
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
            var ArticleCategories = _repository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var category in ArticleCategories)
            {
                result.Add(
                    new ArticleCategoryViewModel(
                        category.Id,
                        category.Title,
                        category.IsDeleted,
                        category.CreationDate.ToString(CultureInfo.InvariantCulture)
                        ));
            }
            return result;
        }

        public RenameArticleCategoryCommand Get(long id)
        {
            var articleCategory = _repository.GetBy(id);
            var command = new RenameArticleCategoryCommand();
            command.title = articleCategory.Title;
            command.id = articleCategory.Id;
            return command;
        }

        public void Rename(RenameArticleCategoryCommand command)
        {
            var articleCategory = _repository.GetBy(command.id);
            articleCategory.Rename(command.title);
            _repository.Save();
        }

        public void Remove(long id)
        {
            var articleCategory = _repository.GetBy(id);
            articleCategory.Remove();
            _repository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _repository.GetBy(id);
            articleCategory.Activate();
            _repository.Save();
        }
    }
}
