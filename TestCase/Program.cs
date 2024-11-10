using TestCase;
using TestCase.DataCollection;
using TestCase.Entities;
using TestCase.FillPallet;
using Microsoft.Extensions.DependencyInjection;

ConsoleDataWriter consoleDataWrite = ConsoleDataWriter.getWriter();

var services = new ServiceCollection()
    .AddTransient<IDataCollector, CsvCollector>()
    .AddTransient<FillPallet>();

using var serviceProvider = services.BuildServiceProvider();

FillPallet? filler = serviceProvider.GetService<FillPallet>(); // класс для заполнения паллет коробками, в качестве метода передается способ получения данных

List<Pallet> pallets = new();
List<Box> boxes = new();

filler!.FillPalletWithBoxes(ref pallets, ref boxes); // заполняем паллеты коробками
consoleDataWrite.PrintAllPalletsAndBoxesInIt(pallets); // выводим все паллеты и коробки в них

SortPallets sortPallets = new SortPallets(); // класс для сортировки паллет

var orderedAndSortedPallets = sortPallets.GroupPalletsByStorageLife(pallets); // группировка паллет по сроку годности, сортировка по возрастанию срока годности
consoleDataWrite.PrintOrderedPalletsByStorageLife(orderedAndSortedPallets);

var topThreePallet = sortPallets.SortByMaxStorageLifeBox(pallets); // 3 паллеты, в которых коробки с наибольшим сроком годности
consoleDataWrite.PrintTopThreePallets(topThreePallet);


