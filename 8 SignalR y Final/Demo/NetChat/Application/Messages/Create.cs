using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Messages
{
  public class Create
  {
    public class Command : IRequest<MessageDto>
    {
      public string Content { get; set; }

      public Guid ChannelId { get; set; }

      public MessageType MessageType { get; set; } = MessageType.Text;

      public IFormFile File { get; set; }
    }

    public class Handler : IRequestHandler<Command, MessageDto>
    {
      private readonly DataContext context;
      private readonly IUserAccessor userAccessor;
      private readonly IMapper _mapper;
      private readonly IMediaUpload _mediaUpload;

      public Handler(DataContext context, IUserAccessor userAccessor,
      IMapper mapper,
      IMediaUpload mediaUpload)
      {
        this.context = context;
        this.userAccessor = userAccessor;
        _mapper = mapper;
        _mediaUpload = mediaUpload;
      }
      public async Task<MessageDto> Handle(Command request, CancellationToken cancellationToken)
      {
        var user = await context
            .Users
            .SingleOrDefaultAsync(x => x.UserName == userAccessor.GetCurrentUserName());

        var channel = await context
              .Channels
              .SingleOrDefaultAsync(x => x.Id == request.ChannelId);

        if (channel == null)
        {
          throw new RestException(HttpStatusCode.NotFound, new { channel = "Channel not found" });
        }

        var message = new Message
        {
          Content = request.MessageType == MessageType.Text ? request.Content :
            _mediaUpload.UploadMedia(request.File).Url,
          Channel = channel,
          Sender = user,
          CreatedAt = DateTime.Now,
          MessageType = request.MessageType
        };

        context.Messages.Add(message);

        if (await context.SaveChangesAsync() > 0)
        {
          return _mapper.Map<Message, MessageDto>(message);
        }

        throw new Exception("There was a problem inserting the message");

      }
    }
  }
}