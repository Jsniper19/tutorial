using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrapple : MonoBehaviour
{
    public GameObject Grapple;
    public GameObject Launcher;
    public GameObject Player;
    public float grappleSpeed;
    public bool GrappleFired;
    public float velX;
    public float velY;
    public float velZ;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GrappleFired == false)
            {
                GameObject Hook;
                Hook = Instantiate(Grapple, Launcher.transform);
                Hook.GetComponent<Rigidbody>().AddForce(Launcher.transform.forward * grappleSpeed);
                GrappleFired = true;
                Player.GetComponent<Rigidbody>().useGravity = false;
                Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        velX = Player.GetComponent<Rigidbody>().velocity.x;
        velY = Player.GetComponent<Rigidbody>().velocity.y;
        velZ = Player.GetComponent<Rigidbody>().velocity.z;
    }
}
