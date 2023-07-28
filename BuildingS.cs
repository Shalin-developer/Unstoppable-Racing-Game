using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingS : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

//This function checks whether it is colliding with the boxcollider
    public void OnTriggerEnter(Collider other)
    {
        Renderer rend = this.GetComponent<Renderer>();
        if (other.tag == "Bcollider")
        {
            //Makes the building invisible
            rend.enabled = false;
        }
    }

//This function checks whether it has stopped colliding with the boxcollider
    public void OnTriggerExit(Collider other)
    {
        Renderer rend = this.GetComponent<Renderer>();
        if (other.tag=="Bcollider")
        {
            //Makes the building visible
            rend.enabled = true;
        }
    }
  
}
