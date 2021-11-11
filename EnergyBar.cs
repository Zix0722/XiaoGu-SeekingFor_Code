using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    public int energyRemain;
    private Vector2 pos;
    public GameObject[] indexPosArray;
    public int indexCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void listAdding(Drag2D obj)
    {
        
        if (indexCount + obj.boxLength <= 5)
        {
            obj.targetPos = indexPosArray[indexCount].transform.position;
            indexCount += obj.boxLength;
            energyRemain -= obj.boxLength;
            Debug.Log("Remain: "+energyRemain);
        }
        else
        {
            //to-do
            obj.targetPos = obj.startPos;
            obj.isDone = false;
        }

    }
}
