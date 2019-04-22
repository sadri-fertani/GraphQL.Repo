# GraphQL.Repo
POC of graphql using.

Look [here](https://www.red-gate.com/simple-talk/dotnet/net-development/getting-started-with-graphql-in-asp-net/
) for the original tuto.

Big thanks for [Julio Sampaio](https://www.red-gate.com/simple-talk/author/iamjuliosampaiogmail-com/).

## Request 1
### Template
````
query GetBlogData($id: Int) {
  author(id: $id) {
    id
    name
  }
  posts(id: $id) {
    author {
      bio
    }
    categories
    comments {
      description
      count
      url
    }
  }
  socials(id: $id) {
    nickName
    type
  }
}
````
### Variables
````
{
    "id":  1
}
````
## Request 2
### Template
````
query GetBlogData($id: [Int]) {
  author(id: $id) {
    id
    name
  }
}
````
### Variables
````
{
    "id":  [1, 2]
}
````

#### Liste as Variable
````
Field<ListGraphType<AuthorType>>(
    // ...
    arguments: new QueryArguments(new QueryArgument<ListGraphType<IntGraphType>> { Name = "id" }),
    // ...
    var ids = context.GetArgument<int[]>("id");
    
    return blogService.GetAuthorByIds(ids);
);
````