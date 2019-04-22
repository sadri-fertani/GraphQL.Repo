﻿using GraphQL.SocialNetwork.Models;
using GraphQL.Types;

namespace GraphQL.SocialNetwork.Query.Types
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Field(x => x.Count);
            Field(x => x.Description);
            Field(x => x.Url);
        }
    }
}
