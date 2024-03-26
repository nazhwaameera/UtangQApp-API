namespace UtangQApp_API_BLL.Interfaces
{
    public interface ICreateViewBLL<T>
    {
        Task<IEnumerable<T>> CreateView(int UserId);
    }
}
