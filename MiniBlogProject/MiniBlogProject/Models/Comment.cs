namespace MiniBlogProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; }

        //Foreign Keys
        public int UserId {  get; set; }
        public int PostId {  get; set; }

        //Navigation
        public User? User { get; set; }

        public Post? Post { get; set; }
    }
}
