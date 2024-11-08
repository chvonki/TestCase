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

    public double Weigth { get; set; } // вес

    public DateOnly? StorageLife { get; set; }
    public bool? IsStorageLife { get; set; } // флаг на тип даты (какая дата пришла)
    public double Volume { get; set; } // объем

    public StorageObject(int id, double width, double height, double depth, double weigth)
    {
        Id = id;
        Width = width;
        Height = height;
        Depth = depth;
        Weigth = weigth;
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
}