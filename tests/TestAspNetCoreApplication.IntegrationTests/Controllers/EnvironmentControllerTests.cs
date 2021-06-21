using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAspNetCoreApplication.Models;

namespace TestAspNetCoreApplication.IntegrationTests.Controllers
{
	[TestClass]
	public class EnvironmentControllerTests
	{
		[TestMethod]
		public async Task Get_ReturnsCorrectResponse()
		{
			// Arrange

			Environment.SetEnvironmentVariable("TEST_ENVIRONMENT_VARIABLE", "Some Test Value");

			using var factory = new WebApplicationFactory<Startup>();
			var client = factory.CreateClient();

			// Act

			var variables = await client.GetFromJsonAsync<IReadOnlyCollection<EnvironmentVariable>>("/environment", CancellationToken.None);

			// Assert

			variables.Should().ContainSingle(x => x.Name == "TEST_ENVIRONMENT_VARIABLE" && x.Value == "Not Some Test Value");
		}
	}
}
