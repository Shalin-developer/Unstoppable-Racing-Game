using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScore : MonoBehaviour
{
    private int finalScore = 0;//value of score variable of TimeS script
    private int hr,hr2 = 0;//stores the hour of displaying timer
    private int s,s2 = 0;//stores the second of displaying timer
    private int m,m2 = 0;//stores the minute fo displaying timer
    private string min,min2;// to store the minutes in the form of string
    private string sec,sec2;// to store the seconds in the form of string
    private int bscore = 0;//stores the highscore
    private string timeStr,timeStr2;//stores the time in string format
    public Text scoreT;//textbox of score
    public Text scoreH;//textbox of highscore
    // Start is called before the first frame update
    void Start()
    {
        bscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Assigns finalScore the value of score variable of TimeS Script
        finalScore = TimeS.score;
        bestS();   
        timeDisplay();
    }
    
    private void timeDisplay()
    {
        //Converts seconds into minute : second format
        hr = (finalScore / 3600);
        m = (finalScore - (3600 * hr)) / 60;
        s = (finalScore - (3600 * hr) - (m * 60));
        min = m.ToString();
        sec = s.ToString();
        // stores the final time of the timer in the form of string
        timeStr = min + ":" + sec;
        // Used to show the score as text in the textbox
        scoreT.text = timeStr;
    }

    private void bestS()
    {
        //Retreives the high score
        bscore = PlayerPrefs.GetInt("highT");
        //Checks whether the new score is highscore and if yes then sets it as highscore
        if (finalScore < bscore || bscore == 0)
        {
            bscore = finalScore;
            PlayerPrefs.SetInt("highT", bscore);
        }
        //Converts seconds into minute : second format
        hr2 = (bscore / 3600);
        m2 = (bscore - (3600 * hr2)) / 60;
        s2 = (bscore - (3600 * hr2) - (m2 * 60));
        min2 = m2.ToString();
        sec2 = s2.ToString();
        // stores the final time of the timer in the form of string
        timeStr2 = min2 + ":" + sec2;
        // Used to show the highscore as text in the textbox
        scoreH.text = timeStr2;
    }
}
