namespace HomeworkEF.Infrastructure.UoW
{
    public class UnitOfWork:IUnitOfWork
    {
        private TodoDbContext _dbContext;

        public UnitOfWork(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
