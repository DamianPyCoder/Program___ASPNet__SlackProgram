using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Channels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controllers
{
    public class ChannelsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Channel>>>
        List([FromQuery] List.Query query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChannelDto>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<Unit> Create([FromBody] Create.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("private/{id}")]
        public async Task<ActionResult<ChannelDto>> PrivateDetails(string id)
        {
            return await Mediator
                .Send(new PrivateChannelDetails.Query { UserId = id });
        }

        [HttpPut("{id}")]
        public async Task<Unit> Edit(Guid id, [FromBody] Edit.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }
    }
}
