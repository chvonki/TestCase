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
        while (true)
        {
            Console.WriteLine("Do you want continue enter values? (y/n)");
            string? readNext = Console.ReadLine();

            if (readNext == "n")
                break;
            else
            {
                Console.WriteLine("Enter parameters of BOX\n");

                Console.Write("Id: ");
                var idValid = int.TryParse(Console.ReadLine(), out var id);

                Console.Write("Width: ");
                var widthValid = double.TryParse(Console.ReadLine(), out var width);

                Console.Write("Height: ");
                var heightValid = double.TryParse(Console.ReadLine(), out var height);

                Console.Write("Depth: ");
                var depthValid = double.TryParse(Console.ReadLine(), out var depth);

                Console.Write("Weight: ");
                var weightValid = double.TryParse(Console.ReadLine(), out var weight);

                Console.Write("Storage Life or Production date: ");
                var storageLifeValid = DateOnly.TryParseExact(Console.ReadLine(), ["dd-MM-yyyy", "yyyy-MM-dd", "dd.MM.yyyy", "yyyy.MM.dd"], out var storageLife);

                Console.Write("Is it Storage Life? (y/n): ");
                var isStorageLifeValid = Boolean.TryParse(Console.ReadLine(), out var isStorageLife);

                Console.Write("Id Pallet: ");
                var idPalletValid = int.TryParse(Console.ReadLine(), out var idPallet);

                if (idValid && widthValid && heightValid && depthValid && weightValid && storageLifeValid && isStorageLifeValid && idPalletValid)
                {
                    if (id > 0 && width > 0 && height > 0 && depth > 0 && weight > 0 && idPallet > 0)
                    {
                        var box = new Box(id, width, height, depth, weight, storageLife, isStorageLife, idPallet);
                        boxes.Add(box);
                    }
                    else
                    {
                        Console.WriteLine("Value isn't correct!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Input string is not valid!\n");
                }
            }
        }
        return boxes;
    }

    public List<Pallet> GetPallets()
    {
        List<Pallet>? pallets = new();
        while (true)
        {
            Console.WriteLine("Do you want continue enter values? (y/n)");
            string? readNext = Console.ReadLine();

            if (readNext == "n")
                break;
            else
            {
                Console.WriteLine("Enter parameters of PALLETE\n");

                Console.Write("Id: ");
                var idValid = int.TryParse(Console.ReadLine(), out var id);

                Console.Write("Width: ");
                var widthValid = double.TryParse(Console.ReadLine(), out var width);

                Console.Write("Height: ");
                var heightValid = double.TryParse(Console.ReadLine(), out var height);

                Console.WriteLine("Depth: ");
                var depthValid = double.TryParse(Console.ReadLine(), out var depth);

                if (idValid && widthValid && heightValid && depthValid)
                {
                    if (id > 0 && width > 0 && height > 0 && depth > 0)
                    {
                        var pallet = new Pallet(id, width, height, depth);
                        pallets.Add(pallet);
                    }
                    else
                    {
                        Console.WriteLine("Value isn't correct!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Input string is not valid!\n");
                }
            }
        }
        return pallets;
    }
}