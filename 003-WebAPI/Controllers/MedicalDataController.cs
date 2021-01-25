using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Test
{
	[Route("api")]
	[ApiController]
	public class MedicalDataController : ControllerBase
	{
		private IMedicalDataRepository medicalDataRepository;

		public MedicalDataController(IMedicalDataRepository _medicalDataRepository)
		{
			medicalDataRepository = _medicalDataRepository;
		}

		[HttpGet("data")]
		public IActionResult GetAllData()
		{
			try
			{
				List<MedicalData> allData = medicalDataRepository.GetAllData();
				return Ok(allData);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("data")]
		public IActionResult AddData(MedicalData medicalData)
		{
			try
			{
				if (medicalDataRepository == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}
				MedicalData addedData = medicalDataRepository.AddData(medicalData);
				return StatusCode(StatusCodes.Status201Created, addedData);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("data/calculate")]
		public IActionResult Calculate(DataToCalculate dataToCalculate)
		{
			try
			{
				float result = medicalDataRepository.Calculate(dataToCalculate.platelets, dataToCalculate.albumin, dataToCalculate.action.ToCharArray()[0]);
				return Ok(result);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}
	}
}
