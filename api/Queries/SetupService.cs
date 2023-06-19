using api.Models;

namespace api.Queries
{
    public static class SetupService
    {
        public static IEnumerable<Note> GetFilledNoteList()
        {
            List<Note> notes = new List<Note>()
            {
                new Note()
                {
                    Id = 1,
                    Title = "Test1",
                    Description = "Description1",
                    Participants = new List<string>() { "Daniil", "Alex" }
                },
                new Note()
                {
                    Id = 2,
                    Title = "Test2",
                    Description = "Description2",
                    Participants = new List<string>() { "Artem", "Alex" }
                },
                new Note()
                {
                    Id = 3,
                    Title = "Test3",
                    Description = "Description3",
                    Participants = new List<string>() { "Daniil", "Max" }
                },
                new Note()
                {
                    Id = 4,
                    Title = "Test4",
                    Description = "Description4",
                    Participants = new List<string>() { "Ivan", "Max" }
                },
                new Note()
                {
                    Id = 5,
                    Title = "Test5",
                    Description = "Description5",
                    Participants = new List<string>() { "Daniil", "Ivan" }
                },
            };

            return notes;
        }

        public static Note CreateEmptyNote()
        {
            Note note = new Note
            {
                Id = 0,
                Title = "Test0",
                Description = "Description0",
                Participants = new List<string>() { "Daniil" }
            };

            return note;
        }
    }
}
