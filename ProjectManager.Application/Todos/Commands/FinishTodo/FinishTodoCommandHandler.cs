using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Todos.Commands.FinishTodo
{
    public class FinishTodoCommandHandler : IRequestHandler<FinishTodoCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IDateTimeService _dateTime;

        public FinishTodoCommandHandler(
            IApplicationDbContext context,
            ICurrentUserService currentUser,
            IDateTimeService dateTime)
        {
            _context = context;
            _currentUser = currentUser;
            _dateTime = dateTime;
        }
        public async Task<Unit> Handle(FinishTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _context
                .Todos
                .FirstOrDefaultAsync(x=>x.Id==request.Id);
            
            todo.IsCompleted=true;
            todo.FinishDate = _dateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            var user = await _context
                .Users
                .FirstOrDefaultAsync(x => x.Id == _currentUser.UserId);
            if (todo.IsCompleted)
            {
                var post = new TodoPost
                {
                    Content = $"Zadanie zostało zakończone przez użytkownika {user.FirstName} {user.LastName}.",
                    UserId = _currentUser.UserId,
                    TodoId = request.Id,
                    CreatedAt = _dateTime.Now
                };
                await _context.TodoPosts.AddAsync(post);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
