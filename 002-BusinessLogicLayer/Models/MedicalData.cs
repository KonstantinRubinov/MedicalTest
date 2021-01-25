using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;

namespace Test
{
	public class MedicalData
	{
		private int _dataKey;
		private int _platelets;
		private float _albumin;
		private DateTime _enterDate;

		public int dataKey
		{
			get { return _dataKey; }
			set { _dataKey = value; }
		}

		[Range(0, 100)]
		public int platelets
		{
			get { return _platelets; }
			set { _platelets = value; }
		}

		[Range(0.0, 7.0)]
		public float albumin
		{
			get { return _albumin; }
			set { _albumin = value; }
		}

		public DateTime enterDate
		{
			get { return _enterDate; }
			set { _enterDate = value; }
		}

		public override string ToString()
		{
			return
				dataKey + " " +
				platelets + " " +
				albumin + " " +
				enterDate;
		}


		public static MedicalData ToObject(DataRow reader)
		{
			DateTime dateValue;

			MedicalData medicalData = new MedicalData();
			medicalData.dataKey = int.Parse(reader[0].ToString());
			medicalData.platelets = int.Parse(reader[1].ToString());
			medicalData.albumin = float.Parse(reader[2].ToString());

			if (DateTime.TryParse(reader[3].ToString(), out dateValue))
			{
				medicalData.enterDate = DateTime.Parse(reader[3].ToString());
			}

			Debug.WriteLine("medicalData:" + medicalData.ToString());
			return medicalData;
		}
	}
}
