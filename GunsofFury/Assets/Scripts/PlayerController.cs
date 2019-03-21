using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    //public float gravity = -9.8f;

    //Health counts
    private int maxcondition = 100;
    [Range(0, 100)]
    private int currentcondition;

    //output current Health to screen
    public Text currentHealth;


    private CharacterController _charCont;

    // Use this for initialization
    void Start()
    {
        currentcondition = maxcondition;
        _charCont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("currentcondtionupdate"+currentcondition);
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    currentcondition = currentcondition - 20;
        //}

        currentHealth.text = currentcondition.ToString();
        if (currentcondition <= 0)
        {
            Debug.Log("You are Dead");
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); //Limits the max speed of the player

        // movement.y = gravity;

        movement *= Time.deltaTime;     //Ensures the speed the player moves does not change based on frame rate
        movement = transform.TransformDirection(movement);
        _charCont.Move(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            Destroy(other.gameObject);
            currentcondition += 5;
            //Debug.Log("current condition ontrigenter"+currentcondition);       
        }
    }

    public void hurt()
    {
        currentcondition -= 1;
    }
}