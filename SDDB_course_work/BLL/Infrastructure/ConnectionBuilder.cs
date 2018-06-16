using DAL.Entities;

namespace BLL.Infrastructure
{
	public static class ConnectionBuilder
	{
		public static string Build(ConnectionDetails details)
		{
		    var directory = @"C:\dbs";

		    var builder = $@"Data source={details.Host};AttachDbFilename={directory}{details.DatabaseName};Integrated Security={details.IntegratedSecurity};";
    
			return builder;
		}
	}
}
