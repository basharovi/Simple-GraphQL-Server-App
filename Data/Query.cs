using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using simple_graphql_app.Models;

namespace simple_graphql_app.Data
{
    public class Query
    {
        [UseSelection]
        public IQueryable<Student> GetStudents([Service] ApplicationDbContext appContext) =>
            appContext.Students;
    }
}
