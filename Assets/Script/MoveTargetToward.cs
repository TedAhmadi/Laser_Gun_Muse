using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetToward : MonoBehaviour {

    //public Transform MixedReality_Camera;
    public float speed = 2f;
    public Transform CurrentTarget;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CurrentTarget = MixedReality_Camera;
        if (CurrentTarget != null) transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.position, speed * Time.deltaTime);
    }
}
