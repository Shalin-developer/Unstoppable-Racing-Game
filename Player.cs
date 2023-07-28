using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput;//Value for horizontal input
    public float forwardInput;//Value for vertical input
    public float _speed;//Forward and backward speed variable
    public int turnspeed;//Right and left turn speed variable
    public int maxSpeed;//Maximum forward acceleration of the car
    public int minSpeed;//Minimum forward acceleration of the car

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get's the left and right input
        horizontalInput = Input.GetAxis("Horizontal");
        //Get's the forward or backward input
        forwardInput = Input.GetAxis("Vertical");
        //If forward or backward keys are pressed then the car moves in that direction
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * forwardInput);
        //If there is acceleration along horizontal axis then only the car turns with speed
        if(forwardInput>0 || forwardInput<0)
        {
            transform.Rotate(Vector3.up, turnspeed * Time.deltaTime * horizontalInput);
        }
        //If the speed of the car is less than maxspeed then it is made maxspeed
        if(forwardInput > 0)
        {
            if (_speed <= maxSpeed)
                _speed += 1 * Time.deltaTime;
            else
                _speed = maxSpeed;           
        }
        //If the movement of car is in backward direction then speed should be decreased
        else if(forwardInput < 0)
        {
            if (_speed >= minSpeed && _speed > 4)
                _speed -= 4 * Time.deltaTime;
        }
        //if there is no acceleration in any direction then the car should brake
        else if(forwardInput == 0)
        {
            if(_speed > 2)
            {
                _speed -= 2 * Time.deltaTime;
            }
        }
    }
}
