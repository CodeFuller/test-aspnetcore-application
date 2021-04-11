using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TestAspNetCoreApplication.Models;

namespace TestAspNetCoreApplication.Controllers
{
	[ApiController]
	[Route("environment")]
	public class EnvironmentController : ControllerBase
	{
		[HttpGet]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<EnvironmentVariable>))]
		public IEnumerable<EnvironmentVariable> Get()
		{
			return Environment.GetEnvironmentVariables()
				.Cast<DictionaryEntry>()
				.Select(x => new { Name = (string)x.Key, Value = (string)x.Value })
				.Select(x => new EnvironmentVariable
				{
					Name = x.Name,
					Value = x.Value,
				});
		}
	}
}
