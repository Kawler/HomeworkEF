using HomeworkEF.Models;

namespace HomeworkEF.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _dbContext.Set<Todo>();
        }

        public Todo Get(int id)
        {
            var todo = _dbContext.Set<Todo>().FirstOrDefault(el => el.Id == id);
            if (todo == null) return new Todo();
            return todo;
        }

        public void Create(Todo todo)
        {
            _dbContext.Add(todo);
        }

        public void Update(Todo todo)
        {
            _dbContext.Update(todo);
        }

        public void Delete(int todoId)
        {
            var todo = Get(todoId);
            if (todo.Id < 1) return;
            _dbContext.Remove(todo);
        }
    }
}
