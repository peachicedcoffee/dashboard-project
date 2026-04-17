namespace MiniBlogProject.Models
{
    public class User
    {

        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        //Navigation
        public List<Post>? Posts { get; set; }

        public List<Comment>? Comments { get; set; }

    }
}
