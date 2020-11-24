using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using SimpleGraphQLApp.Models;

namespace SimpleGraphQLApp.Data
{
    public class Query
    {
        [UseSelection]
        public IQueryable<Student> GetStudents([Service] ApplicationDbContext appContext) =>
            appContext.Students;
    }
}
