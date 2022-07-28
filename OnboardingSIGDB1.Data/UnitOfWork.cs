using OnboardingSIGDB1.Domain.Interfaces;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext = null;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
            Dispose();
        }

        public void Dispose() => _dataContext.Dispose();
    }
   
}
