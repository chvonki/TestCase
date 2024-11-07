﻿using TestCase.Entities;

var box1 = new Box(width: 12.0, height: 5.0,
                  depth: 10.0, weight: 10.0,
                  date: new DateOnly(2024, 10, 30),
                  isStorageLife: false);

var box2 = new Box(width: 6.0, height: 3.0,
                  depth: 9.0, weight: 6.0,
                  date: new DateOnly(2024, 11, 30),
                  isStorageLife: true);

var box3 = new Box(width: 15.0, height: 8.0,
                  depth: 13.0, weight: 16.0,
                  date: new DateOnly(2024, 12, 08),
                  isStorageLife: true);


var pallet = new Pallet(width: 12.0, height: 5.0,
                  depth: 10.0, weight: 10.0);


Console.WriteLine($"BOX: \nWidth = {box1.Width}\nHeight = {box1.Height}\nDepth = {box1.Depth}");
Console.WriteLine($"StorageLife = {box1.StorageLife}\nVolume = {box1.Volume}\n");

Console.WriteLine($"BOX: \nWidth = {box2.Width}\nHeight = {box2.Height}\nDepth = {box2.Depth}");
Console.WriteLine($"StorageLife = {box2.StorageLife}\nVolume = {box2.Volume}\n");

Console.WriteLine($"BOX: \nWidth = {box3.Width}\nHeight = {box3.Height}\nDepth = {box3.Depth}");
Console.WriteLine($"StorageLife = {box3.StorageLife}\nVolume = {box3.Volume}\n");

Console.WriteLine($"PALLET: \nWidth = {pallet.Width}\nHeight = {pallet.Height}\nDepth = {pallet.Depth}");
Console.WriteLine($"StorageLife = {pallet.StorageLife}\nVolume = {pallet.Volume}\n");


pallet.AddBox(box1);
pallet.AddBox(box2);
pallet.AddBox(box3);

foreach (var box in pallet.boxes!)
{
    Console.WriteLine($"BOX: \nWidth = {box.Width}\nHeight = {box.Height}\nDepth = {box.Depth}");
    Console.WriteLine($"StorageLife = {box.StorageLife}\nVolume = {box.Volume}\n");
}

Console.WriteLine($"PALLET: \nWidth = {pallet.Width}\nHeight = {pallet.Height}\nDepth = {pallet.Depth}");
Console.WriteLine($"StorageLife = {pallet.StorageLife}\nVolume = {pallet.Volume}\n");