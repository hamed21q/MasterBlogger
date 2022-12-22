using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategory
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public RedirectToPageResult OnPost(CreateArticleCategoryCommand command)
        {
            articleCategoryApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}
