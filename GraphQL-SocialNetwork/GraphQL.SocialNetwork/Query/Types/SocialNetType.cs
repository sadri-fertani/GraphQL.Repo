using GraphQL.SocialNetwork.Models;
using GraphQL.Types;

namespace GraphQL.SocialNetwork.Query.Types
{
    public class SocialNetworkType : ObjectGraphType<SocialNet>
    {
        public SocialNetworkType()
        {
            Field(x => x.Id);
            Field(x => x.NickName);
            Field<EnumerationGraphType<SNType>>("type");
            Field(x => x.Url);
        }
    }
}
