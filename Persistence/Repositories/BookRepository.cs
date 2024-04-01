
using Assesment.Application.Contracts.Persistence;
using Assessment.Domain;

namespace Persistence.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly BookAppDbContext _context;

        public BookRepository(BookAppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
