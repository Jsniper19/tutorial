using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleRopeManagement : MonoBehaviour
{
    public Transform Hook;
    public Transform Launcher;
    public GameObject Rope;
    Vector3 RopeLength;
    float ropeLength;

    private void Start()
    {
        Launcher = GameObject.Find("Launcher").gameObject.transform;
    }


    private void Update()
    {
        RopeLength = Hook.transform.position - Launcher.transform.position;
        ropeLength = RopeLength.magnitude;
        Rope.transform.localScale = new Vector3(0.1f, 5f * ropeLength, 0.1f);
        Rope.transform.localPosition = new Vector3(0, 0, -5f * ropeLength);
    }
}
