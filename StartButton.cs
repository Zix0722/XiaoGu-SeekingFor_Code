using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startBut;

    public GameObject StartCanv;

    public GameObject foreword;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startBut.onClick.AddListener(clickOnStartBut);
        //StartCanv.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void clickOnStartBut()
    {
        StartCanv.gameObject.SetActive(false);
        gameStart();
    }

    private void gameStart()
    {
        foreword.SetActive(true);
    }
}
