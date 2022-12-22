using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.Article
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication articleApplication;
        private readonly IArticleCategoryApplication categoryApplication;
        [BindProperty] public EditArticleCommand editCommand { get; set; }
        public List<SelectListItem> articleCategories { get; set; }
        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication categoryApplication)
        {
            this.categoryApplication = categoryApplication;
            this.articleApplication = articleApplication;
        }

        public void OnGet(long id)
        {
            editCommand = articleApplication.GetBy(id);
            articleCategories = categoryApplication.GetAll().Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }
        public RedirectToPageResult OnPost()
        {
            articleApplication.Edit(editCommand);
            return RedirectToPage("./List");
        }
    }
}
