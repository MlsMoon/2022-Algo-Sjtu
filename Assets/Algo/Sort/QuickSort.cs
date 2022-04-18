using System.Collections;
using UnityEngine;

public partial class VisualSort
{
    //基本思路：
    //选定一个 pivot 
    //将比pivot 小的放左边
    //比 pivot 大的放右边
    //递归

    private int _quickSortPivot;
    IEnumerator QuickSort(int left ,int right)
    {
        if (left < right)
        {
            yield return StartCoroutine(Partition(left,right));
            var pivot = _quickSortPivot;
            yield return StartCoroutine(QuickSort(left , pivot -1));
            yield return StartCoroutine(QuickSort(pivot + 1, right));
        }
        yield return null;
    }

    IEnumerator Partition(int left ,int right)
    {
        var pivot = _dataArray[left];
        while (left < right)
        {
            _dataArray[right].DataState = SortDataState.Selected;
            yield return new WaitForSeconds(0.1f);
            while (left < right && _dataArray[right].Value >= pivot.Value)
            {
                _dataArray[right].DataState = SortDataState.Selected;
                yield return new WaitForSeconds(0.1f);
                _dataArray[right].DataState = SortDataState.Default;
                right--;
            }
            _dataArray[right].DataState = SortDataState.Default;
            _dataArray[left] = _dataArray[right];
            
            _dataArray[left].DataState = SortDataState.Selected;
            yield return new WaitForSeconds(0.1f);
            while (left<right && _dataArray[left].Value <= pivot.Value)
            {
                _dataArray[left].DataState = SortDataState.Selected;
                yield return new WaitForSeconds(0.1f);
                _dataArray[left].DataState = SortDataState.Default;
                left++;
            }
            _dataArray[right] = _dataArray[left];
            _dataArray[left].DataState = SortDataState.Default;
        }
        _dataArray[left] = pivot;
        _dataArray[left].DataState = SortDataState.Sorted;
        _quickSortPivot = left;
        yield return null;
    }
}