using HomeworkEF.Dto;

namespace HomeworkEF.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoDto> GetTodos();
        TodoDto GetTodo(int id);
        void CreateTodo(TodoDto todo);
        void CompleteTodo(int id);
        void DeleteTodo(int todo);
    }
}
