using TestCase.Entities;

namespace TestCase.DataCollection;

public class CsvCollector : IDataCollector
{
    public string _path_boxes = @"..\TestCase\Files\boxes.csv";
    private string _path_pallets = @"..\TestCase\Files\pallets.csv";
    private StreamReader? _reader;

    public List<Box> GetBoxes()
    {
        List<Box> boxes = new();
        using (_reader = new StreamReader(_path_boxes))
        {
            string[]? parameters = _reader.ReadLine()!.Split(';'); // игнорирование заголовков в csv файле
            string? line;
            while ((line = _reader.ReadLine()) is not null)
            {
                parameters = line.Split(";");

                var idValid = int.TryParse(parameters[0], out var id);
                var widthValid = double.TryParse(parameters[1], out var width);
                var heightValid = double.TryParse(parameters[2], out var height);
                var depthValid = double.TryParse(parameters[3], out var depth);
                var weightValid = double.TryParse(parameters[4], out var weight);
                var storageLifeValid = DateOnly.TryParseExact(parameters[5], ["dd-MM-yyyy", "yyyy-MM-dd", "dd.MM.yyyy", "yyyy.MM.dd"], out var storageLife);
                var isStorageLifeValid = Boolean.TryParse(parameters[6], out var isStorageLife);
                var idPalletValid = int.TryParse(parameters[7], out var idPallet);

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
        List<Pallet> pallets = new();
        using (_reader = new StreamReader(_path_pallets))
        {
            string[]? parameters = _reader.ReadLine()!.Split(';');
            string? line;
            while ((line = _reader.ReadLine()) is not null)
            {
                parameters = line.Split(";");

                var idValid = int.TryParse(parameters[0], out var id);
                var widthValid = double.TryParse(parameters[1], out var width);
                var heightValid = double.TryParse(parameters[2], out var height);
                var depthValid = double.TryParse(parameters[3], out var depth);

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