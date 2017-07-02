using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true, 
                        data = result
                    });
                }
                catch
                {
                    //Logar o erro (Elmah)
                    return BadRequest(new
                    {
                        success = false,
                        error = new[] { "Ocorreu uma falha interna no servidor" }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    sucess = false,
                    errors = notifications
                });
            }
        }

    }
}
