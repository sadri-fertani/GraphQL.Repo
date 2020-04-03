namespace GraphQL.SocialNetwork.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
    }
}
