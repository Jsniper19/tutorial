using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public GameObject PLAYER;
    public GameObject Player;
    public GameObject SwingRope;
    public Transform SwingHook;
    public Animation swing;
    public bool swinging;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SwingRope.SetActive(true);
            swing.Play();
            Player.transform.parent = SwingHook.transform;
            Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Player.transform.localPosition = Vector3.zero;
            Player.GetComponent<Rigidbody>().useGravity = false;
            //Player.transform.localScale = Vector3.one;
            swinging = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SwingRope.SetActive(false);
            swing.Stop();
            Player.transform.parent = PLAYER.transform;
            Player.transform.localScale = Vector3.one;
            swinging = false;
        }
    }
}
