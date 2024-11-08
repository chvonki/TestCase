namespace TestCase.Entities;

public class Group
{
    public DateOnly? Date { get; set; }
    public List<Pallet>? Pallets { get; set; }

    public Group(DateOnly? date)
    {
        Date = date;
        Pallets = new();
    }

    public void AddPallet(Pallet pallet)
    {
        Pallets.Add(pallet);
    }

    public override string ToString()
    {
        string result = "\n" + Date.ToString() + " ";
        if (Pallets is not null)
        {
            foreach (var pallet in Pallets)
            {
                result += pallet.ToString();
            }
        }
        return result;
    }
}