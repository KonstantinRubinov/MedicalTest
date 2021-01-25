using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Test
{
	public class MedicalDataManager : MySqlDataBase, IMedicalDataRepository
	{
		public List<MedicalData> GetAllData()
		{
			DataTable dt = new DataTable();
			List<MedicalData> arrMovie = new List<MedicalData>();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(MedicalDataStringsMySql.GetAllData());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrMovie.Add(MedicalData.ToObject(ms));
			}

			return arrMovie;
		}

		public MedicalData GetById(int dataKey)
		{
			if (dataKey == -1)
				throw new ArgumentOutOfRangeException();

			DataTable dt = new DataTable();

			MedicalData medicalData = new MedicalData();


			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(MedicalDataStringsMySql.GetById(dataKey));
			}

			foreach (DataRow ms in dt.Rows)
			{
				medicalData = MedicalData.ToObject(ms);
			}

			return medicalData;
		}

		public MedicalData AddData(MedicalData medicalData)
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(MedicalDataStringsMySql.AddData(medicalData));
			}
			foreach (DataRow ms in dt.Rows)
			{
				medicalData = MedicalData.ToObject(ms);
			}

			return medicalData;
		}

		public MedicalData UpdateData(MedicalData medicalData)
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(MedicalDataStringsMySql.UpdateData(medicalData));
			}
			foreach (DataRow ms in dt.Rows)
			{
				medicalData = MedicalData.ToObject(ms);
			}

			return medicalData;
		}

		public int DeleteData(int dataKey)
		{
			if (dataKey==-1)
				throw new ArgumentOutOfRangeException();

			int i = 0;
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(MedicalDataStringsMySql.DeleteData(dataKey));
			}
			return i;
		}

		public float Calculate(int platelets, float albumin, char action)
		{
			if (platelets < 0 || albumin < 0)
				throw new ArgumentOutOfRangeException();


			if (action == '/' && albumin == 0)
				throw new ArgumentOutOfRangeException();

			float result = 0;

			switch (action)
			{
				case '+':
					return platelets + albumin;
				case '-':
					return platelets - albumin;
				case '*':
					return platelets * albumin;
				case '/':
					return platelets / albumin;
				default:
					break;
			}
			return result;
		}
	}
}
