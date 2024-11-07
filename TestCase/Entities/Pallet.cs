namespace TestCase.Entities;

public class Pallet : StorageObject
{
    public List<Box>? boxes;
    public Pallet(double width, double height, double depth, double weight)
    : base(width, height, depth, weight)
    {
        boxes = new();
    }

    public bool IsBoxSizeFit(Box box)
    {
        return box.Width <= Width && box.Depth <= Depth;
    }

    public void RecalculateDate() // выбрать минимальную дату коробки
    {
        StorageLife = boxes!.Min(b => b.StorageLife);
    }

    public void AddBox(Box box) // при добавлении коробки нужно пересчитать объем и вес
    {
        if (IsBoxSizeFit(box))
        {
            boxes!.Add(box);
            Weigth += box.Weigth;
            Volume += box.Volume;

            RecalculateDate();
        }
        else
        {
            Console.WriteLine("Box is too big!");
        }
    }

    public void DeleteBox(int id)
    {
        if (boxes is not null)
        {
            var item = (Box)boxes.Where(b => b.Id == id);

            Weigth -= item.Weigth;
            Volume -= item.Volume;

            RecalculateDate();

            boxes.Remove(item);
        }
    }
}