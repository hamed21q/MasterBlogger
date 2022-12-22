using MB.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository articleCategoryRepository;
        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            this.articleCategoryRepository = articleCategoryRepository;
        }

        public void ExistanceCheck(string title)
        {
            if (articleCategoryRepository.Exist(title))
            {
                throw new DuplicatedRecordExeption("this record already exist in the database");
            }
        }
        public void NullCheck(String title)
        {
            if(String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("empty record is not allowed");
            }
        }
    }
}
