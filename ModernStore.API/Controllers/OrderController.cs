using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.API.Controllers
{
    public class OrderController : BaseController
    {
        private readonly OrderCommandHandler _handler;

        public OrderController(IUow uow, OrderCommandHandler handler) : base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Authorize]
        [Route("v1/orders")]
        public async Task<IActionResult> Post([FromBody]RegisterOrderCommand command)
        {
            var customer = User.Identity.Name;
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}
