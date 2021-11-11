using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class value : MonoBehaviour
{
    public Slider green;

    public float num;

    public Image color;

    public Text val;
    //private float percent;
    
    // Start is called before the first frame update
    void Start()
    {
        num =70;
        //color = GameObject.Find("Fill").GetComponent<Image>();
    }

    private void OnMouseEnter()
    {
       
        val.text = num.ToString();
        val.gameObject.SetActive(true);
        //Debug.Log("ON the collider");
        val.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        
    }

    private void OnMouseExit()
    {
        val.gameObject.SetActive(false);
    }

    // Update is called once per frame
    
    void Update()
    {
        setGreenHeight(num);
        setColor();
    }

    private void setGreenHeight(float num)
    {
        green.value = num;
    }

    private void setColor()
    {
        if (num <= 60)
        {
            color.color = new Color32(207, 184, 56,255);
            if (num <= 25)
            {
                color.color = new Color32(207, 67, 56,255);
            }
        }
        else
        {
            color.color = new Color32(96, 207, 56,255);
        }
        
    }
    
    //private 
}
