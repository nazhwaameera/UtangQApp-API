using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppDAL.Interfaces
{
	public interface IHelper<T>
	{
		IEnumerable<T> GetAll();
		T Get(int id);
	}
}
