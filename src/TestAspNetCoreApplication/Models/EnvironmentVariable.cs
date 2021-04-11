using System.Runtime.Serialization;

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
