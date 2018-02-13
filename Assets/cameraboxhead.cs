using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraboxhead : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    // Use this for initialization
    void Start()
    {

    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position;
            //Vector3 smoothedPosition2 = Vector3.Lerp(transform.position, a, smoothSpeed * Time.deltaTime);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.localPosition = new Vector3(smoothedPosition.x, smoothedPosition.y, -10f);
    }


    
}
