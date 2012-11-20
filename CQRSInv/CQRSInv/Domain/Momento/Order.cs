using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRSInv.Domain.Momento
{
	[Serializable]
	public class Order : CQRSInv.Domain.Momento.IMemento
	{
		public Guid Id { get; private set; }
		public string Description { get; private set; }


		public Order(
			Guid id,
			string description)
		{
			this.Id = id;
			this.Description = description;
		}
	}
}
