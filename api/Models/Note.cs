namespace api.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Participants { get; set; }

        public Note() { }

        public Note(int id, string title, string description, List<string> participants) 
        {
            Id = id;
            Title = title;
            Description = description;
            Participants = participants;
        }
    }
}
