using System.ComponentModel.DataAnnotations;

namespace TestCase.Entities;

public class StorageObject
{
    [Required]
    public int Id { get; set; }

    [Required]
    public double Width { get; set; } // ширина

    [Required]
    public double Height { get; set; } // высота

    [Required]
    public double Depth { get; set; } // глубина

    public double Weight { get; set; } // вес

    public DateOnly? StorageLife { get; set; }
    public bool? IsStorageLife { get; set; } // флаг на тип даты (какая дата пришла)
    public double Volume { get; set; } // объем

    public StorageObject(int id, double width, double height, double depth, double weight)
    {
        Id = id;
        Width = width;
        Height = height;
        Depth = depth;
        Weight = weight;
        CalculateVolume();
    }
    public void CalculateVolume()
    {
        Volume = Width * Height * Depth;
    }

    public void CalculateStorageLife(DateOnly date, bool isStorageLife)
    {
        if (isStorageLife)
        {
            StorageLife = date;
        }
        else
        {
            StorageLife = date.AddDays(100);
        }
    }

    public override string ToString()
    {
        return $"Id: {Id}\nWidth: {Width}, Height: {Height}, Depth: {Depth}\nWeight: {Weight}, Storage date: {StorageLife}\nVolume: {Volume}\n";
    }
}