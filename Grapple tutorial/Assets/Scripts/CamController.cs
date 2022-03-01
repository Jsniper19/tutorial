using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public GameObject grapple;
    public FireGrapple FG;
    public float xSpeed;
    public float ySpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!FG.GrappleFired)
        {
            float horizontal = Input.GetAxis("Mouse X") * xSpeed;
            float vertical = Input.GetAxis("Mouse Y") * ySpeed;


            //apply the rotation via the y axis onto the public GameObject target.
            player.transform.Rotate(0, horizontal, 0);
            cam.transform.Rotate(-vertical, 0, 0);
            //grapple.transform.Rotate(-vertical, 0, 0);
        }

    }
}
