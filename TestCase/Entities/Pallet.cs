namespace TestCase.Entities;

public class Pallet : StorageObject
{
    public List<Box>? boxes;
    public Pallet(int id, double width, double height, double depth, double weight = 30.0)
    : base(id, width, height, depth, weight)
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

    public void AddBox(Box box) // при добавлении коробки нужно пересчитать объем, вес и дату
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
            var item = boxes.First(b => b.Id == id);
            if (item is not null)
            {
                Weigth -= item.Weigth;
                Volume -= item.Volume;

                RecalculateDate();

                boxes.Remove(item);
            }
            else
            {
                Console.WriteLine("This Box doesn't exist in this Pallet");
            }

        }
    }
}