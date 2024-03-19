using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.Interfaces
{
	public interface IHelperBLL<T>
	{
		IEnumerable<T> GetAll();
		T Get(int id);
	}
}
