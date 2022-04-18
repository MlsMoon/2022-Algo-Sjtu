using System.Collections;
using UnityEngine;

public partial class VisualSort
{
    IEnumerator SelectionSort()
    {
        for (int i = 0; i < _dataArray.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i+1; j < _dataArray.Length; j++)
            {
                _dataArray[j].DataState = SortDataState.Selected;
                if (_dataArray[j].Value < _dataArray[minIndex].Value)
                {
                    minIndex = j;
                }
                yield return new WaitForSeconds(0.05f);
                _dataArray[j].DataState = SortDataState.Default;
            }
            var temp = _dataArray[i];
            _dataArray[i] = _dataArray[minIndex];
            _dataArray[i].DataState = SortDataState.Sorted;
            _dataArray[minIndex] = temp;
        }
        yield return null;
    }
}