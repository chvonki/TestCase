using TestCase.Entities;

namespace TestCase.DataCollection;

public class ConsoleCollector : IDataCollector
{
    private static ConsoleCollector? collector;

    protected ConsoleCollector()
    {
    }

    public static ConsoleCollector getCollector()
    {
        if (collector == null)
            collector = new ConsoleCollector();
        return collector;
    }

    public List<Box> GetBoxes()
    {
        List<Box>? boxes = new();

        Console.WriteLine("Enter parameters of BOX\n");

        Console.WriteLine("Id: ");
        var id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Width: ");
        var width = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Height: ");
        var height = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Depth: ");
        var depth = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Weight: ");
        var weight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Storage Life or Production date");
        var date = DateOnly.Parse(Console.ReadLine()!);

        Console.WriteLine("Is it Storage Life? (y/n): ");
        var isStorageLife = Convert.ToBoolean(Console.ReadLine());

        Console.WriteLine("Id Pallet:");
        var idPallet = Convert.ToInt32(Console.ReadLine());

        var box = new Box(id, width, height, depth, weight, date, isStorageLife, idPallet);
        boxes.Add(box);

        return boxes;
    }

    public List<Pallet> GetPallets()
    {
        throw new NotImplementedException();
    }
}