using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.User
{
    public class Edit
    {
        public class Command : IRequest
        {
            public string PrimaryAppColor { get; set; }

            public string SecondaryAppColor { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit>
            Handle(Command request, CancellationToken cancellationToken)
            {
                var user =
                    await _context
                        .Users
                        .SingleOrDefaultAsync(x =>
                            x.UserName == _userAccessor.GetCurrentUserName());
                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { Channel = "Not found" });

                user.PrimaryAppColor = request.PrimaryAppColor;
                user.SecondaryAppColor = request.SecondaryAppColor;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Error updating user");
            }
        }
    }
}
