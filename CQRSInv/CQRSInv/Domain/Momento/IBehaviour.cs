using System;


namespace CQRSInv.Domain.Momento
{
	public interface IBehaviour
	{
		CQRSInv.Domain.Momento.IMemento CreateMemento();

		void SetMemento(
			CQRSInv.Domain.Momento.IMemento memento);
	}
}