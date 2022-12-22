using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.ArticleCategory
{
    public  class RenameArticleCategoryCommand
    {
        public long id { get; set; }
        public string title { get; set; }  
    }
}
