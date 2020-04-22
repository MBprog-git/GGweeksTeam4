using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grimpomatic : MonoBehaviour
{
    public Transform Destination;
    bool hooked;
    GameObject Player;
    Vector3 Going;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hooked)
        {
             Going = (Destination.transform.position - Player.transform.position).normalized * GameManager.instance.speed;
            Player.GetComponent<Rigidbody>().velocity = new Vector3(Going.x, Going.y, Going.z);
            Player.GetComponent<PlayerController>()._Grounded = true;

            if (Vector3.Distance(Player.transform.position, Destination.transform.position) <= 0.5f)
            {
                hooked = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().IsJumping != false)
        {
            hooked = true;
            Player = other.gameObject;
        }
    }
}
