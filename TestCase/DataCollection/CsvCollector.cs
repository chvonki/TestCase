using TestCase.Entities;

namespace TestCase.DataCollection;

public class CsvCollector : IDataCollector
{
    private static string _path_boxes = @"..\TestCase\Files\boxes.csv"; // ..\TestCase\Files\boxes.csv   ..\..\..\Files\boxes.csv
    private static string _path_pallets = @"..\TestCase\Files\pallets.csv";
    private static StreamReader? reader;

    public List<Box> GetBoxes()
    {
        List<Box> boxes = new();
        using (reader = new StreamReader(_path_boxes))
        {
            string[]? parameters = reader.ReadLine()!.Split(';');
            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                parameters = line.Split(";");

                int id = Convert.ToInt32(parameters[0]);
                double width = Convert.ToDouble(parameters[1]);
                double height = Convert.ToDouble(parameters[2]);
                double depth = Convert.ToDouble(parameters[3]);
                double weight = Convert.ToDouble(parameters[4]);
                DateOnly date = DateOnly.Parse(parameters[5]);
                bool isStorageLife = Convert.ToBoolean(parameters[6]);

                var box = new Box(id, width, height, depth, weight, date, isStorageLife);
                boxes.Add(box);
            }
        }
        return boxes;
    }

    public List<Pallet> GetPallets()
    {
        List<Pallet> pallets = new();

        using (reader = new StreamReader(_path_pallets))
        {
            string[]? parameters = reader.ReadLine()!.Split(';');
            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                parameters = line.Split(";");

                int id = Convert.ToInt32(parameters[0]);
                double width = Convert.ToDouble(parameters[1]);
                double height = Convert.ToDouble(parameters[2]);
                double depth = Convert.ToDouble(parameters[3]);

                var pallet = new Pallet(id, width, height, depth);
                pallets.Add(pallet);
            }
        }
        return pallets;
    }
}