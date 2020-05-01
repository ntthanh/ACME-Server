﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TG_IT.ACME.Server.Filters;

namespace TG_IT.ACME.Server.Controllers
{
    [ApiController]
    [AddNextNonce]
    public class NonceController : ControllerBase
    {
        [Route("/new-nonce", Name = "NewNonce")]
        [HttpGet, HttpHead]
        public ActionResult GetNewNonce()
        {
            if (HttpMethods.IsGet(HttpContext.Request.Method))
                return NoContent();
            else
                return Ok();
        }
    }
}