using GraphQL.SocialNetwork.Data;
using GraphQL.SocialNetwork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.SocialNetwork.Services
{
    public class BlogService
    {
        private readonly AppGraphQLDbContext _ctx;

        public BlogService(AppGraphQLDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Author> GetAllAuthors()
        {
            return this._ctx.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return this._ctx.Authors
                .Include("SocialsNet").Where(x => x.SocialsNet.Any())
                .Where(author => author.Id == id)
                .FirstOrDefault<Author>();
        }

        public List<Author> GetAuthorByIds(int[] ids)
        {
            return this._ctx.Authors
                .Include("SocialsNet").Where(x => x.SocialsNet.Any())
                .Where(author => ids.Contains(author.Id))
                .ToList<Author>();
        }

        public List<Post> GetPostsByAuthor(int id)
        {
            return this._ctx.Posts
                .Include("Categories").Where(x => x.Categories.Any())
                .Include("Comments").Where(x => x.Categories.Any())
                .Include("Rating")
                .Include("Author")
                .Where(post => post.Author.Id == id)
                .ToList<Post>();
        }
    }
}
