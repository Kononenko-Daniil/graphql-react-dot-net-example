using api.Contexts;
using api.Models;
using HotChocolate.Authorization;

namespace api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class NoteQuery
    {
        [GraphQLName("notes")]
        public IQueryable<Note> GetNotes([Service] DataContext dbcontext)
        {
            var notes = dbcontext.Notes;

            return notes;
        }

        [Authorize]
        [GraphQLName("noteById")]
        public Note GetNoteById([Service] DataContext dbcontext, int id)
        {
            var note = dbcontext.Notes.Where(x => x.Id == id).FirstOrDefault();

            if (note == null)
            {
                note = SetupService.CreateEmptyNote();
            }

            return note;
        }
    }
}
