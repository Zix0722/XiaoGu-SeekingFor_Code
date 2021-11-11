using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    int WeekCount = 0;
    int DayCount = 0;

    bool GameStart = false;

    string[] InfoArr =
    {
        "asdadasd",
        "asdasdasd",
        "asdasdas",
        "sdasdasd",
        "sdasdasd",
        "sdasdasd"
    };

    public Text DisInfoText;

    int[,] WeekDayEvent = new int[10, 7];

    struct EventStu
    {
        public int val1;
        int val;
    }

    EventStu[] EventInfoArr;

    public string Tips;
    Text TipInfo;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            WeekDayEvent[0, i] = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart)
        {
            
        }
    }

    private void OnMouseEnter()
    {
        TipInfo.text = Tips;
        TipInfo.gameObject.SetActive(true);

        TipInfo.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
    }

    private void OnMouseExit()
    {
        TipInfo.gameObject.SetActive(false);
    }

    void NextDay()
    {
        if (DayCount < InfoArr.Length - 1)
        {
            DayCount++;
        }
        else
        {
            WeekCount++;
            DayCount = 0;
        }
        StartCoroutine(InfoDisIen());
    }

    IEnumerator InfoDisIen()
    {
        yield return new WaitForSeconds(0.01f);
        DisInfoText.text = " ";
        for (int i = 0; i < InfoArr[DayCount].Length; i++)
        {
            DisInfoText.text += InfoArr[WeekDayEvent[WeekCount, DayCount]][i];
            yield return new WaitForSeconds(0.01f);
        }
        GameStart = true;
    }
}
