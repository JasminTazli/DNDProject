using Domain.Models;

namespace FileStorage;

public record DataContainer
{
    public List<User> Users { get; set; } = [];
    public List<Data> Datas { get; set; } = [];
}
