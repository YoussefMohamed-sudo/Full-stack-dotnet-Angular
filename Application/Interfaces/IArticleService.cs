using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IArticleService 
    {
       Task<ArticleDto> GetByIdAsync(int id);
       Task<IEnumerable<ArticleDto>> GetAllAsync();
        Task<ArticleDto> CreateAsync(CreateArticleDto createArticleDto);
        Task<ArticleDto> UpdateAsync(int id, UpdateArticleDto updateArticleDto);
        Task<bool> DeleteAsync(int id);
    }
}