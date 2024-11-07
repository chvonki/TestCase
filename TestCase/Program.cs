using TestCase.Entities;

var box = new Box(width: 12.0, height: 5.0,
                  depth: 10.0, date: new DateOnly(2024, 10, 30),
                  isStorageLife: true);
Console.WriteLine($"Box: \nWidth = {box.Width}\nHeight = {box.Height}\nDepth = {box.Depth}");
Console.WriteLine($"StorageLife = {box.StorageLife}\nVolume = {box.Volume}");