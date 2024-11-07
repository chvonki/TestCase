
namespace TestCase.Entities;

public class Pallet : StorageObject
{
    public Pallet(double width, double height, double depth, DateOnly date, bool isStorageLife) : base(width, height, depth, date, isStorageLife)
    {
    }
}