namespace TestCase.Entities;

public abstract class StorageObject
{
    public int Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weigth { get; set; }
    public DateOnly StorageLife { get; set; }
    public bool IsStorageLife { get; set; }
    public double Volume { get; set; }

    public StorageObject(double width, double height,
                         double depth, DateOnly date,
                         bool isStorageLife)
    {
        Width = width;
        Height = height;
        Depth = depth;

        if (isStorageLife)
        {
            StorageLife = date;
        }
        else
        {
            CalculationgStorageLife(date);
        }

        CalculateVolume();
    }

    public virtual void CalculateVolume()
    {
        Volume = Width * Height * Depth;
    }

    public void CalculationgStorageLife(DateOnly date)
    {
        StorageLife = date.AddDays(100);
    }
}