﻿using HomeworkEF.Dto;
using HomeworkEF.Services;
using HomeworkEF.Models;
using HomeworkEF.Infrastructure.Repositories;


namespace HomeworkEF.Services
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _todoRepo;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepo = todoRepository;
        }

        public IEnumerable<TodoDto> GetTodos()
        {
            return _todoRepo.GetTodos().Select(el => ModelToDto(el));
        }

        public TodoDto GetTodo(int id)
        {
            return ModelToDto(_todoRepo.Get(id));
        }

        public void CompleteTodo(int todoId)
        {
            var todo = _todoRepo.Get(todoId);
            if (todo.Id < 1) return;
            todo.IsDone = true;
            _todoRepo.Update(todo);
        }

        public void CreateTodo(TodoDto todoDto)
        {
            var todo = new Todo()
            {
                Id = 0,
                Title = todoDto.Title,
                IsDone = todoDto.IsDone
            };
            _todoRepo.Create(todo);
        }

        public void DeleteTodo(int todoId)
        {
            _todoRepo.Delete(todoId);
        }

        private TodoDto ModelToDto(Todo todo)
        {
            return new TodoDto()
            {
                Id = todo.Id,
                Title = todo.Title,
                IsDone = todo.IsDone
            };
        }
    }
}
