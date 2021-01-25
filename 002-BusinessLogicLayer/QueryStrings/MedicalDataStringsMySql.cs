using MySql.Data.MySqlClient;

namespace Test
{
	static public class MedicalDataStringsMySql
	{
		static private string queryMedicalDataString = "SELECT dataKey, platelets, albumin, enterDate from MEDDATA ORDER BY enterDate ASC";
		static private string queryMedicalDataByIdString = "SELECT dataKey, platelets, albumin, enterDate from MEDDATA where dataKey=@dataKey";
		static private string queryMedicalDataPost = "INSERT INTO MEDDATA (platelets, albumin, enterDate) VALUES (@platelets, @albumin, @enterDate); SELECT dataKey, platelets, albumin, enterDate FROM MEDDATA WHERE dataKey = SCOPE_IDENTITY();";
		static private string queryMedicalDataUpdate = "UPDATE test MEDDATA platelets = @platelets, albumin = @albumin, enterDate = @enterDate WHERE dataKey = @dataKey; SELECT dataKey, platelets, albumin, enterDate FROM MEDDATA WHERE dataKey = @dataKey;";
		static private string queryMedicalDataDelete = "DELETE FROM MEDDATA WHERE dataKey=@dataKey;";

		static public MySqlCommand GetAllData()
		{
			return CreateSqlCommand(queryMedicalDataString);
		}

		static public MySqlCommand GetById(int dataKey)
		{
			return CreateSqlCommand(dataKey, queryMedicalDataByIdString);
		}

		static public MySqlCommand AddData(MedicalData medicalData)
		{
			return CreateSqlCommand(medicalData, queryMedicalDataPost);
		}

		static public MySqlCommand UpdateData(MedicalData medicalData)
		{
			return CreateSqlCommand(medicalData, queryMedicalDataUpdate);
		}

		static public MySqlCommand DeleteData(int dataKey)
		{
			return CreateSqlCommand(dataKey, queryMedicalDataDelete);
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(MedicalData medicalData, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@dataKey", medicalData.dataKey);
			command.Parameters.AddWithValue("@platelets", medicalData.platelets);
			command.Parameters.AddWithValue("@albumin", medicalData.albumin);
			command.Parameters.AddWithValue("@enterDate", medicalData.enterDate);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(int dataKey, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);
			command.Parameters.AddWithValue("@dataKey", dataKey);
			return command;
		}
	}
}
