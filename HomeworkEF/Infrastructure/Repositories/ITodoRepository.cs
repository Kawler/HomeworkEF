using HomeworkEF.Models;

namespace HomeworkEF.Infrastructure.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodos();
        Todo Get(int id);
        void Create(Todo todo);
        void Update(Todo todo);
        void Delete(int todo);
    }
}

