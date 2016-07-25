using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace customer360.Models
{
public class Interaction : Entity {
	private String customerId;

	public String getCustomerId() {
		return customerId;
	}
}
}