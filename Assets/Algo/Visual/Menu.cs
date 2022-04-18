using UnityEngine;

public class Menu : MonoBehaviour
{
    public Transform sortPanel;
    
    public void OpenMenu(Transform target)
    {
        transform.gameObject.SetActive(false);
        target.gameObject.SetActive(true);
    }

    public void StartVisualSort(int sortEnum)
    {
        var sortType = (SortEnum) sortEnum;
        transform.gameObject.SetActive(false);
        sortPanel.gameObject.SetActive(true);
        VisualSort visualSort = sortPanel.GetComponent<VisualSort>();
        visualSort.StartSort(sortType);
    }
}
