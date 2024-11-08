using TestCase.Entities;

namespace TestCase.DataCollection;

public interface IDataCollector
{
    public List<Box> GetBoxes();
    public List<Pallet> GetPallets();
}