using TestCase.Entities;

namespace TestCase.DataWriter;

public interface IDataWriter
{
    public void PrintAllPalletsAndBoxesInIt(List<Pallet> pallets);
    public void PrintOrderedPalletsByStorageLife(List<Group> groups);
    public void PrintTopThreePallets(List<Pallet> pallets);
}