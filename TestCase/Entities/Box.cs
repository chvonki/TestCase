namespace TestCase.Entities;

public class Box : StorageObject
{
    public int IdPallet { get; set; }
    public Box(int id, double width, double height, double depth, double weight, DateOnly date, bool isStorageLife, int idPallet)
    : base(id, width, height, depth, weight)
    {
        IdPallet = idPallet;
        CalculateStorageLife(date, isStorageLife);
    }

    public override string ToString()
    {
        return "BOX " + base.ToString();
    }
}