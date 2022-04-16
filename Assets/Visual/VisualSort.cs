using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class VisualSort : MonoBehaviour
{
    #region Properties

    public Vector2 screenSize;
    public int randomNumCont = 50;
    private RectTransform[] _visualDataArray;
    public int[] dataArray;

    #endregion
    
    
    #region Mono

    private void Start()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        Initial();
    }

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        for (int i = 0; i < randomNumCont; i++)
        {
            _visualDataArray[i].localScale = new Vector3(1 ,dataArray[i] /100f,1 );
        }
    }

    #endregion
    
    public void Initial()
    {
        _visualDataArray = new RectTransform[randomNumCont];
        dataArray = new int[randomNumCont];
        for (int i = 0; i < randomNumCont; i++)
        {
            dataArray[i] = Random.Range(1, 101);
            GameObject go = new GameObject(i.ToString());
            go.transform.SetParent(this.transform);
            go.AddComponent<Image>().color = new Color( 70,70,70,255 );
            _visualDataArray[i] = (RectTransform)go.transform;
            _visualDataArray[i].anchorMin = Vector2.zero;
            _visualDataArray[i].anchorMax = new Vector2( 0f , 1f);
            _visualDataArray[i].pivot = Vector2.zero;
            _visualDataArray[i].localScale = new Vector3(1 ,dataArray[i] /100f,1 );
            _visualDataArray[i].sizeDelta = new Vector2(1920f / randomNumCont ,  0 );
            _visualDataArray[i].anchoredPosition = new Vector2(1920f / randomNumCont * i, 0);
        }
    }
    
}
