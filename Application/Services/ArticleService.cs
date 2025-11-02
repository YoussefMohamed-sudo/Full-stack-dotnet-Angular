using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;

namespace Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ArticleDto> GetByIdAsync(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            return MapToDto(article);
        }

        public async Task<IEnumerable<ArticleDto>> GetAllAsync()
        {
            var articles = await _articleRepository.GetAllAsync();
            var articleDtos = new List<ArticleDto>();
            foreach (var article in articles)
            {
                articleDtos.Add(MapToDto(article));
            }
            return articleDtos;
        }

        public async Task<ArticleDto> CreateAsync(CreateArticleDto createArticleDto)
        {
            var article = new Article
            {
                Title = createArticleDto.Title,
                Content = createArticleDto.Content,
                Author = createArticleDto.Author,
                PublishedDate = DateTime.UtcNow
            };

            var createdArticle = await _articleRepository.AddAsync(article);
            return MapToDto(createdArticle);
        }

        public async Task<ArticleDto> UpdateAsync(int id, UpdateArticleDto updateArticleDto)
        {
            var existingArticle = await _articleRepository.GetByIdAsync(id);
            if (existingArticle == null)
                return null;

            existingArticle.Title = updateArticleDto.Title;
            existingArticle.Content = updateArticleDto.Content;
            existingArticle.Author = updateArticleDto.Author;
            existingArticle.LastModifiedDate = DateTime.UtcNow;

            var updatedArticle = await _articleRepository.UpdateAsync(existingArticle);
            return MapToDto(updatedArticle);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _articleRepository.DeleteAsync(id);
        }

        private ArticleDto MapToDto(Article article)
        {
            if (article == null)
                return null;
            return new ArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                PublishedDate = article.PublishedDate,
                Author = article.Author,
                LastModifiedDate = article.LastModifiedDate
            };
        }
    }
}