using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	public interface IMedicalDataRepository
	{
		List<MedicalData> GetAllData();
		MedicalData GetById(int dataKey);
		MedicalData AddData(MedicalData medicalData);
		MedicalData UpdateData(MedicalData medicalData);
		int DeleteData(int dataKey);
		float Calculate(int platelets, float albumin, char action);
	}
}
