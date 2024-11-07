using TestCase.Entities;

namespace TestCase.DataCollection;

public class ConsoleCollector : IDataCollector
{
    public List<Box> GetBoxes()
    {
        List<Box> boxes = new();
        while (true)
        {
            Console.WriteLine("Continue? (y/n)\n");
            if (Console.ReadLine() == "n")
                break;

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
            var date = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Is it Storage Life? (y/n): ");
            var isStorageLife = Convert.ToBoolean(Console.ReadLine());

            var box = new Box(id, width, height, depth, weight, date, isStorageLife);
            boxes.Add(box);
        }
        return boxes;
    }

    public List<Pallet> GetPallets()
    {
        throw new NotImplementedException();
    }
}