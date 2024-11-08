using TestCase.Entities;

namespace TestCase.FillPallet;

public class SortPallets
{
    public List<Group> GroupPalletsByStorageLife(List<Pallet> pallets)
    {
        List<Group> groups = new();
        var storageLifesDictinct = pallets.Select(p => p.StorageLife).Distinct().ToList(); // выбираем уникальные даты по всем паллетам

        foreach (var date in storageLifesDictinct) // перебираем все уникальные даты
        {
            Group palletsAndDate = new Group(date);
            var palletForEveryDate = pallets.Where(p => p.StorageLife == date); // находим паллеты с одной и той же датой

            foreach (var pallet in palletForEveryDate)
            {
                palletsAndDate.AddPallet(pallet); // добавляем паллеты в группу
            }
            SortPalletsByWeight(palletsAndDate.Pallets!); // сортируем паллеты в группе по весу
            groups.Add(palletsAndDate);
        }
        SortGroupsByStorageLife(groups); // сортируем группы по сроку годности
        return groups;
    }

    public void SortGroupsByStorageLife(List<Group> groups)
    {
        groups = groups.OrderBy(g => g.Date).ToList();
    }

    public void SortPalletsByWeight(List<Pallet> pallets)
    {
        pallets = pallets!.OrderBy(p => p.Weight).ToList();
    }

    public void SortPalletsByVolume(List<Pallet> pallets)
    {
        pallets = pallets!.OrderBy(p => p.Volume).ToList();
    }

    public List<Pallet> SortByMaxStorageLifeBox(List<Pallet> pallets)
    {
        var selectedPallets = pallets.Where(p => p.boxes!.Any()) // выбираем коробки во возрастанию срока годности и берем только 3 их них
                                     .OrderByDescending(p => p.boxes!.Max(b => b.StorageLife))
                                     .Take(3)
                                     .ToList();

        SortPalletsByVolume(selectedPallets); // сортируем паллеты по объему
        return selectedPallets;
    }
}