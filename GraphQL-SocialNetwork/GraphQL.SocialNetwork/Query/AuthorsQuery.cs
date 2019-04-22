using GraphQL.SocialNetwork.Query.Types;
using GraphQL.SocialNetwork.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.SocialNetwork.Query
{
    public class AuthorsQuery : ObjectGraphType
    {
        public AuthorsQuery(BlogService blogService)
        {
            Field<ListGraphType<AuthorType>>(
                name: "author",
                arguments: new QueryArguments(new QueryArgument<ListGraphType<IntGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var ids = context.GetArgument<int[]>("id");
                    return blogService.GetAuthorByIds(ids);
                }
            );
        }
    }
}
