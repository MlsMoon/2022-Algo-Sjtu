using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public partial class VisualSort : MonoBehaviour
{
    #region Properties

    public Vector2 screenSize;
    public int randomNumCont = 50;
    private RectTransform[] _visualDataArray;
    private VisualSortData[] _dataArray;

    private Material _white;
    private Material _red;
    private Material _blue;

    #endregion


    #region Mono

    private void Awake()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        Initial();
        //生成几个颜色的材质球
        _white = new Material(Shader.Find("UI/Default"))
        {
            hideFlags = HideFlags.HideAndDontSave,
            color = Color.white,
        };
        _red  = new Material(Shader.Find("UI/Default"))
        {
            hideFlags = HideFlags.HideAndDontSave,
            color = Color.yellow
        };
        _blue  = new Material(Shader.Find("UI/Default"))
        {
            hideFlags = HideFlags.HideAndDontSave,
            color = Color.blue
        };
    }

    private void Update()
    {
        //根据数组来显示
        for (int i = 0; i < randomNumCont; i++)
        {
            _visualDataArray[i].localScale = new Vector3(1 ,_dataArray[i].Value /100f,1 );
            _visualDataArray[i].GetComponent<Image>().material=
                GetVisualDataColor(_dataArray[i].DataState);
        }
    }

    #endregion

    public void Initial()
    {
        _visualDataArray = new RectTransform[randomNumCont];
        _dataArray = new VisualSortData[randomNumCont];
        for (int i = 0; i < randomNumCont; i++)
        {
            _dataArray[i] = new VisualSortData();
            _dataArray[i].Value = Random.Range(1, 101);
            _dataArray[i].DataState = SortDataState.Default;
            GameObject go = new GameObject(i.ToString());
            go.transform.SetParent(this.transform);
            var img = go.AddComponent<Image>();
            img.material = _white;
            _visualDataArray[i] = (RectTransform)go.transform;
            _visualDataArray[i].anchorMin = Vector2.zero;
            _visualDataArray[i].anchorMax = new Vector2( 0f , 1f);
            _visualDataArray[i].pivot = Vector2.zero;
            _visualDataArray[i].localScale = new Vector3(1 ,_dataArray[i].Value /100f,1 );
            _visualDataArray[i].sizeDelta = new Vector2(1920f / randomNumCont - 5 ,  0 );
            _visualDataArray[i].anchoredPosition = new Vector2(1920f / randomNumCont * i +2.5f, 0);
        }
    }

    public void StartSort(SortEnum sortType)
    {
        Debug.Log("Start Sort");
        switch (sortType)
        {
            case SortEnum.Insertion:
                StartCoroutine(Insertion());
                break;
            case SortEnum.QuickSort:
                StartCoroutine(QuickSort( 0 , _dataArray.Length-1));
                break;
            case SortEnum.Selection:
                StartCoroutine(SelectionSort());
                break;
            case SortEnum.HeapSort:
                StartCoroutine(HeapSort());
                break;
            case SortEnum.ThreeWayQuickSort:
                StartCoroutine(ThreeWayQuickSort(0, _dataArray.Length - 1));
                break;
        }
    }

    private Material GetVisualDataColor(SortDataState dataState)
    {
        switch (dataState)
        {
            case SortDataState.Default:
                return _white;
            case SortDataState.Sorted:
                return _red;
            case SortDataState.Selected:
                return _blue;
        }
        return null;
    }
    
    private void Swap(int indexA, int indexB)
    {
        var temp = _dataArray[indexA];
        _dataArray[indexA] = _dataArray[indexB];
        _dataArray[indexB] = temp;
    }

}
