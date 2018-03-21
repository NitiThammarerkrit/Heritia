using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowN : MonoBehaviour {
    
    public GameObject cam;
    public GameObject T;
    public static bool m ;
    
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = T.transform.position;
        Vector3 cameraPosition = cam.transform.position;
        
        cam.transform.position = new Vector3(targetPosition.x, cameraPosition.y,cameraPosition.z);
      
		if (cam.transform.position.x <= 2.5f)
        {
			cam.transform.position = new Vector3 (2.5f, cam.transform.position.y, cam.transform.position.z);
		}
        if (cam.transform.position.x >= 170)
        {
			cam.transform.position = new Vector3(170, cam.transform.position.y, cam.transform.position.z);
            m = true;
		}
        if (this.transform.position.x > 2.5f && this.transform.position.x < 170)
        {
            this.GetComponent<CameraFollow>().enabled = true;
            this.GetComponent<CameraFollowN>().enabled = false;
            
        }

    }
}
