using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Test.Cdek.Domain.Models
{
	public class Service
	{
		public string Code { get; set; } // Код доп. услуги доставка в городе получателя (DELIV_RECEIVER)
	}

	public class ServiceResponse
	{
		public string Code { get; set; }
		public float Sum { get; set; }
	}
}
