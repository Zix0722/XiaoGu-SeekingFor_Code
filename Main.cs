using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject[] amusement;

    public GameObject[] oldFriends;

    public GameObject[] family;

    public GameObject[] career;

    public GameObject[] mental;

    public  GameObject[] icons;

    public Button endBut;

    public GameObject Week;

    public GameObject TxtLoad;

    public GameObject energyBar;
        
    private int weekNum = 0;
    
    private const int totalWeek = 18;

    private GameObject selection;

    public GameObject[] pos;

    public GameObject result;
    public String[] resultTxt;
    private String saveResultTxt = " ";
    
    public GameObject blackScreen;

    private bool animDone = false;
    
    //----------------------------------------------------------------------------------------
    private bool _isFinished = true;
    private bool temp = true;
    private bool destroyDone = true;
    
    //event triggers------------------------------------------
    public bool selectedEnte = false;
    public bool selectedFami = false;
    public bool selectedCareer = false;
    //--------------------------------------------------------
    string[] InfoArr =
    {
        "As a newcomer, Tian is not under pressure at work, and his life is very comfortable. He lamented his own youth and freedom. Moreover, there is no longer any parental concern about when he goes to bed or whether he stays up late to play games. He often played games until very late, enjoying the freedom of entertainment that he had never had before.", //1
        "After the probation period, Tian has become increasingly busy at work, and the requirements of his superiors have gradually become stricter. However, Tian feels that his life is still full of expectations and longings. He enjoys the pleasure of relaxing after the busy schedule.",//2
        "He made new colleagues from his work. In order to have a good relationship with them, Tian often went to team building and gathering with them after get off work. Sometimes he just perfunctory a few short messages from good brothers in college. These colleagues are his predecessors, and they sometimes guide Tian to solve some problems at work.",//3
        "Tian learned that the company has new products to be launched within six months. The superior said that everyone had to work overtime to get through this for a while. Tian found himself a little tired. He hasn't called his parents for a long time. Every day I revolve around work and life. He feels so tired.",//4
        "Before going out, he glanced at his desktop computer and the dusty PlayStation. Tian lamented that he hadn't played games for a long time. He didn't have time to play the new games he pre-ordered before. He sighed, I have to work overtime to catch the end of the project at night, I'll think about it later.",//5
        "It's the last sprint, Tian followed the team and successfully completed the final launch of the software. Six months of busyness has come to an end. For the first time, Tian felt the joy that he could contribute to a team so much. Although it was hard work, it was worth it in the end.",//6
        "Tian's mother called and said that his father was not in good health recently. Tian is a little worried, but he can't do anything. He asked his mother to take his father to the hospital to check. The intensity of recent work has not been as easy as imagined, but Tian is almost used to it at this level. ",//7
        "Tian has been a little absent-minded at work recently, and he often overlooks some details of the problem, which leads to many work mistakes that shouldn't occur. ",//8
        "Tian met a new girl, her name is Ning. Tian likes her very much, but he has not had the courage to confess. Sometimes, even though he was at work, he would still wonder how he could go further with Ning. ",//9
        "Fortunately, after constant contact, Tian and Ning get along better and better. One night, Ning agreed to be Tian's girlfriend. Tian was so happy that he missed the conference call that night. ",//10
        "Tian spends a certain amount of time with Ning every day. When Ning learned that he hadn't put his mind on work recently, she told Tian that she didn't want their relationship to affect Tian's work. Tian smiled and said that he would work hard but didn't care much.",//11
        "Tian and Ning often quarreled and argued about the little things in life recently. The emotional ups and downs caused Tian's life to become a mess. He contacted the college roommates and tried to find a solution to deal with the relationship with Ning. He and his old friends also talked a lot about her. ",//12
        "Ning said to Tian, you are a good person, but we are not suitable. Unfortunately, they finally broke up. Tian was sad for a long time. He suddenly realized that he didn't seem to have the passion for his life at the beginning. ",//13
        "Tian decides that he wants to find the right track of life again. He started to focus on work and life again. He adopted a cat, Jack, which brought him some comfort. ",//14
        "Tian's life gradually became a kind of cycle, dull and boring. Although life is calm, Tian also tried to become more optimistic. One day, he called and asked about his father's condition in detail, and learned that his father had enteritis. ",//15
        "Tian was transferred to a new project team, the project developed the most cutting-edge technology. This is a huge challenge for Tian. ",//16
        "During this time, Tian was still sad about Ning sometimes, but he made up for a lot of games he hadn't played before. The work is just an ordinary deal. He thinks that the life of going to work during the day and having fun at night is also a kind of enjoyment in hardship. ",//17a
        "Tian has been asking about his father's condition during this time. Although his father felt very optimistic, Tian always felt that the doctor's diagnosis reminder should be paid more attention to. He kept reminding his mother to pay attention to his father's condition and to review it regularly.",//17b  18
        "Tian devoted himself to the new project. He met the new team leader and learned a lot from him. The project is in progress and Tian is also improving. He feels that maybe he likes work because he has experienced the satisfaction and sense of accomplishment brought by progress in his work.",//17c  19
        "I have been running around in a new city for 3 years...Tian drank some alcohol one night and was slightly drunk. Looking back at his initial state of mind and current life state, he found that he had changed a lot... ",//18   20
        
    };
    
    public Text DisInfoText;

    private bool GameStart;
    int WeekCount = 0;
    int DayCount = 0;

    struct EventStu
    {
        public int amus;
        public int oldF;
        public int fam;
        public int career;
        public int mental;

        public EventStu(int amus, int oldf, int fami, int career, int mental)
        {
            this.amus = amus;
            this.oldF = oldf;
            this.fam = fami;
            this.career = career;
            this.mental = mental;
        }
    }

    private EventStu[] EventList = new EventStu[20]
    {
        new EventStu(2,1,1,2,1),//1
        new EventStu(2,1,2,1,1),//2
        new EventStu(1,2,1,2,1),//3
        new EventStu(3,2,2,3,2),//4
        new EventStu(2,1,2,3,1),//5
        new EventStu(2,1,3,1,1),//6
        new EventStu(2,1,2,2,1),//7
        new EventStu(2,1,2,1,1),//8
        new EventStu(1,1,1,1,3),//9
        new EventStu(2,1,2,1,1),//10
        new EventStu(1,2,1,1,2),//11
        new EventStu(2,1,1,1,3),//12
        new EventStu(4,1,1,2,1),//13
        new EventStu(2,1,1,2,2),//14
        new EventStu(2,1,4,2,1),//15
        new EventStu(2,3,2,4,1),//16
        new EventStu(2,1,2,1,3),//17a
        new EventStu(2,1,2,1,3),//17b
        new EventStu(2,1,2,1,3),//17c
        new EventStu(2,3,3,2,2)//18
    };
    // Start is called before the first frame update
    void Start()
    {
        DisInfoText = TxtLoad.GetComponent<Text>();
        selection = GameObject.Find("selection");
        weekNum = 1;
        Week.GetComponent<Text>().text = "Year "+year+", March";
        _isFinished = false;
        endBut.onClick.AddListener(endButOnClick);
    }

    private void endButOnClick()
    {
        if(WeekCount!=20)
            StartCoroutine(showBlack());
        _isFinished = true;
        destroyDone = false;
        if (selectedEnte)
        {
            if (WeekCount == 16)
                WeekCount+= 2;
        }
        if (selectedFami)
        {
            if (WeekCount == 15)
                WeekCount++;
            if (WeekCount == 17)
                WeekCount++;
        }
        if (selectedCareer)
        {
            if (WeekCount == 15)
                WeekCount+=2;
        }

        if (!selectedCareer && !selectedEnte && !selectedFami && WeekCount == 15)
        {
            WeekCount += 2;
        }
        weekNum++;
        WeekCount++;
        temp = true;
        ShowCorretWeekInfo(weekNum);
        if (WeekCount == 20)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            //todo
            
            //result.gameObject.SetActive(true);
            if (icons[(int)Type.amusement].GetComponent<value>().num > 20)
            {
                saveResultTxt += resultTxt[0] + "\n";
            }
            if (icons[(int)Type.amusement].GetComponent<value>().num <= 20)
            {
                saveResultTxt += resultTxt[1] + "\n";
            }
            if (icons[(int)Type.oldFriends].GetComponent<value>().num > 20)
            {
                saveResultTxt += resultTxt[2] + "\n";
            }
            if (icons[(int)Type.oldFriends].GetComponent<value>().num <= 20)
            {
                saveResultTxt += resultTxt[3] + "\n";
            }
            if (icons[(int)Type.family].GetComponent<value>().num > 20)
            {
                saveResultTxt += resultTxt[4] + "\n";
            }
            if (icons[(int)Type.family].GetComponent<value>().num <= 20)
            {
                saveResultTxt += resultTxt[5] + "\n";
            }
            if (icons[(int)Type.career].GetComponent<value>().num > 20)
            {
                saveResultTxt += resultTxt[6] + "\n";
            }
            if (icons[(int)Type.career].GetComponent<value>().num <= 20)
            {
                saveResultTxt += resultTxt[7] + "\n";
            }
            if (icons[(int)Type.mental].GetComponent<value>().num > 20)
            {
                saveResultTxt += resultTxt[8] + "\n";
            }
            if (icons[(int)Type.mental].GetComponent<value>().num <= 20)
            {
                saveResultTxt += resultTxt[9] + "\n";
            }

            StartCoroutine(showResult());
            result.transform.GetChild(0).GetComponent<Text>().text = saveResultTxt;
        }

        energyBar.GetComponent<EnergyBar>().indexCount = 0;
        //changeValueByStroy();
    }

    private int year = 2021;
    private int month = 3;
    void ShowCorretWeekInfo(int weekNum)
    {
        switch (weekNum)
        {
            case 1:
                Week.GetComponent<Text>().text = "Year "+year+", Mar.";
                break;
            case 2:
                Week.GetComponent<Text>().text = "Year "+year+", May";
                break;
            case 3:
                Week.GetComponent<Text>().text = "Year "+year+", Jul.";
                break;
            case 4:
                Week.GetComponent<Text>().text = "Year "+year+", Sep.";
                break;
            case 5:
                Week.GetComponent<Text>().text = "Year "+year+", Nov.";
                break;
            case 6:
                Week.GetComponent<Text>().text = "Year "+year+", Jan.";
                break;
            case 7:
                year++;
                Week.GetComponent<Text>().text = "Year "+year+", Mar.";
                break;
            case 8:
                Week.GetComponent<Text>().text = "Year "+year+", May";
                break;
            case 9:
                Week.GetComponent<Text>().text = "Year "+year+", Jul.";
                break;
            case 10:
                Week.GetComponent<Text>().text = "Year "+year+", Sep.";
                break;
            case 11:
                Week.GetComponent<Text>().text = "Year "+year+", Nov.";
                break;
            case 12:
                Week.GetComponent<Text>().text = "Year "+year+", Jan.";
                break;
            case 13:
                year++;
                Week.GetComponent<Text>().text = "Year "+year+", Mar.";
                break;
            case 14:
                Week.GetComponent<Text>().text = "Year "+year+", May";
                break;
            case 15:
                Week.GetComponent<Text>().text = "Year "+year+", Jul.";
                break;
            case 16:
                Week.GetComponent<Text>().text = "Year "+year+", Sep.";
                break;
            case 17:
                Week.GetComponent<Text>().text = "Year "+year+", Nov.";
                break;
            case 18:
                Week.GetComponent<Text>().text = "Year "+year+", Jan.";
                break;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        /*if (energyBar.GetComponent<EnergyBar>().energyRemain == 0)
        {
            endBut.GetComponent<Button>().interactable = true;
        }
        else
        {
            endBut.GetComponent<Button>().interactable = false;
        }*/
        
        if (_isFinished)
        {
           destroySelection();
           //_isFinished = false;
        }

        if (temp && destroyDone)
        {
            changeValueByStroy(weekNum);
            Debug.Log(WeekCount);
            if (WeekCount == 14 && selectedEnte)
            {
                loadNewWeek(EventList[18].amus,EventList[18].oldF,EventList[18].fam,
                        EventList[18].career,EventList[18].mental);
                
            }else if (WeekCount == 15 && (selectedEnte || selectedFami))
            {
                
                    loadNewWeek(EventList[19].amus,EventList[19].oldF,EventList[19].fam,
                        EventList[19].career,EventList[19].mental); 
                
            }
            else
            {
               loadNewWeek(EventList[WeekCount].amus,EventList[WeekCount].oldF,EventList[WeekCount].fam,
                                                             EventList[WeekCount].career,EventList[WeekCount].mental); 
            }
            
            StartCoroutine(InfoDisIen());
            temp = false;
            
        }
            
        
        

        
    }
    IEnumerator InfoDisIen()
    {
        yield return new WaitForSeconds(0.02f);
        DisInfoText.text = " ";
        for (int i = 0; i < InfoArr[WeekCount].Length; i++)
        {
            DisInfoText.text += InfoArr[WeekCount][i];
            yield return new WaitForSeconds(0.02f);
        }
        GameStart = true;
    }
    void loadNewWeek(int amus, int oldF, int fam, int career, int mental)
    {
        energyBar.GetComponent<EnergyBar>().energyRemain = 5;
        GameObject newSelection;
        switch (amus)
        {
            case 1:
                newSelection = Instantiate(amusement[0], pos[0].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 2:
                newSelection = Instantiate(amusement[1], pos[0].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 3:
                newSelection = Instantiate(amusement[2], pos[0].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 4:
                newSelection = Instantiate(amusement[3], pos[0].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
        }
        switch (oldF)
        {
            case 1:
                newSelection = Instantiate(oldFriends[0], pos[1].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 2:
                newSelection = Instantiate(oldFriends[1], pos[1].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 3:
                newSelection = Instantiate(oldFriends[2], pos[1].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
        }
        switch (fam)
        {
            case 1:
                newSelection = Instantiate(family[0], pos[2].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 2:
                newSelection = Instantiate(family[1], pos[2].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 3:
                newSelection = Instantiate(family[2], pos[2].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 4:
                newSelection = Instantiate(family[3], pos[2].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
        }
        switch (career)
        {
            case 1:
                newSelection = Instantiate(this.career[0], pos[3].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 2:
                newSelection = Instantiate(this.career[1], pos[3].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 3:
                newSelection = Instantiate(this.career[2], pos[3].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 4:
                newSelection = Instantiate(this.career[3], pos[3].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
        }
        switch (mental)
        {
            case 1:
                newSelection = Instantiate(this.mental[0], pos[4].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 2:
                newSelection = Instantiate(this.mental[1], pos[4].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
            case 3:
                newSelection = Instantiate(this.mental[2], pos[4].transform.position,Quaternion.identity);
                newSelection.transform.parent = selection.transform;
                newSelection.transform.GetChild(0).GetComponent<Drag2D>().boxManager = energyBar.transform;
                break;
        }
    }

    void destroySelection()
    {
        if (selection.transform.childCount != 0)
        {
            Destroy(selection.transform.GetChild(0).gameObject);
        }
        else
        {
            _isFinished = false;
            destroyDone = true;
        }
    }

    void changeValueByStroy(int weekNum)
    {
        switch (weekNum)
        {
            case 1:
                valueChange(Type.amusement,5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-5);
                valueChange(Type.mental,5);
                break;
            case 2:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-5);
                valueChange(Type.mental,-5);
                break;
            case 3:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-15);
                valueChange(Type.family,-5);
                valueChange(Type.career,5);
                valueChange(Type.mental,-5);
                break;
            case 4:
                valueChange(Type.amusement,-10);
                valueChange(Type.oldFriends,-10);
                valueChange(Type.family,-10);
                valueChange(Type.career,-10);
                valueChange(Type.mental,-15);
                break;
            case 5:
                valueChange(Type.amusement,-10);
                valueChange(Type.oldFriends,0);
                valueChange(Type.family,0);
                valueChange(Type.career,0);
                valueChange(Type.mental,-15);
                break;
            case 6:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,10);
                valueChange(Type.mental,10);
                break;
            case 7:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-5);
                valueChange(Type.mental,-10);
                break;
            case 8:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-10);
                valueChange(Type.mental,-5);
                break;
            case 9:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-10);
                valueChange(Type.mental,-5);
                break;
            case 10:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-10);
                valueChange(Type.mental,10);
                break;
            case 11:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-5);
                valueChange(Type.mental,10);
                break;
            case 12:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,10);
                valueChange(Type.family,-5);
                valueChange(Type.career,-5);
                valueChange(Type.mental,-10);
                break;
            case 13:
                valueChange(Type.amusement,-10);
                valueChange(Type.oldFriends,-10);
                valueChange(Type.family,-5);
                valueChange(Type.career,-10);
                valueChange(Type.mental,-15);
                break;
            case 14:
                valueChange(Type.amusement,0);
                valueChange(Type.oldFriends,0);
                valueChange(Type.family,0);
                valueChange(Type.career,0);
                valueChange(Type.mental,5);
                break;
            case 15:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-5);
                valueChange(Type.mental,-15);
                break;
            case 16:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-5);
                valueChange(Type.mental,-5);
                break;
            case 17:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-5);
                valueChange(Type.mental,-5);
                break;
            case 18:
                valueChange(Type.amusement,-5);
                valueChange(Type.oldFriends,-5);
                valueChange(Type.family,-5);
                valueChange(Type.career,-5);
                valueChange(Type.mental,-5);
                break;
        }
    }

    void valueChange(Type type, int valChange)
    {
        icons[(int)type].GetComponent<value>().num += valChange;
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

    IEnumerator showBlack()
    {
        yield return new WaitForSeconds(0.01f);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(4f);
        blackScreen.SetActive(false);
    }

    IEnumerator showResult()
    {
        yield return new WaitForSeconds(0.01f);
        result.SetActive(true);
    }
}
