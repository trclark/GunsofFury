using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 5;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, 0, speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("hit the player");
            other.GetComponent<PlayerController>().hurt();
    //Destroy(this.gameObject);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
            if(collision.gameObject.tag == "Player")
            {
                Debug.Log("hit the player");
                collision.gameObject.GetComponent<PlayerController>().hurt();
        //Destroy(this.gameObject);
            }
    }*/
}
