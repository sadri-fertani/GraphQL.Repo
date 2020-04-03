using System.Collections.Generic;

namespace GraphQL.SocialNetwork.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImgUrl { get; set; }
        public string ProfileUrl { get; set; }
        public List<SocialNet> SocialsNet { get; set; }
    }
}
