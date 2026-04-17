namespace MiniBlogProject.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; }


        //Foreign Keys
        public int UserId {  get; set; }


        //Navigation
        public User? User { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
