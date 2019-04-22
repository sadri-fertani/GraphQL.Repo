using GraphQL.SocialNetwork.Models;
using GraphQL.Types;

namespace GraphQL.SocialNetwork.Query.Types
{
    public class RatingType : ObjectGraphType<Rating>
    {
        public RatingType()
        {
            Field(x => x.Count);
            Field(x => x.Percent);
        }
    }
}
