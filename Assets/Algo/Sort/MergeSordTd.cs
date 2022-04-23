using System.Collections;
using UnityEngine;

public partial class VisualSort
{
    IEnumerator MergeSortTd(int left ,int right)
    {
        if (left == right)
        {
            //结束
        }
        else
        {
            int mid = (left + right) / 2;
            yield return StartCoroutine(MergeSortTd(left, mid));
            yield return StartCoroutine(MergeSortTd(mid+1, right));
            var dataArrayCopy = VisualSortData.MyCopy(_dataArray);
            int i = left, j = mid + 1, k;
            for (int l = left; l <= right; l++)
            {
                _dataArray[l].DataState = SortDataState.Selected;
            }
            yield return new WaitForSeconds(0.3f);
            for (k = left; k <= right ; k++)
            {
                yield return new WaitForSeconds(0.15f);
                //判断下标
                if ( i > mid)
                {
                    _dataArray[k] = dataArrayCopy[j++];
                }
                else if (j > right )
                {
                    _dataArray[k] = dataArrayCopy[i++];
                }
                //比较大小
                else if ( dataArrayCopy[i].Value <= dataArrayCopy[j].Value)
                {
                    _dataArray[k] = dataArrayCopy[i++];
                }
                else
                {
                    _dataArray[k] = dataArrayCopy[j++];
                }
                _dataArray[k].DataState = SortDataState.Sorted;
                yield return new WaitForSeconds(0.15f);
            }
        }
        yield return null;
    }
}