namespace api.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }

        public Note() { }

        public Note(int id, string title, string description, string creatorId) 
        {
            Id = id;
            Title = title;
            Description = description;
            CreatorId = creatorId;
        }
    }
}
