using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategory
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        [BindProperty]
        public RenameArticleCategoryCommand command { get; set; }
        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            command = _articleCategoryApplication.Get(id);
        }
        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Rename(command);
            return RedirectToPage("./List");
        }

    }
}
