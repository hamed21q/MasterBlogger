using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.Article
{
    public class ListModel : PageModel
    {
        private readonly IArticleApplication articleApplication;
        public IEnumerable<ArticleViewModel> articles { get; set; }

        public ListModel(IArticleApplication articleApplication)
        {
            this.articleApplication = articleApplication;
        }

        public void OnGet()
        {
            articles = articleApplication.GetAll();
        }
        public RedirectToPageResult OnPostRemove(long id)
        {
            articleApplication.Remove(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostActivate(long id)
        {
            articleApplication.Activate(id);
            return RedirectToPage("./List");
        }
    }
}
