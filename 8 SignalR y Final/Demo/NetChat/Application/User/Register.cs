using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest<UserDto>
        {
            public string UserName { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string Avatar { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            private readonly UserManager<AppUser> userManager;

            public CommandValidator(UserManager<AppUser> userManager)
            {
                RuleFor(x => x.UserName)
                    .NotEmpty()
                    .MustAsync(async (username, cancellation) =>
                        (await userManager.FindByNameAsync(username)) == null)
                    .WithMessage("Username already exists");

                RuleFor(x => x.Email)
                    .NotEmpty()
                    .EmailAddress()
                    .MustAsync(async (email, cancellation) =>
                        (await userManager.FindByEmailAsync(email)) == null)
                    .WithMessage("Email already exists");

                RuleFor(x => x.Password).Password();
                this.userManager = userManager;
            }
        }

        public class Handler : IRequestHandler<Command, UserDto>
        {
            private readonly UserManager<AppUser> userManager;

            private readonly IJwtGenerator jwtGenerator;

            public Handler(
                UserManager<AppUser> userManager,
                IJwtGenerator jwtGenerator
            )
            {
                this.userManager = userManager;
                this.jwtGenerator = jwtGenerator;
            }

            public async Task<UserDto>
            Handle(Command request, CancellationToken cancellationToken)
            {
                var user =
                    new AppUser {
                        Email = request.Email,
                        UserName = request.UserName,
                        Avatar = request.Avatar
                    };

                var result =
                    await userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return new UserDto {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = jwtGenerator.CreateToken(user),
                        Avatar = user.Avatar
                    };
                }

                throw new Exception("Error registering user");
            }
        }
    }
}
