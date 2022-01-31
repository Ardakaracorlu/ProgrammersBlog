using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int articleId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.success, new ArticleDto { 
                Article = article,
                ResultStatus = ResultStatus.success  
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);
         }
        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı.", null);
        }

        public  async Task<IDataResult<ArticleListDto>> GetAllByCategory(int CategoryId)
        {
            var Result = await _unitOfWork.Categories.AnyAsync(c => c.Id == CategoryId);
            if (Result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == CategoryId && !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı.", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir Kategori bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive,a=>a.User,a=>a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı.", null);
        }

        public Task<IResult> HardDelete(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
