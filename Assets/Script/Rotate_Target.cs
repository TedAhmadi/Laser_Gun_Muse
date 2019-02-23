using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Target : MonoBehaviour {

    //public GameObject MixedReality_Camera;
    //public GameObject Rotating_Cube;
    public float rotatationspeed = -10f;
    public float speed = -2f;
    public float speeds = -2f;
    public float approach = 10f;
    //public Transform MixedRealityCamera;
    // Use this for initialization
    void Start()
    {


    }

    void Update()
    {
        //float step = approach * Time.deltaTime;
        RotateAround();
    }

    // Update is called once per frame
    void RotateAround()
    {
        transform.Rotate(speed, 0, speeds);
        transform.RotateAround(transform.position, Vector3.up, rotatationspeed * Time.deltaTime); //Orbit around camera
        //transform.position = Vector3.MoveTowards(transform.position, MixedReality_Camera.transform.position, approach * Time.deltaTime);
    }
}
