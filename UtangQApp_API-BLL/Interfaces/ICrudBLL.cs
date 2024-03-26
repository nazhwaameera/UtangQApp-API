namespace UtangQApp_API_BLL.Interfaces
{
    public interface ICrudBLL<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
