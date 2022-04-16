using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenMenu(Transform target)
    {
        transform.gameObject.SetActive(false);
        target.gameObject.SetActive(true);
    }

    public void StartVisualSort()
    {
        
    }
}
