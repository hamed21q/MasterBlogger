using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategory
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> articleCategories { get; set; }
        public IArticleCategoryApplication _application;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _application = articleCategoryApplication;
        }

        public void OnGet()
        {
            articleCategories = _application.GetAll();
        }
        public RedirectToPageResult OnPostRemove(long id)
        {
            _application.Remove(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostActivate(long id)
        {
            _application.Activate(id);
            return RedirectToPage("./List");
        }
    }
}
