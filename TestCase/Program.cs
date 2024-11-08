using System.Runtime.CompilerServices;
using TestCase.DataCollection;
using TestCase.Entities;
using TestCase.FillPallet;


CsvCollector csvCollector = CsvCollector.getCollector();
FillPallet filler = new FillPallet(csvCollector);

List<Pallet> pallets = new();
List<Box> boxes = new();


filler.FillPalletWithBoxes(ref pallets, ref boxes);

// foreach (var pallet in pallets)
// {
//     Console.WriteLine("PALLET № " + pallet.ToString());
//     if (pallet.boxes is not null)
//     {
//         foreach (var box in pallet.boxes)
//         {
//             Console.WriteLine("BOX № " + box.ToString());
//         }
//     }
// }

SortPallets sortPallets = new SortPallets();
var sortlist = sortPallets.GroupPalletsByStorageLife(pallets);

var TopThreePallet = sortPallets.SortByMaxStorageLifeBox(pallets);

foreach (var line in TopThreePallet)
{
    Console.WriteLine(line.ToString());
    foreach (var box in line.boxes!)
    {
        Console.WriteLine(box.ToString());
    }
}

