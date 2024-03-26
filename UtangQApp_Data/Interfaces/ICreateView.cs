namespace UtangQApp_Data.Interfaces
{
    public interface ICreateView<T>
    {
        Task<IEnumerable<T>> CreateView(int UserId);
    }
}
