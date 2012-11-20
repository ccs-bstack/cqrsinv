using NUnit.Framework;
using System;


namespace CQRSInv.Test
{
	[TestFixture]
	public class Order
	{
		[Test]
		public void Create_Order()
		{
			var _order = CQRSInv.Domain.Order.CreateNew("MY SAMPLE ORDER");

			Assert.IsNotNull(_order);
		}
	}
}
