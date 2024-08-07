﻿using BloggieWebProject.Data;
using Microsoft.EntityFrameworkCore;
using WebSocialUdla.Models.Dominio;

namespace WebSocialUdla.Repositorio
{
	public class BlogPostCommentRepositorio : IBlogPostCommentRepositorio
	{
		private readonly BlogDbContext blogDbContext;

		public BlogPostCommentRepositorio(BlogDbContext blogDbContext)
        {
			this.blogDbContext = blogDbContext;
		}
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
		{
			await blogDbContext.BlogPostComment.AddAsync(blogPostComment);
			await blogDbContext.SaveChangesAsync();
			return blogPostComment;
		}

		public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
		{
			return await blogDbContext.BlogPostComment.Where(x =>x.BlogPostId == blogPostId)
				.ToListAsync();
		}
	}
}
