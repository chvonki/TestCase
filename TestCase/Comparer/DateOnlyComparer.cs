namespace TestCase;

public class DateOnlyComparer : IComparer<DateOnly>
{
    public int Compare(DateOnly x, DateOnly y)
    {
        var xValue = x.ToDateTime(new TimeOnly());
        var yValue = y.ToDateTime(new TimeOnly());
        return DateTime.Compare(xValue, yValue);
    }
}