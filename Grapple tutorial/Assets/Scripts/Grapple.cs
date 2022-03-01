using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public GameObject player;
    public GameObject grapple;
    public float playerSpeed;
    public float GrappleTime;
    Vector3 playerTransform;
    Vector3 grappleTransform;
    Vector3 grappleDisplacement;
    bool hooked = false;
    bool pulling = false;

    public FireGrapple FG;
    public Swing swing;

    private void Start()
    {
        
        player = GameObject.Find("Player");
        FG = GameObject.Find("Player").GetComponent<FireGrapple>();
        swing = GameObject.Find("swingArea").GetComponent<Swing>();
    }

    void Update()
    {
        
        //setting transform to variables
        playerTransform = player.transform.position;
        grappleTransform = grapple.transform.position;
        grappleDisplacement = new Vector3(grappleTransform.x - playerTransform.x, grappleTransform.y - playerTransform.y, grappleTransform.z - playerTransform.z);

        if (hooked)
        {
            if (!pulling)
            {
                player.GetComponent<Rigidbody>().AddForce(grappleDisplacement * playerSpeed);
                pulling = true;
            }
        }

        if (grappleDisplacement.magnitude > 20)
        {
            FG.GrappleFired = false;
            pulling = false;
            player.GetComponent<Rigidbody>().useGravity = true;
            Destroy(grapple);
        }

        if (GrappleTime <= 0)
        {
            FG.GrappleFired = false;
            pulling = false;
            player.GetComponent<Rigidbody>().useGravity = true;
            Destroy(grapple);
        }
        else
        {
            GrappleTime -= Time.deltaTime;
        }

        if (swing.swinging)
        {
            Destroy(grapple);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GrappleWall")
        {
            hooked = true;
            grapple.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else
        if (collision.gameObject.tag == "Player")
        {
            if (hooked)
            {
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                FG.GrappleFired = false;
                player.GetComponent<Rigidbody>().useGravity = true;
                pulling = false;
                Destroy(grapple);
            }
        }
        else
        {
            FG.GrappleFired = false;
            player.GetComponent<Rigidbody>().useGravity = true;
            Destroy(grapple);
        }

    }

}
