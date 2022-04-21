using System.Collections;
using UnityEngine;


public partial class VisualSort
{
    IEnumerator Insertion()
    {
        for (int i = 1; i < _dataArray.Length; i++)
        {
            _dataArray[0].DataState = SortDataState.Sorted;
            _dataArray[i].DataState = SortDataState.Sorted;
            for (int j = i; j > 0; j--)
            {
                if (_dataArray[j].Value < _dataArray[j - 1].Value)
                {
                    //交换位置
                    Swap(j,j-1);
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
        Debug.Log("Done");
        yield return null;
    }
}
