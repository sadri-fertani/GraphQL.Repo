using GraphQL.SocialNetwork.Query.Types;
using GraphQL.SocialNetwork.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.SocialNetwork.Query
{
    public class BlogQuery : ObjectGraphType
    {
        public BlogQuery(BlogService blogService)
        {
            Field<AuthorType>(
                name: "author",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return blogService.GetAuthorById(id);
                }
            );

            Field<ListGraphType<PostType>>(
                name: "posts",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return blogService.GetPostsByAuthor(id);
                }
            );

            Field<ListGraphType<SocialNetworkType>>(
                name: "socials",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    
                    var id = context.GetArgument<int>("id");
                    return blogService.GetAuthorById(id).SocialsNet;
                }
            );
        }
    }
}
