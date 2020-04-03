using GraphQL.SocialNetwork.Models;
using GraphQL.Types;

namespace GraphQL.SocialNetwork.Query.Types
{
    public class CategorieType : ObjectGraphType<Categorie>
    {
        public CategorieType()
        {
            Field(x => x.Id).Description("Id of a categorie");
            Field(x => x.Name).Description("Name of a categorie");
        }
    }
}
