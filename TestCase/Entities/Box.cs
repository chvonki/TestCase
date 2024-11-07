
namespace TestCase.Entities;

public class Box : StorageObject
{
    public Box(double width, double height, double depth, double weight, DateOnly date, bool isStorageLife)
    : base(width, height, depth, weight)
    {
        CalculateStorageLife(date, isStorageLife);
    }
}