using TestCase.DataCollection;
using TestCase.Entities;

namespace TestCase.FillPallet;

public class FillPallet
{
    private IDataCollector _dataCollector;

    public FillPallet(IDataCollector dataCollector)
    {
        _dataCollector = dataCollector;
    }

    public void FillPalletWithBoxes(ref List<Pallet> pallets, ref List<Box> boxes)
    {
        boxes = _dataCollector.GetBoxes();
        pallets = _dataCollector.GetPallets();
        if (pallets.Count != 0)
        {
            if (boxes.Count != 0)
            {
                foreach (var box in boxes)
                {
                    var pallet = pallets.First(p => p.Id == box.IdPallet);
                    pallet.AddBox(box);
                }
            }
        }
    }

}