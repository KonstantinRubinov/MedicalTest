namespace Test
{
	static public class ConnectionStrings
	{
		static private string mySqlConnectionString = "server=localhost; user id = root; persistsecurityinfo=True; password=admin; database=test";

		static public string GetMySqlConnection()
		{
			return mySqlConnectionString;
		}
	}
}
