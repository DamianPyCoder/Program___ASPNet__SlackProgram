using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<UserDto>
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly UserManager<AppUser> userManager;

            private readonly SignInManager<AppUser> signInManager;

            private readonly IJwtGenerator jwtGenerator;

            private readonly DataContext context;

            public Handler(
                UserManager<AppUser> userManager,
                SignInManager<AppUser> signInManager,
                IJwtGenerator jwtGenerator,
                DataContext context
            )
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
                this.jwtGenerator = jwtGenerator;
                this.context = context;
            }

            public async Task<UserDto>
            Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await userManager.FindByEmailAsync(request.Email);

                if (user == null)
                {
                    throw new RestException(HttpStatusCode.Unauthorized);
                }

                var result =
                    await signInManager
                        .CheckPasswordSignInAsync(user,
                        request.Password,
                        false);

                if (result.Succeeded)
                {
                    user.IsOnline = true;
                    await context.SaveChangesAsync();

                    //TODO: generate TOKEN
                    return new UserDto {
                        Token = jwtGenerator.CreateToken(user),
                        UserName = user.UserName,
                        Email = user.Email,
                        Id = user.Id,
                        IsOnline = user.IsOnline,
                        Avatar = user.Avatar,
                        PrimaryAppColor = user.PrimaryAppColor, 
                        SecondaryAppColor = user.SecondaryAppColor
                    };
                }

                throw new RestException(HttpStatusCode.Unauthorized);
            }
        }
    }
}
