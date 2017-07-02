using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.API.Controllers
{
    //[Route("api")]
    public class ProductController : Controller
    {

        [HttpGet]
        [Route("v1/products")]
        public string Get()
        {
            return $"Listando todos os produtos";
        }


        [HttpGet]
        [Route("v1/products/{id}")]
        public string Get(Guid id)
        {
            return $"Produto {id}!";
        }

        [HttpPost]
        [Route("v1/products")]
        public string Post()
        {
            return "Método Post";
        }

    }
}
