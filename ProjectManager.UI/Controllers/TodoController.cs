using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Todos.Commands.AddPost;
using ProjectManager.Application.Todos.Commands.DeleteTodo;
using ProjectManager.Application.Todos.Commands.DeleteTodoPost;
using ProjectManager.Application.Todos.Commands.FinishTodo;
using ProjectManager.Application.Todos.Queries.GetAddTodo;
using ProjectManager.Application.Todos.Queries.GetEditTodo;
using ProjectManager.Application.Todos.Queries.GetFromUserTodos;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;
using ProjectManager.Application.Todos.Queries.GetTodo;
using ProjectManager.Application.Todos.Queries.GetUserTodos;

namespace ProjectManager.UI.Controllers
{
    public class TodoController : BaseController
    {
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger; 
        }
        public async Task <IActionResult> Todos(int id)
        {
            return View(await Mediator.Send(new GetProjectTodosQuery { Id = id}));
        }

        public async Task<IActionResult> UserTodos()
        {
            return View(await Mediator.Send(new GetUserTodosQuery()));
        }

        public async Task<IActionResult> FromUserTodos()
        {
            return View(await Mediator.Send(new GetFromUserTodosQuery()));
        }

        public async Task<IActionResult> Todo(int id)
        {
            return View(await Mediator.Send(new GetTodoQuery { Id = id }));
        }

        public async Task<IActionResult> UserToTodo(int id)
        {
            return View(await Mediator.Send(new GetTodoQuery { Id = id }));
        }


        public async Task<IActionResult> AddTodo(int id)
        {
            return View(await Mediator.Send(new GetAddTodoQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTodo(AddTodoVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.Todo);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Zadanie zostało dodane.";

            return RedirectToAction("Todos", new { @id = viewModel.Project.Id });
        }

        public async Task<IActionResult> EditTodo(int id)
        {
            return View(await Mediator.Send(new GetEditTodoQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTodo(EditTodoVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.Todo);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane zostały zaktualizowane .";

            return RedirectToAction("Todos", new { @id = viewModel.Project.Id });
        }

        [HttpPost]
        public async Task<IActionResult> FinishTodo(int id)
        {
            try
            {
                await Mediator.Send(
                    new FinishTodoCommand
                    {
                        Id = id
                    });

                return Json(new { success = true });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, null);
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                await Mediator.Send(
                    new DeleteTodoCommand
                    {
                        Id = id
                    });

                return Json(new { success = true });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, null);
                return Json(new { success = false });
            }
        }
         
        public async Task<IActionResult> AddPost(int id, string title)
        {
            ViewData["Todo"] = title;
            return View(new AddPostCommand { TodoId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(AddPostCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);
            TempData["Success"] = "Komentarz został dodany.";

            return RedirectToAction("UserToTodo", new { @id = command.TodoId });
        }

        public async Task<IActionResult> AddPostMan(int id, string title)
        {
            ViewData["Todo"] = title;
            return View(new AddPostCommand { TodoId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPostMan(AddPostCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);
            TempData["Success"] = "Komentarz został dodany.";

            return RedirectToAction("Todo", new { @id = command.TodoId });
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await Mediator.Send(
                    new DeleteTodoPostCommand
                    {
                        Id = id
                    });

                return Json(new { success = true });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, null);
                return Json(new { success = false });
            }
        }
    }
}
