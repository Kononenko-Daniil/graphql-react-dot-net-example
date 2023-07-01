using api.Contexts;
using api.Models;
using HotChocolate.Authorization;
using System.Security.Claims;

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
        [UseServiceScope]
        public Note GetNoteById([Service] DataContext dbcontext, 
            [Service] IHttpContextAccessor contextAccessor, 
            int id)
        {
            var user = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); 
            var note = dbcontext.Notes.Where(x => x.Id == id).FirstOrDefault();

            if (note == null)
            {
                note = SetupService.CreateEmptyNote();
            }

            return note;
        }
    }
}
