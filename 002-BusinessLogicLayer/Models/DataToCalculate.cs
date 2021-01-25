using System;
using System.ComponentModel.DataAnnotations;

namespace Test
{
	public class DataToCalculate
	{
		private int _platelets;
		private float _albumin;
		private string _action;

		public int platelets
		{
			get { return _platelets; }
			set { _platelets = value; }
		}

		public float albumin
		{
			get { return _albumin; }
			set { _albumin = value; }
		}

		public string action
		{
			get { return _action; }
			set { _action = value; }
		}

		public override string ToString()
		{
			return
				platelets + " " +
				albumin + " " +
				action;
		}
	}
}
