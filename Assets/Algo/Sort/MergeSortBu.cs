using System;
using System.Collections;
using UnityEngine;

public partial class VisualSort
{
    IEnumerator MergeSortBu()
    {
        int len;
        for (len = 1; len < _dataArray.Length; len *= 2)
        {
            for (int i = 0; i < _dataArray.Length; i++)
            {
                _dataArray[i].DataState = SortDataState.Default;
            }
            yield return new WaitForSeconds(0.15f);
            var tempDataArray = VisualSortData.MyCopy(_dataArray);
            for (int start = 0; start < _dataArray.Length; start = start + len * 2)
            {
                int mid = start + len - 1;
                int end = Math.Min(start + len * 2 -1, _dataArray.Length - 1);
                for (int k = start; k <= end; k++)
                {
                    _dataArray[k].DataState = SortDataState.Selected;
                }
                yield return new WaitForSeconds(0.25f);
                int i = start;
                int j = mid + 1;
                for ( int k = start; k <= end; k++)
                {
                    yield return new WaitForSeconds(0.15f);
                    if (i > mid)
                    {
                        _dataArray[k] = tempDataArray[j++];
                    }
                    else if(j > end)
                    {
                        _dataArray[k] = tempDataArray[i++];
                    }
                    else if (tempDataArray[i].Value <= tempDataArray[j].Value)
                    {
                        _dataArray[k] = tempDataArray[i++];
                    }
                    else
                    {
                        _dataArray[k] = tempDataArray[j++];
                    }
                    _dataArray[k].DataState = SortDataState.Sorted;
                    yield return new WaitForSeconds(0.15f);
                }
            }
        }
        yield return null;
    }
}