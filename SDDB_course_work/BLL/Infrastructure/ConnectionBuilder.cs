using System.Text;

using DAL.Entities;

namespace BLL.Infrastructure
{
	public static class ConnectionBuilder
	{
		public static string Build(ConnectionDetails details)
		{
			var builder = new StringBuilder();
			builder
				.Append("Data source=")
				.Append(details.Host)
				.Append(";Initial Catalog=")
				.Append(details.DatabaseName)
				.Append(";Integrated Security=")
				.Append(details.IntegratedSecurity);

			return builder.ToString();
		}
	}
}
