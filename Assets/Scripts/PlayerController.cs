using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    private Rigidbody rb;
    public int pickUpCount;
    private Timer timer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Get the number of pick ups in our scene
        pickUpCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        //Run the Check Pickups Function
        CheckPickUps();
        //Get the timer object and start the timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0 , moveVertical);
        rb.AddForce(movement * 10);
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(
      other.gameObject.CompareTag("Pickup"))
        {
            //Destroy the collided object
            Destroy(other.gameObject);
            //Decrement the pick up count
            pickUpCount--;
            //Run the CheckPickUps option
            CheckPickUps();
        }
    }
  
    void CheckPickUps()
    {
        print("Pick Ups Left: " + pickUpCount);
        if (pickUpCount == 0)
        {
            timer.StopTimer();
            print("Yay! You Won");
        }
    }

}
