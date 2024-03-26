namespace UtangQApp_API_BLL.Interfaces
{
	public interface IHelperBLL<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int id);
	}
}
