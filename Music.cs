using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private bool On;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks whether the value of boolean On is true
        if (On == true)
        {
            //Reduces the volume of the background music
            GetComponent<AudioSource>().volume -= 0.05f * Time.deltaTime;
        }
    }

    //Checks whether the gameobject colliding is player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Sets the value of boolean On to true
            On = true;
        }
    }
}
