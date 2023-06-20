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
                    Title = "Test1",
                    Description = "Description1",
                    CreatorId = "01"
                },
                new Note()
                {
                    Title = "Test2",
                    Description = "Description2",
                    CreatorId = "02"
                },
                new Note()
                {
                    Title = "Test3",
                    Description = "Description3",
                    CreatorId = "03"
                },
                new Note()
                {
                    Title = "Test4",
                    Description = "Description4",
                    CreatorId = "04"
                },
                new Note()
                {
                    Title = "Test5",
                    Description = "Description5",
                    CreatorId = "05"
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
                CreatorId = "---"
            };

            return note;
        }
    }
}
