using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeS : MonoBehaviour
{
    private int timer = 0;// the variable which contains the count of the timer
    private int m = 0;// minute of the displaying timer
    private int s = 0;// second of the displaying timer
    private int hr = 1;// hour of the displaying timer
    private string min;// to store the minutes in the form of string
    private string sec;// to store the seconds in the form of string
    private string timeStr;// to store the time of the timer in the form of a string
    public static int score = 0;//stores the value of the final time

    // Start is called before the first frame update
    void Start()
    {
        //Calls the function timed every 1 second
        InvokeRepeating("timed", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //checks whether the script is attached to the time textbox
        if (gameObject.tag == "timeNum")
        {
            mainTime();
        }
    }
    void mainTime()
    {
        //Converts seconds into minute : second format
        hr = (timer / 3600);
        m = (timer - (3600 * hr)) / 60;
        s = (timer - (3600 * hr) - (m * 60));
        min = m.ToString();
        sec = s.ToString();
        // stores the final time of the timer in the form of string
        timeStr = min + ":" + sec;
        // Used to show the time as text in the textbox
        gameObject.GetComponent<Text>().text = timeStr;
        //Check whether the number is odd and decreases the text font
        if (timer % 2 != 0)
        {
            gameObject.transform.localScale = new Vector3(0.95f, 0.95f);
        }
        //Checks whether the number is even and increases the text font
        else if (timer % 2 == 0)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f);
        }
    }

    //Increments the value of the timer
    void timed()
    {
        timer += 1;
    }

    //Loads the main game when the button is clicked
    public void GameSceneLoader()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //Loads the Gameover screen
    public void GameOverLoader()
    {
        SceneManager.LoadScene("End");
    }

    private void OnTriggerStay(Collider other)
    {
        //Checks whether the player has collided and loads the end screen
        if(other.tag=="Player")
        {
            score = timer;
            SceneManager.LoadScene("End");
            Debug.Log("high score " + score);
        }
    }
    
}