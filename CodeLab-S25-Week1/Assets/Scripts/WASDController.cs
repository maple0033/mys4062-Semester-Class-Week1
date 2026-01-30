using System;
using UnityEngine;
using UnityEngine.InputSystem;
    
public class WASDController : MonoBehaviour
{ 
    Rigidbody rb; //rigidbody of the gameobject that this script is attached to

    public float moveForce = 10f; //the force we add to the gameobject this script is attached to to make it move 

    public Key keyUp = Key.W; //what key you must press to make things go up the y axis
    public Key keyDown = Key.S; //what key you must press to make things go down the y axis
    public Key keyLeft = Key.A;
    public Key keyRight = Key.D;

    Keyboard keyboard = Keyboard.current; //what keyboard you will use to take in input 

    public float score = 0;
    public GameObject KillForceCheck;
    private bool resetGame = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //getcomponent looks for a component of this type on the gameobject this script is attached to
        Debug.Log(score);
    }

    void FixedUpdate()
    {

        if (keyboard[keyUp].isPressed)
        {
            rb.AddForce(Vector3.forward * moveForce, ForceMode.Acceleration); // give the object an upward force 
        }

        if (keyboard[keyDown].isPressed)
        {
            rb.AddForce(Vector3.down * moveForce, ForceMode.Acceleration);
        }

        if (keyboard[keyLeft].isPressed)
        {
            rb.AddForce(Vector3.left * moveForce, ForceMode.Acceleration);
        }

        if (keyboard[keyRight].isPressed)
        {
            rb.AddForce(Vector3.right * moveForce, ForceMode.Acceleration);
        }
        
        // if(Input.GetKey(KeyCode.S))
        // {
        //     rb.AddForce(Vector3.down * moveForce, ForceMode.Acceleration); // give the object a downard force 
        // }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            score += 1;
            Debug.Log(score);
        }
    }

    private void OnTriggerEnter (Collider other)
    { 
        if (other.gameObject == KillForceCheck)
        {
            Debug.Log("GAME OVER");
            moveForce = 0f;
            resetGame = true;
            TeleportBall();
        }
        
    }

    private void TeleportBall()
    {
        if (resetGame == true)
        {
            Debug.Log("Your Final Score: " + score);
            score = 0;
            resetGame = false;
            rb.position = new Vector3(0, 0, -6); //
            moveForce = 10f;

        }
    }
}