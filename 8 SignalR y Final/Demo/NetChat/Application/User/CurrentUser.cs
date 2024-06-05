using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User
{
    public class CurrentUser
    {
        public class Query : IRequest<UserDto> { }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly IUserAccessor userAccessor;

            private readonly UserManager<AppUser> userManager;

            private readonly IJwtGenerator jwtGenerator;

            public Handler(
                IUserAccessor userAccessor,
                UserManager<AppUser> userManager,
                IJwtGenerator jwtGenerator
            )
            {
                this.userAccessor = userAccessor;
                this.userManager = userManager;
                this.jwtGenerator = jwtGenerator;
            }

            public async Task<UserDto>
            Handle(Query request, CancellationToken cancellationToken)
            {
                var user =
                    await userManager
                        .FindByNameAsync(userAccessor.GetCurrentUserName());

                return new UserDto {
                    UserName = user.UserName,
                    Token = jwtGenerator.CreateToken(user),
                    Email = user.Email,
                    Id = user.Id,
                    Avatar = user.Avatar,
                    PrimaryAppColor = user.PrimaryAppColor,
                    SecondaryAppColor = user.SecondaryAppColor
                };
            }
        }
    }
}
