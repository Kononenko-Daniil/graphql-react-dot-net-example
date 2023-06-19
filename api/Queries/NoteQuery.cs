using api.Models;

namespace api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class NoteQuery
    {
        public NoteQuery() { }

        [GraphQLName("notes")]
        public IEnumerable<Note> GetNotes()
        {
            var notes = SetupService.GetFilledNoteList();

            return notes;
        }

        [GraphQLName("noteById")]
        public Note GetNoteById(int id)
        {
            var note = SetupService
                    .GetFilledNoteList()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

            if (note == null)
            {
                note = SetupService.CreateEmptyNote();
            }

            return note;
        }
    }
}
