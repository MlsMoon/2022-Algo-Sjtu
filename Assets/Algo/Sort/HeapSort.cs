using System.Collections;
using UnityEngine;

public partial class VisualSort
{
    IEnumerator HeapSort()
    {
        Debug.Log("堆排序");
        var length = _dataArray.Length;
        //build heap
        for (int i =(int)length/2; i >=0 ; i--)
        {
            yield return StartCoroutine( MaxHeapify(i , length));
        }
        //sort
        for (int i = length - 1; i > 0; i--)
        {
            _dataArray[0].DataState = SortDataState.Selected;
            yield return new WaitForSeconds(0.15f);
            var temp = _dataArray[0];
            _dataArray[0] = _dataArray[i];
            _dataArray[i] = temp;
            _dataArray[i].DataState = SortDataState.Sorted;
            yield return new WaitForSeconds(0.15f);
            length--;
            yield return StartCoroutine(MaxHeapify(0 , length));
        }
        _dataArray[0].DataState = SortDataState.Sorted;
        yield return null;
    }

    IEnumerator MaxHeapify(int index , int len)
    {
        //维护大顶堆的排序
        var leftChild = 2 * index + 1;
        var rightChild = 2 * index + 2;
        var largest = index;
        if (leftChild < len && _dataArray[leftChild].Value > _dataArray[largest].Value )
        {
            largest = leftChild;
        }
        if (rightChild < len && _dataArray[rightChild].Value > _dataArray[largest].Value)
        {
            largest = rightChild;
        }
        if (index != largest)
        {
            _dataArray[largest].DataState = SortDataState.Selected;
            yield return new WaitForSeconds(0.2f);
            var temp = _dataArray[index];
            _dataArray[index] = _dataArray[largest];
            _dataArray[largest] = temp;
            yield return new WaitForSeconds(0.2f);
            _dataArray[index].DataState = SortDataState.Default;
            yield return StartCoroutine(MaxHeapify(largest , len));
        }
        yield return null;
    }
}