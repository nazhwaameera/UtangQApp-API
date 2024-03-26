namespace UtangQApp_Data.Interfaces
{
	public interface IHelper<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int id);
	}
}
