using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Drag2D : MonoBehaviour
{
    public Vector2 startPos;

    public Vector2 targetPos;

    private GameObject Game;
    public bool isDone;

    public int boxLength;

    public Transform boxManager;

    public int boxType;

    public GameObject TipInfo;
    public String Tips = " ";
    private bool showTip = true;
    private GameObject tipInfo;

    
    //---------------------------------------------------
    public int valChange;

    private bool moved = false;
    // Start is called before the first frame update
    void Start()
    {
        Game = GameObject.Find("Game");
        moved = false;
        startPos = transform.parent.position;
        switch (boxLength)
        {
            case 1 :
                valChange = 5;
                break;
            case 2 :
                valChange = 10;
                break;
            case 3 :
                valChange = 15;
                break;
        }
        
    }
    private void OnMouseEnter()
    {
        tipInfo = Instantiate(TipInfo);
        tipInfo.transform.GetChild(1).GetComponent<Text>().text = Tips;
        if (showTip)
        {
            //TipInfo.transform.GetChild(1).GetComponent<Text>().text = Tips;
            //Debug.Log("ON the collider");
            tipInfo.gameObject.SetActive(true);
            tipInfo.transform.position = transform.position;
        }
        
    }

    private void OnMouseExit()
    {
        Destroy(tipInfo);
        //TipInfo.gameObject.SetActive(false);
    }

    

    private void OnMouseDrag()
    {
        if (!isDone)
        {
            showTip = false;
            if (tipInfo)
            {
               tipInfo.gameObject.SetActive(false); 
            }
            transform.parent.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    private void OnMouseUp()
    {
        Debug.Log(Vector3.Distance(transform.parent.position,boxManager.position));
        if (Mathf.Abs(transform.parent.position.x - boxManager.position.x) <= 285.0f &&
            Mathf.Abs(transform.parent.position.y - boxManager.position.y) <= 47.5f)
        {
            isDone = true;
            showTip = false;
            boxManager.GetComponent<EnergyBar>().listAdding(this);
            transform.parent.position = new Vector2(targetPos.x, targetPos.y);
            moved = true;
            if (boxLength == 4)
            {
                switch (boxType)
                {
                    case 0:  // entertainment
                        Game.GetComponent<Main>().selectedEnte = true;
                        break;
                    case 2:  // family
                        Game.GetComponent<Main>().selectedFami = true;
                        break;
                    case 3:  // career
                        Game.GetComponent<Main>().selectedCareer = true;
                        break;
                }
            }
        }
        else
        {
            transform.parent.position = new Vector2(startPos.x, startPos.y);
            showTip = true;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        switch (boxType)
        {
            case 0:
                if(moved)
                    Game.GetComponent<Main>().icons[(int)Type.amusement].GetComponent<value>().num += valChange;
                break;
            case 1:
                if(moved)
                    Game.GetComponent<Main>().icons[(int)Type.oldFriends].GetComponent<value>().num += valChange;
                break;
            case 2:
                if(moved)
                    Game.GetComponent<Main>().icons[(int)Type.family].GetComponent<value>().num += valChange;
                break;
            case 3:
                if(moved)
                    Game.GetComponent<Main>().icons[(int)Type.career].GetComponent<value>().num += valChange;
                break;
            case 4:
                if(moved)
                    Game.GetComponent<Main>().icons[(int)Type.mental].GetComponent<value>().num += valChange;
                break;
            
            case 5:
                if(moved)
                    Game.GetComponent<Main>().icons[5].GetComponent<value>().num += valChange;
                break;
        }
    }

    enum Type
    {
        amusement, //0
        oldFriends,//1
        family,//2
        career,//3
        mental,//4
        special//5
    };


}
