using Domain.Models;

namespace Application.Interfaces
{
    public interface IDataService
    {
        List<Data> GetDatas();
        Task RemoveDataAsync(int id);
        Task<Data> SaveDataAsync(Data data);
        Task UpdateDataAsync(Data data);
    }
}
