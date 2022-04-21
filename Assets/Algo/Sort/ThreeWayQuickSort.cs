using System.Collections;
using UnityEngine;


public partial class VisualSort
{

    private int _medianPivot;
    IEnumerator ThreeWayQuickSort(int left, int right)
    {
        yield return StartCoroutine(FindMedian(left, right));
        var medianPivot = _medianPivot;
        if (right - left + 1 >= 3)
        {
            int i = left;
            int j = right - 1;
            while (true)
            {
                //按照中值交换位置
                while(_dataArray[++i].Value < medianPivot ){}
                while (_dataArray[--j].Value > medianPivot){}
                if (i < j)
                {
                    _dataArray[i].DataState = SortDataState.Selected;
                    yield return new WaitForSeconds(0.15f);
                    Swap(i,j);
                    yield return new WaitForSeconds(0.15f);
                    _dataArray[j].DataState = SortDataState.Default;
                }
                else
                {
                    break;
                }
            }
            _dataArray[right -1].DataState = SortDataState.Sorted;
            Swap(i, right -1);
            yield return new WaitForSeconds(0.15f);
            yield return StartCoroutine(ThreeWayQuickSort(left, i - 1));
            yield return StartCoroutine(ThreeWayQuickSort(i + 1, right));
        }
        yield return null;
    }

    IEnumerator FindMedian(int left, int right)
    {
        if (right - left + 1 >= 3)
        {
            int center = (left + right) / 2;
            if (_dataArray[left].Value > _dataArray[center].Value)
            {
                _dataArray[left].DataState = SortDataState.Selected;
                yield return new WaitForSeconds(0.15f);
                Swap(left,center);
                yield return new WaitForSeconds(0.15f);
                _dataArray[left].DataState = SortDataState.Default;
            }
            if (_dataArray[right].Value < _dataArray[center].Value)
            {
                _dataArray[right].DataState = SortDataState.Selected;
                yield return new WaitForSeconds(0.15f);
                Swap(right,center);
                yield return new WaitForSeconds(0.15f);
                _dataArray[right].DataState = SortDataState.Default;
            }
            if (_dataArray[left].Value > _dataArray[center].Value)
            {
                _dataArray[left].DataState = SortDataState.Selected;
                yield return new WaitForSeconds(0.15f);
                Swap(left,center);
                yield return new WaitForSeconds(0.15f);
                _dataArray[left].DataState = SortDataState.Default;
            }
            _dataArray[center].DataState = SortDataState.Selected;
            yield return new WaitForSeconds(0.25f);
            //将中值给right - 1
            Swap(center,right-1);
            _medianPivot = _dataArray[right - 1].Value;
            _dataArray[right - 1].DataState = SortDataState.Default;
            yield return new WaitForSeconds(0.15f);
        }
        else
        {
            if (_dataArray[left].Value > _dataArray[right].Value)
            {
                Swap(left,right);
            }
            _dataArray[left].DataState = SortDataState.Sorted;
            _dataArray[right].DataState = SortDataState.Sorted;
            yield return new WaitForSeconds(0.25f);
        }
        yield return null;
    }


}