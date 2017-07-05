using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.API.Controllers
{
    //[Route("api")]
    public class ProductController : Controller
    {

        public readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/products")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }


    }
}
