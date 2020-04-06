using GraphQL.SocialNetwork.Query;
using GraphQL.SocialNetwork.Services;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GraphQL.SocialNetwork.Controllers
{
    [Route(Startup.GRAPH_QL_ROUTE)]
    public class GraphQlController : Controller
    {
        readonly BlogService blogService;

        public GraphQlController(BlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            IObjectGraphType currentObjectGraphType = null;

            switch (query.OperationName)
            {
                case "GetBlogData":
                    currentObjectGraphType = new BlogQuery(blogService);
                    break;
                case "GetAuthors":
                    currentObjectGraphType = new AuthorsQuery(blogService);
                    break;
                default:
                    currentObjectGraphType = new BlogQuery(blogService);
                    break;
            }

            var schema = new Schema { Query = currentObjectGraphType };

            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.Inputs = query.Variables;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}