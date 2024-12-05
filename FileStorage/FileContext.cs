using System.Text.Json;
using Domain.Models;

namespace FileStorage;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer dataContainer = new();
    public List<User> Users { get { LoadData(); return dataContainer.Users; } }
    public List<Data> Datas { get { LoadData(); return dataContainer.Datas; } }

    public async Task SaveChangesAsync()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
        };

        var data = JsonSerializer.Serialize(dataContainer, options);
        await File.WriteAllTextAsync(filePath, data);
    }

    public void LoadData()
    {
        if (!File.Exists(filePath))
        {
            dataContainer = new()
            {
                Users = [],
                Datas = []
            };
            return;
        }
        var content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content) ?? new();
    }

}