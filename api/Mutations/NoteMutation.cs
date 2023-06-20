using api.Contexts;
using api.Queries;

namespace api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class NoteMutation
    {
        [GraphQLName("fillNoteTable")]
        public bool FillNoteTable([Service] DataContext dbcontext)
        {
            var notes = SetupService.GetFilledNoteList();

            dbcontext.Notes.AddRange(notes);
            dbcontext.SaveChanges();

            return true;
        }
    }
}
