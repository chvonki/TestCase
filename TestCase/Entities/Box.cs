
namespace TestCase.Entities;

public class Box : StorageObject
{
    public Box(double width, double height, double depth,
               DateOnly date, bool isStorageLife)
               : base(width, height, depth, date, isStorageLife)
    {
    }
}