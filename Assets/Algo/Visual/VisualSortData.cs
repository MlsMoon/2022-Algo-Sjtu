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
}