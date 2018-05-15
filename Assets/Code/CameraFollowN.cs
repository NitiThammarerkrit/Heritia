using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowN : MonoBehaviour {
    
    public GameObject cam;
    public GameObject T;
    public static bool m ;

    public static float[] rightrim = new float[7];

    void Start()
    {
        rightrim[0] = 170.0f;
        rightrim[1] = 3.6f;
        rightrim[2] = 114.0f;
        rightrim[3] = 170.0f;
        rightrim[4] = 142.0f;
        rightrim[5] = 83.0f;
        rightrim[6] = 105.0f;
    }

    // Update is called once per frame
	void Update () {
        T = GameObject.FindWithTag("Player");
        Vector3 targetPosition = T.transform.position;
        Vector3 cameraPosition = cam.transform.position;
        
        cam.transform.position = new Vector3(targetPosition.x, cameraPosition.y,cameraPosition.z);

        if (cam.transform.position.x <= 2.5f)
        {
			cam.transform.position = new Vector3 (2.5f, cam.transform.position.y, cam.transform.position.z);
		}
        if (cam.transform.position.x >= rightrim[Application.loadedLevel])
        {
			cam.transform.position = new Vector3(rightrim[Application.loadedLevel], cam.transform.position.y, cam.transform.position.z);
            m = true;
		}

        if (this.transform.position.x > 2.5f && this.transform.position.x < rightrim[Application.loadedLevel])
        {
            this.GetComponent<CameraFollow>().enabled = true;
            this.GetComponent<CameraFollowN>().enabled = false;
            
        }

    }
}
