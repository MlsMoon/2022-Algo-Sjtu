
public enum SortDataState
{
    Default = 0,
    Sorted = 1,
    Selected = 2,
}

public class VisualSortData
{
    public int Value;
    public SortDataState DataState;

    public static VisualSortData[] MyCopy(VisualSortData[] input)
    {
        VisualSortData[] result = new VisualSortData[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            var sortData = new VisualSortData();
            sortData.Value = input[i].Value;
            sortData.DataState = input[i].DataState;
            result[i] = sortData;
        }
        return result;
    }
}