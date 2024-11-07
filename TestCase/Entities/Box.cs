
namespace TestCase.Entities;

public class Box : StorageObject
{
    public Box(int id, double width, double height, double depth, double weight, DateOnly date, bool isStorageLife)
    : base(id, width, height, depth, weight)
    {
        CalculateStorageLife(date, isStorageLife);
    }
}