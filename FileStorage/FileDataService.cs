using Domain.Models;
using Application.Interfaces;

namespace FileStorage
{
    public class FileDataService : IDataService
    {
        private readonly FileContext _context;

        public FileDataService(FileContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Data> GetDatas()
        {
            return _context.Datas.ToList();
        }

        public async Task RemoveDataAsync(int id)
        {
            var data = _context.Datas.First(data => data.Id == id);
            _context.Datas.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<Data> SaveDataAsync(Data data)
        {
            data.Id = _context.Datas.Select(data => data.Id).DefaultIfEmpty().Max() + 1;
            _context.Datas.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task UpdateDataAsync(Data data)
        {
            var indexToUpdate = _context.Datas.FindIndex(t => t.Id == data.Id);
            if (indexToUpdate != -1)
            {
                _context.Datas[indexToUpdate] = data;
                await _context.SaveChangesAsync();
            }
        }
    }
}
