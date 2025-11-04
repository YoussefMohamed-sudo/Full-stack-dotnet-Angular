using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetAll()
        {
            var articles = await _articleService.GetAllAsync();
            return Ok(new Response<IEnumerable<ArticleDto>>(articles, "Articles retrieved successfully", true));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetById(int id)
        {
            var article = await _articleService.GetByIdAsync(id);
            if (article == null)
                return NotFound();

            return Ok(new Response<ArticleDto>(article, "Article retrieved successfully", true));
        }

        [HttpPost]
        public async Task<ActionResult<Response<ArticleDto>>> Create(CreateArticleDto createArticleDto)
        {
            var article = await _articleService.CreateAsync(createArticleDto);

            var response = new Response<ArticleDto>(
                article,
                "Article created successfully",
                true
            );

            return CreatedAtAction(nameof(GetById), new { id = article.Id }, response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ArticleDto>> Update(int id, UpdateArticleDto updateArticleDto)
        {
            var article = await _articleService.UpdateAsync(id, updateArticleDto);
            if (article == null)
                return NotFound();
            return Ok(new Response<ArticleDto>(article, "Article updated successfully", true));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _articleService.DeleteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}