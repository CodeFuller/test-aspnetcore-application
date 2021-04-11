using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TestAspNetCoreApplication.Models
{
	[DataContract]
	public class EnvironmentVariable
	{
		[DataMember(Name = "name")]
		public string Name { get; init; }

		[DataMember(Name = "value")]
		public string Value { get; init; }
	}
}
