using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class EdataService
    {
        private readonly ESGContext _context;

        public EdataService(ESGContext context)
        {
            _context = context;
        }

        public async Task<Edata> AddEdataAsync(Edata edata)
        {
            _context.EModels.Add(edata);
            await _context.SaveChangesAsync();
            return edata;
        }

        public async Task<Edata> GetEdataByIdAsync(int id)
        {
            return await _context.EModels.FindAsync(id);
        }

        public async Task<List<Edata>> GetAllEdataAsync()
        {
            return await _context.EModels.ToListAsync();
        }

        public async Task<List<GreenHouse>> GetAllGreenHouseAsync()
        {
            return await _context.GHModels.ToListAsync();
        }

        public async Task<List<Waste>> GetAllWasteAsync()
        {
            return await _context.WModels.ToListAsync();
        }

        public async Task<List<Water>> GetAllWaterAsync()
        {
            return await _context.WaModels.ToListAsync();
        }

        public async Task UpdateEdataAsync(Edata edata)
        {
            _context.EModels.Update(edata);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGreenHouseAsync(GreenHouse greenhouse)
        {
            _context.GHModels.Update(greenhouse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWater(Water water)
        {
            _context.WaModels.Update(water);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWaste(Waste waste)
        {
            _context.WModels.Update(waste);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEdataAsync(int id)
        {
            var edata = await _context.EModels.FindAsync(id);
            if (edata != null)
            {
                _context.EModels.Remove(edata);
                await _context.SaveChangesAsync();
            }
        }
    }
}
